    using Stateless;
    using System.ComponentModel.DataAnnotations;
namespace CRIP.Models
{

           /// <summary>
        /// 订单状态枚举类型
        /// </summary>
        public enum OrderStateEnum
        {
            Pending,//订单已生成
            Processing,//订单处理中
            Completed,//交易成功
            Declined,//交易失败
            Cancelled,//订单取消
            Refund,//已退款

        }
        /// <summary>
        /// 订单动作枚举
        /// </summary>
        public enum OrderStateTriggerEnum
        {
            PlaceOrder, // 支付
            Approve, // 收款成功
            Reject, // 收款失败
            Cancel, // 取消
            Return // 退货
        }


        public class Order:BaseEntity
        {
            public Order()//每次创建订单都会初始化订单的状态机
            {
                StateMachineInit();
            }
            public string UserId { get; set; }
            public CRIPUser User { get; set; }
            public ICollection<LineItem> OrderLineItems { get; set; }
            public OrderStateEnum State { get; set; }
            public DateTime CreateDateUTC { get; set; }
            //public string TransactionMetadata { get; set; }

            StateMachine<OrderStateEnum, OrderStateTriggerEnum>? _stateMachine;
        /// <summary>
        /// 订单处理中
        /// </summary>
            public void PaymentProcessing()
            {
                _stateMachine.Fire(OrderStateTriggerEnum.PlaceOrder);
            }
        /// <summary>
        /// 
        /// </summary>

            public void PaymentApprove()
            {
                _stateMachine.Fire(OrderStateTriggerEnum.Approve);
            }

            public void PaymentReject()
            {
                _stateMachine.Fire(OrderStateTriggerEnum.Reject);
            }
            private void StateMachineInit()
            {
                _stateMachine = new StateMachine<OrderStateEnum, OrderStateTriggerEnum>
                    (() => State, s => State = s);
                _stateMachine.Configure(OrderStateEnum.Pending)//配置订单已生成状态
                    .Permit(OrderStateTriggerEnum.PlaceOrder, OrderStateEnum.Processing)//前一个触发动作，后一个次状态
                    .Permit(OrderStateTriggerEnum.Cancel, OrderStateEnum.Cancelled);
                _stateMachine.Configure(OrderStateEnum.Processing)//配置订单处理中
                    .Permit(OrderStateTriggerEnum.Approve, OrderStateEnum.Completed)
                    .Permit(OrderStateTriggerEnum.Reject, OrderStateEnum.Declined);//Permit准许
                _stateMachine.Configure(OrderStateEnum.Declined)//配置支付失败
                    .Permit(OrderStateTriggerEnum.PlaceOrder, OrderStateEnum.Completed)
                    .Permit(OrderStateTriggerEnum.Cancel, OrderStateEnum.Cancelled);
                _stateMachine.Configure(OrderStateEnum.Completed)//配置支付完成
                    .Permit(OrderStateTriggerEnum.Return, OrderStateEnum.Refund);
            }
    }

}

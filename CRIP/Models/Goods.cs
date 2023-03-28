namespace CRIP.Models
{
    public class Goods:BaseEntity
    {
        /// <summary>
        /// 商品名 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
 
        /// <summary>
        /// 商品信息
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int Quantity { get; set; }
    }
}

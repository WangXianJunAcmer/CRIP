using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CRIP.Services;
using CRIP.Services.IRepositorys;
using CRIP.Common;

namespace CRIP.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICartRepository _CartRepository;
        private IGoodsRepository _goodsRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderController(
           ICartRepository CartRepository,
           IMapper mapper,
           IHttpContextAccessor httpContextAccessor,
           IGoodsRepository goodsRepository
            )
        {
            _CartRepository = CartRepository;
            _goodsRepository = goodsRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("Orders", Name = "GetOrdersByUserId")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOrdersByUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Ok(await _CartRepository.GetOrdersByUserIdAsync(userId));
        }
        [HttpGet("{orderId:Guid}", Name = "GetOrdersByOrderId")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOrdersByOrderId([FromRoute] string orderId)
        {
            return Ok(await _CartRepository.GetOrdersByOrderIdAsync(orderId));
        }

        [HttpPost("payment/{orderId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> paymentOrder(
            [FromRoute] string orderId)
        {
            PagesResponse pagesResponse = new();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (orderId == null)
            {
                pagesResponse.BadRequest("出错，检查订单id");
                return Ok(pagesResponse);
            }
            var order = await _CartRepository.GetOrdersByOrderIdAsync(orderId);

            if (order == null)
            {
                pagesResponse.NotFound("订单不存在");
                return Ok(pagesResponse);
            }

            // 根据订单状态调用相应的方法
            switch (order.State)
            {
                case OrderStateEnum.Pending:
                    order.PaymentProcessing();
                    //await _CartRepository.SaveChangesAsync();
                    pagesResponse.Success("订单已支付，请等待处理结果");
                    break;
                case OrderStateEnum.Processing:
                    pagesResponse.Success("订单正在处理中，请等待处理结果");
                    break;
                case OrderStateEnum.Completed:
                    pagesResponse.Success("订单已支付成功");
                    break;
                case OrderStateEnum.Declined:
                    pagesResponse.BadRequest("订单支付失败，请重新支付");
                    break;
                case OrderStateEnum.Cancelled:
                    pagesResponse.BadRequest("订单已取消");
                    break;
                case OrderStateEnum.Refund:
                    pagesResponse.Success("订单已退款");
                    break;
                default:
                    pagesResponse.BadRequest("订单状态错误");
                    break;
            }

            return Ok(pagesResponse);

        }
    }
}

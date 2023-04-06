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
        /// <summary>
        /// 通过id获得order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("{orderId:Guid}", Name = "GetOrdersByOrderId")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOrdersByOrderId([FromRoute] string orderId)
        {
            return Ok(await _CartRepository.GetOrdersByOrderIdAsync(orderId));
        }
        /// <summary>
        /// 支付订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpPost("payment/{orderId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PaymentOrder(
            [FromRoute] string orderId)
        {
            PagesResponse pagesResponse = new();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(string.IsNullOrWhiteSpace(userId))
            {
                pagesResponse.BadRequest("找不到用户");
                return Ok(pagesResponse);
            }
            if (string.IsNullOrWhiteSpace(orderId))
            {
                pagesResponse.BadRequest("出错，检查订单id");
                return Ok(pagesResponse);
           }
           var order =await _CartRepository.GetOrdersByOrderIdAsync(orderId);
            //进入订单处理
            order.PaymentProcessing();
            //进入到完成订单
            order.PaymentApprove();
            await _CartRepository.SaveAsync();
            pagesResponse.Success("支付成功");
            return Ok(pagesResponse);   
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("payment/{orderId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CancelOrder(
        [FromRoute] string orderId)
        {
            PagesResponse pagesResponse = new();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrWhiteSpace(userId))
            {
                pagesResponse.BadRequest("找不到用户");
                return Ok(pagesResponse);
            }
            if (string.IsNullOrWhiteSpace(orderId))
            {
                pagesResponse.BadRequest("出错，检查订单id");
                return Ok(pagesResponse);
            }
             
            var order = await _CartRepository.GetOrdersByOrderIdAsync(orderId);
            order.PaymentCancel();
            await _CartRepository.SaveAsync();     
            return Ok(pagesResponse);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using CRIP.Services.IRepositorys;
using CRIP.Dtos;
using CRIP.Models;
using CRIP.Common;

namespace CRIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _CartRepository;
        private IGoodsRepository _goodsRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(
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
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetCart()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var Cart = await _CartRepository.GetCartByUserIdAsync(userId);
            var Items = await _CartRepository.GetCartItemsByCartIdAsync(Cart.Id);
            var LineItemRes = _mapper.Map<IEnumerable<LineItemDto>>(Items);
            return Ok(LineItemRes);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AddItemToCart([FromBody] string addCartItemDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var goods = await _goodsRepository.GetByIdAsync(addCartItemDto);
            var Cart = await _CartRepository.GetCartByUserIdAsync(userId);

            if (goods == null)
            {
                return NotFound("旅游路线不存在");
            }
            LineItem lineItem = new LineItem()
            {
                Id = Guid.NewGuid().ToString(),
                GoodsId = addCartItemDto,
                CartId = Cart.Id,
                Title = goods.Name,
                Price = goods.Price

            };
            await _CartRepository.AddItemAsync(lineItem);
            await _CartRepository.SaveAsync();
            var lineItemRes = _mapper.Map<LineItemDto>(lineItem);
            return Ok(lineItemRes);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteItemFromCart([FromBody] DeleteCartItemDto deleteCartItem)
        {
            var item = _mapper.Map<LineItem>(deleteCartItem);
            _CartRepository.DeleteItem(item);
            await _CartRepository.SaveAsync();
            return Ok("删除成功");
        }
        [HttpDelete("item/{ItemIDs}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteItemsFromCartByList
            ([ModelBinder(BinderType = typeof(ArrayModelBinder))]
        [FromRoute]IEnumerable<string> ItemIDs)
        {
            var item = await _CartRepository.GetBatchItemsByIDsAsync(ItemIDs);
            _CartRepository.DeleteItemByList(item);
            await _CartRepository.SaveAsync();
            return Ok("删除成功");
        }

        /// <summary>
        /// 全部下单
        /// </summary>
        /// <returns></returns>
        [HttpPost("Checkout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CheckouteCart()
        {
            PagesResponse pagesResponse = new();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cart = await _CartRepository.GetCartByUserIdAsync(userId);
            if (cart.CartItems.Count == 0)
            {
                pagesResponse.NotFound("购物车为空");
                return Ok(pagesResponse);
            }
            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                State = OrderStateEnum.Pending,
                UserId = userId,
                CreateDateUTC = DateTime.UtcNow,
            };
            foreach (var item in cart.CartItems)
            {
                item.OrderId = order.Id;
            }
            order.OrderLineItems = cart.CartItems;
            await _CartRepository.AddOrderAsync(order);

            cart.CartItems = null;

            await _CartRepository.SaveAsync();

            var OrderRes = _mapper.Map<OrderDto>(order);
            pagesResponse.Success(OrderRes);
            return Ok(pagesResponse);
        }
        /// <summary>
        /// 批量下单
        /// </summary>
        /// <param name="ItemIDs"></param>
        /// <returns></returns>

        [HttpPost("BatchCheckout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> BatchCheckouteCart(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]
            [FromBody]IEnumerable<string> ItemIDs)
        {
            PagesResponse pagesResponse = new();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ItemIDs == null)
            {
                pagesResponse.BadRequest("出错，请重试！");
                return Ok(pagesResponse);
            }
            var Items = await _CartRepository.GetBatchItemsByIDsAsync(ItemIDs);

            if (Items.Count() == 0)
            {
                pagesResponse.NotFound("没有该商品");
                return Ok(pagesResponse);
            }

            Order order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                State = OrderStateEnum.Pending,
                CreateDateUTC = DateTime.UtcNow,
            };
            foreach (var item in Items)
            {
                item.CartId = null;
                item.OrderId = order.Id;
            }
            order.OrderLineItems = (ICollection<LineItem>)Items;
            await _CartRepository.AddOrderAsync(order);
            //_CartRepository.DeleteItemByList(Items);
            await _CartRepository.SaveAsync();


            var orderRes = _mapper.Map<OrderDto>(order);
            pagesResponse.Success(orderRes);
            return Ok(pagesResponse);

        }
    }

}

  
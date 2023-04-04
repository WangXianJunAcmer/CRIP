using CRIP.Database;
using CRIP.Models;
using CRIP.Services.IRepositorys;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRIP.Services.Repositorys
{
    public class CartRepository: BaseRepository<Cart>, ICartRepository
    {
            private readonly CRIPDbContext _DbContext;
            public CartRepository(CRIPDbContext CRIPDbContext) : base(CRIPDbContext)
            {
                _DbContext = CRIPDbContext;
            }


            public async Task AddItemAsync(LineItem lineItem)
            {
                await _DbContext.LineItems.AddAsync(lineItem);
            }

            public async Task AddItemsAsync(IEnumerable<LineItem> items)
            {
                await _DbContext.LineItems.AddRangeAsync(items);
            }

            public async Task AddOrderAsync(Order order)
            {
                await _DbContext.Orders.AddAsync(order);
            }

            public async Task AddCartAsync(Cart Cart)
            {
                await _DbContext.Carts.AddAsync(Cart);
            }

            public void DeleteItem(LineItem lineItem)
            {
                _DbContext.LineItems.Remove(lineItem);
            }

            public void DeleteItemByList(IEnumerable<LineItem> lineItems)
            {
                _DbContext.LineItems.RemoveRange(lineItems);
            }

            public async Task<IEnumerable<LineItem>> GetBatchItemsByIDsAsync(IEnumerable<string> IDs)
            {
                var res = await _DbContext.LineItems.Where(x => IDs.Contains(x.Id)).ToListAsync();
            return res;
            }

            public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
            {
                return await _DbContext.Orders.Where(x => x.UserId == userId).Include(u=>u.User).Include(o=>o.OrderLineItems).ToListAsync();
            }

            public async Task<Order> GetOrdersByOrderIdAsync(string orderId)
            {
                return await _DbContext.Orders.Include(x => x.OrderLineItems)
                    .FirstOrDefaultAsync(o => o.Id == orderId);
            }

            public async Task<Cart> GetCartByUserIdAsync(string userId)
            {
                return await _DbContext.Carts
                     .Include(u => u.CripUser)
                     .Include(s => s.CartItems)
                     .Where(u => u.UserId == userId)
                     .FirstOrDefaultAsync();
            }

            public async Task<IEnumerable<LineItem>> GetCartItemsByCartIdAsync(string CartId)
            {
                return await _DbContext.LineItems.Where(x => x.CartId == CartId).ToListAsync();
            }

            public async Task SaveAsync()
            {
                await _DbContext.SaveChangesAsync();
            }

        }
    
}

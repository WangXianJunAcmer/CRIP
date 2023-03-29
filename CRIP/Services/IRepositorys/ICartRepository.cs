using CRIP.Models;

namespace CRIP.Services.IRepositorys
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task AddItemAsync(LineItem lineItem);
        Task SaveAsync();
        void DeleteItem(LineItem lineItem);
        void DeleteItemByList(IEnumerable<LineItem> lineItems);//通过列表删除LineItem
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order> GetOrdersByOrderIdAsync(string orderId);
        Task AddOrderAsync(Order order);
        Task AddCartAsync(Cart Cart);
        Task<IEnumerable<LineItem>> GetCartItemsByCartIdAsync(string CartId);
        Task<IEnumerable<LineItem>> GetBatchItemsByIDsAsync(IEnumerable<string> IDs);
        Task AddItemsAsync(IEnumerable<LineItem> items);
    }
}

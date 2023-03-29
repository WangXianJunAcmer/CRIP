namespace CRIP.Models
{
    public class Cart:BaseEntity
    {
        public string UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}

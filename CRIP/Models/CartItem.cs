namespace CRIP.Models
{
    public class CartItem:BaseEntity
    {
        public string GoodsId { get; set; }
        public string CartId { get; set; }
        public int GoodsQuantity { get; set; }
    }
}

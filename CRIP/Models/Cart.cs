using System.ComponentModel.DataAnnotations;

namespace CRIP.Models
{
    public class Cart:BaseEntity
    {
        public string UserId { get; set; }
        public CRIPUser CripUser { get; set; }
        public ICollection<LineItem> CartItems { get; set; }
    }
}

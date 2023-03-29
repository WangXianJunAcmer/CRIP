using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRIP.Models
{
    public class LineItem:BaseEntity
    {
        public string Title { get; set; }
        [ForeignKey("GoodsId")]

        public string GoodsId { get; set; }
        public Goods Goods{ get; set; }
        public string?  CartId { get; set; }
        public string? OrderId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}

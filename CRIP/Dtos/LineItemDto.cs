using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRIP.Dtos
{
    public class LineItemDto
    {
        public string Id { get; set; }
        public string GoodsId { get; set; }
        public string? CartId { get; set; }
        public string? OrderId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}

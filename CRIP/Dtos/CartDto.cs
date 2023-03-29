using CRIP.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRIP.Dtos
{
    public class CartDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ICollection<LineItemDto> CartItems { get; set; }
    }
}

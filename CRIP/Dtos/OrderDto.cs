using CRIP.Dtos;
using CRIP.Models;
namespace CRIP.Dtos
{
    public class OrderDto
    {

        public string Id { get; set; }
        public string UserId { get; set; }
        public ICollection<LineItemDto> OrderLineItems { get; set; }
        public OrderStateEnum OrderState { get; set; }
        public DateTime CreateDataTime { get; set; }

    }
}

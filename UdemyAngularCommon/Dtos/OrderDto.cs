using System.Collections.Generic;

namespace UdemyAngularCommon.Dtos
{
    public class OrderDto
    {
        public OrderSubDto OrderSubDto { get; set; }

        public List<OrderItemModelDto> OrderItemModelDtos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyAngularCommon.Dtos
{
    public class OrderItemModelDto
    {
        public int? OrderItemId { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
    }
}

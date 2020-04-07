using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UdemyAngularData.DbModels
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public decimal GrandTotal { get; set; }
        public string PaymentMethod { get; set; }

        public int? CustomerId { get; set; }

        
        public virtual Customer Customer { get; set; }
        public virtual  ICollection<OrderItem> OrderItems { get; set; }
    }
}

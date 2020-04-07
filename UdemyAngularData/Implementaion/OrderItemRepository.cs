using System;
using System.Collections.Generic;
using System.Text;
using UdemyAngularData.DataContext;
using UdemyAngularData.DataContracts;
using UdemyAngularData.DbModels;

namespace UdemyAngularData.Implementaion
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly UdemyAngularDbContext _db;

        public OrderItemRepository(UdemyAngularDbContext db) : base(db)
        {
            _db = db;
        }
    }
}

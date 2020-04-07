using System;
using System.Collections.Generic;
using System.Text;
using UdemyAngularData.DataContext;
using UdemyAngularData.DataContracts;
using UdemyAngularData.DbModels;

namespace UdemyAngularData.Implementaion
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly UdemyAngularDbContext _db;
        public OrderRepository(UdemyAngularDbContext db) : base(db)
        {
            _db = db;
        }
    }
}

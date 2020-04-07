using System;
using System.Collections.Generic;
using System.Text;
using UdemyAngularData.DataContext;
using UdemyAngularData.DataContracts;
using UdemyAngularData.DbModels;

namespace UdemyAngularData.Implementaion
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly UdemyAngularDbContext _db;


        public ItemRepository(UdemyAngularDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

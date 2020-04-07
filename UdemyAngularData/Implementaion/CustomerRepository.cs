using UdemyAngularData.DataContext;
using UdemyAngularData.DataContracts;
using UdemyAngularData.DbModels;

namespace UdemyAngularData.Implementaion
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly UdemyAngularDbContext _db;

        public CustomerRepository(UdemyAngularDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

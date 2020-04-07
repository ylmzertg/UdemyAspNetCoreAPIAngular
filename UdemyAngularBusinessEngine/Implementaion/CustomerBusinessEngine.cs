using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UdemyAngularBusinessEngine.Contracts;
using UdemyAngularCommon.Dtos;
using UdemyAngularCommon.ResultConstant;
using UdemyAngularData.DataContracts;

namespace UdemyAngularBusinessEngine.Implementaion
{
    public class CustomerBusinessEngine : ICustomerBusinessEngine
    {
        private readonly IUnitOfWork _uow;

        public CustomerBusinessEngine(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Result<List<CustomerDto>> GetCustomers()
        {
            List<CustomerDto> items = new List<CustomerDto>();
            var data = _uow.customer.GetAll().ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    items.Add(new CustomerDto()
                    {
                        CustomerId = item.CustomerId,
                        Name = item.Name,
                    });
                }
                return new Result<List<CustomerDto>>(true, ResultConstant.RecordFound, items);
            }
            return new Result<List<CustomerDto>>(false, ResultConstant.RecordNotFound);
        }
    }
}

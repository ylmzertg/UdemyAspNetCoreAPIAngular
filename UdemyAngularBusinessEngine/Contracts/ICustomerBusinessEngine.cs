using System;
using System.Collections.Generic;
using System.Text;
using UdemyAngularCommon.Dtos;
using UdemyAngularCommon.ResultConstant;

namespace UdemyAngularBusinessEngine.Contracts
{
    public interface ICustomerBusinessEngine
    {
        Result<List<CustomerDto>> GetCustomers();
    }
}

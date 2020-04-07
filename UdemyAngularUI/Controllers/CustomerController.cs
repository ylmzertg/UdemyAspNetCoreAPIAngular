using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UdemyAngularBusinessEngine.Contracts;
using UdemyAngularCommon.Dtos;

namespace UdemyAngularUI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusinessEngine _customerBusiness;

        public CustomerController(ICustomerBusinessEngine customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [HttpGet("GetCustomerList")]
        public List<CustomerDto> GetCustomerList()
        {
            return _customerBusiness.GetCustomers().Data;
        }
    }
}
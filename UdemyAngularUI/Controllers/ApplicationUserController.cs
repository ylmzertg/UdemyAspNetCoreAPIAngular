using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdemyAngularBusinessEngine.Contracts;
using UdemyAngularCommon.Dtos;
using UdemyAngularData.DbModels;

namespace UdemyAngularUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserBusinessEngine _applicationUserEngine;

        public ApplicationUserController(IApplicationUserBusinessEngine applicationUserEngine)
        {
            _applicationUserEngine = applicationUserEngine;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Register")]
        //www.denemePorject.com/api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserDto model)
        {
            var data = await _applicationUserEngine.CreateApplicationUser(model);
            var result = data.Data;
            return Ok(result);
        }
    }
}
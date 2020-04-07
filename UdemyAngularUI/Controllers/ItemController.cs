using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyAngularBusinessEngine.Contracts;
using UdemyAngularCommon.Dtos;

namespace UdemyAngularUI.Controllers
{
    [Route("api/Item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemBusinessEngine _itemBusiness;

        public ItemController(IItemBusinessEngine itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [HttpGet("GetItems")]
        public List<ItemDto> GetItems()
        {
            return _itemBusiness.GetItems().Data;
        }

    }
}
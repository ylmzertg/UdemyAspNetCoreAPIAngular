using System;
using System.Collections.Generic;
using System.Text;
using UdemyAngularCommon.Dtos;
using UdemyAngularCommon.ResultConstant;

namespace UdemyAngularBusinessEngine.Contracts
{
    public interface IItemBusinessEngine
    {
        Result<List<ItemDto>> GetItems();
    }
}

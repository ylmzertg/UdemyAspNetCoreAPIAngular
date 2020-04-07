using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyAngularCommon.Dtos;
using UdemyAngularCommon.ResultConstant;
using UdemyAngularData.DbModels;

namespace UdemyAngularBusinessEngine.Contracts
{
    public interface IApplicationUserBusinessEngine
    {
         Task<Result<object>> CreateApplicationUser(ApplicationUserDto model);
    }
}

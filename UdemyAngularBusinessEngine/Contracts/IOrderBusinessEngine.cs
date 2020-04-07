using System.Collections.Generic;
using UdemyAngularCommon.Dtos;
using UdemyAngularCommon.ResultConstant;

namespace UdemyAngularBusinessEngine.Contracts
{
    public interface IOrderBusinessEngine
    {
        Result<bool> SaveOrder(OrderDto order);
        Result<List<GetOrderDto>> GetOrders();
        Result<bool> DeleteOrder(int id);
    }
}

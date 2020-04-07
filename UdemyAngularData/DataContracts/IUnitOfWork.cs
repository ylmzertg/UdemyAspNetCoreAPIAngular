using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyAngularData.DataContracts
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository items { get; }
        IOrderRepository order { get; }
        IOrderItemRepository orderItem { get; }
        ICustomerRepository customer { get; }
        void Save();
    }
}

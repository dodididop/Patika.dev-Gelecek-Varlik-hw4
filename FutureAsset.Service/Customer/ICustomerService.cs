using System;
using FutureAsset.Model;

namespace FutureAsset.Service.Customer
{
    public interface ICustomerService
    {
        public Response<bool> Create(CustomerViewModel newCustomer);
    }
}

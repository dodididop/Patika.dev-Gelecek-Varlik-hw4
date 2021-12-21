using System;
using FutureAsset.Model;
using AutoMapper;
using FutureAsset.DB.Entities.DatabaseContext;

namespace FutureAsset.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        public CustomerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Response<bool> Create(CustomerViewModel newCustomer)
        {
            try
            {
                var customer = _mapper.Map<FutureAsset.DB.Entities.Customer>(newCustomer);

                customer.CreateDate = DateTime.Now.Date;
                customer.IsActive = true;
                customer.IsDeleted = false;

                using (var srv = new FutureAssetDBContext())
                {
                    srv.Customer.Add(customer);
                    srv.SaveChanges();
                    return new Response<bool>(true);
                }
            }
            catch (Exception)
            {
                return new Response<bool>(false);
            }
        }
    }
}

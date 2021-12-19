using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FutureAsset.Model;
using FutureAsset.Service.Customer;
using Microsoft.AspNetCore.Mvc;



namespace FutureAsset.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerservice;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper) 
        {
            _customerservice = customerService;
            _mapper = mapper;
        }
        [HttpPost]
        public Response<bool> Create([FromBody] CustomerViewModel request)
        {
            return _customerservice.Create(request);
             
        }
    }
}

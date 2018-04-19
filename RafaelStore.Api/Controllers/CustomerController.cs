using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Outputs;
using RafaelStore.Domain.StoreContext.Entities;
using RafaelStore.Domain.StoreContext.Handlers;
using RafaelStore.Domain.StoreContext.Queries;
using RafaelStore.Domain.StoreContext.Repositories;
using RafaelStore.Shared.Commands;

namespace RafaelStore.Api.Controllers
{    
    public class CustomerController: Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _customerHandler;
        public CustomerController(ICustomerRepository repository, CustomerHandler customerHandler)
        {
            _repository = repository;
            _customerHandler = customerHandler;
        }
        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache( Duration = 60)]
        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]// armazena os dados no cliente
        public IEnumerable<ListCustomerQueryResult>Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }
        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody] CreateCustumerCommad commad){

            var result = (CreateCustomerCommandResult)_customerHandler.Handle(commad);
            return result;          
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody] Customer customer){
            return null;            
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public Customer Delete(){
            return null;            
        }
    }
}
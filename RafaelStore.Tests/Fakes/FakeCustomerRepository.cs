using RafaelStore.Domain.StoreContext.Entities;
using RafaelStore.Domain.StoreContext.Queries;
using RafaelStore.Domain.StoreContext.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RafaelStore.Tests.Fakes
{
    class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrderCountResult GetCustomerOrderCountResult(string document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
        }
    }
}

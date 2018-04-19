using System;
using System.Collections.Generic;
using RafaelStore.Domain.StoreContext.Entities;
using RafaelStore.Domain.StoreContext.Queries;

namespace RafaelStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);

        void Save(Customer customer);
        CustomerOrderCountResult GetCustomerOrderCountResult(string document);
        IEnumerable<ListCustomerQueryResult> Get();        
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id); 

    }
}

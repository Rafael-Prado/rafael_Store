using System;
namespace RafaelStore.Domain.StoreContext.Queries
{
    public class CustomerOrderCountResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Orders { get; set; }
    }
}

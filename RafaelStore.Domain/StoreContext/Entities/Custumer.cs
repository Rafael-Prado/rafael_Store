
using RafaelStore.Domain.StoreContext.ValuesObject;
using RafaelStore.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RafaelStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _address;

        public Customer(
            Name name,
            Document document,
            Email email,
            string phone)
        {
           Name = name;
           Document= document;
           Email= email;
           Phone= phone;
            _address = new List<Address>();
            
        }
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _address.ToArray();

        public void AddAddress(Address address)
        {
            //validar Endereço
            //adicionando enderço
            _address.Add(address);

        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

}
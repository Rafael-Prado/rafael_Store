
using FluentValidator;
using FluentValidator.Validation;

namespace RafaelStore.Domain.StoreContext.ValuesObject
{
    public class Email: Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract().Requires()
                 .IsEmail(Address,"FirsName", "E mail inválido")
                 );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}

using FluentValidator;
using FluentValidator.Validation;

namespace RafaelStore.Domain.StoreContext.ValuesObject
{
    public class Name: Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddNotifications(new ValidationContract().Requires()
                 .HasMinLen(FirstName, 3, "FirsName", "o nome deve conter no minimo 3 caracteres")
                 .HasMaxLen(FirstName, 40, "FirsName", "o nome deve conter no maximo 40 caracteres")
                 .HasMinLen(FirstName, 3, "LastName", "o sobrenome deve conter no minimo 3 caracteres")
                 .HasMaxLen(FirstName, 40, "LastName", "o sobrenome deve conter no maximo 40 caracteres")
                 );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";

        }
    }
}

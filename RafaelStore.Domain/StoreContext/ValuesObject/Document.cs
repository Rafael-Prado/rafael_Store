
using FluentValidator;
using FluentValidator.Validation;

namespace RafaelStore.Domain.StoreContext.ValuesObject
{
   public class Document: Notifiable
    {
        public Document(string number)
        {
            Number = number;
            AddNotifications(new ValidationContract().Requires()
                 .IsTrue(Validate(Number), "Document", "Cpf Inválido" )
                 );
        }

        public string Number { get; private set; }


        public override string ToString()
        {
            return Number;
        }

        public bool Validate(string cpf)
        {
            return true;
        }
    }
}

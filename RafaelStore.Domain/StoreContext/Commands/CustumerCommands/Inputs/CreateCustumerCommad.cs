using FluentValidator;
using FluentValidator.Validation;
using RafaelStore.Shared.Commands;

namespace RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Inputs
{
    public class CreateCustumerCommad: Notifiable, ICommands
    {
        public string FirstName { get; set; }
        public string LestName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                 .HasMinLen(FirstName, 3, "FirsName", "o nome deve conter no minimo 3 caracteres")
                 .HasMaxLen(FirstName, 40, "FirsName", "o nome deve conter no maximo 40 caracteres")
                 .HasMinLen(FirstName, 3, "LestName", "o sobrenome deve conter no minimo 3 caracteres")
                 .HasMaxLen(FirstName, 40, "LestName", "o sobrenome deve conter no maximo 40 caracteres")
                 .IsEmail(Email, "FirsName", "E mail inválido")
                 .HasLen(Document, 11, "Document", "CPF inválido")
                 );

            return IsValid;
        }

    }
}

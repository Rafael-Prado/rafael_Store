using FluentValidator;
using RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Outputs;
using RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using RafaelStore.Domain.StoreContext.Entities;
using RafaelStore.Domain.StoreContext.ValuesObject;
using RafaelStore.Shared.Commands;
using System;
using RafaelStore.Domain.StoreContext.Repositories;
using RafaelStore.Domain.StoreContext.Services;

namespace RafaelStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable, 
        ICommandHandler<CreateCustumerCommad>, 
        ICommandHandler<AddAddressCommand>

    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustumerCommad command)
        {
            //Verificar se o cpf ja existe na base
            if (_repository.CheckDocument(command.Document))
            {
                AddNotification("Document", "Este CPF já esta em uso");
            }
            //Verificar se os E-mail ja exite na base

            if (_repository.CheckEmail(command.Email))
            {
                AddNotification("Email", "Este E-mail já esta em uso");
            }
            //Criar os VOS
             var name = new Name(command.FirstName, command.LestName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar Entidade
            var customer = new Customer(name, document, email, command.Phone);

            //validar entidades e VOS
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
            {
                return new CreateCommandResult(true, "Ocorreu um erro!! ", 
                Notifications);
            }

            //Persitir o cliente
            _repository.Save(customer);

            //Enviar o Email
            _emailService.Send(email.Address, "rafael@prado", "Bem vindo", "Seja bem vido ao Rafael Store!!");

            //Retornar o resultado para tela
            return new CreateCommandResult(true, "Bem vido ", new{
               Id = customer.Id,
               Name = name.ToString(),
               Email = email.Address
            });
        }


        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

using RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using RafaelStore.Shared.Commands;

namespace RafaelStore.Domain.StoreContext.Handlers
{
    public interface ICustomerHandler
    {
        ICommandResult Handle(CreateCustumerCommad command);
    }
}
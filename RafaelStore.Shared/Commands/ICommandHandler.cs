
namespace RafaelStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommands
    {
        ICommandResult Handle(T command);
    }
}

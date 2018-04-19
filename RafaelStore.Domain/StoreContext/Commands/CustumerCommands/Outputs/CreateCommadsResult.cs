
using RafaelStore.Shared.Commands;
using System;

namespace RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Outputs
{
    public class CreateCommandResult: ICommandResult
    {
        public CreateCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get ; set ; }
        public string Message { get; set; }
        public object Data { get ; set; }
    }
}
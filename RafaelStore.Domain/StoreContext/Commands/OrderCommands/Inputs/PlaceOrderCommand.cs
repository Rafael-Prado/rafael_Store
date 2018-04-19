using FluentValidator;
using FluentValidator.Validation;
using RafaelStore.Shared.Commands;
using System;
using System.Collections.Generic;

namespace RafaelStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand: Notifiable , ICommands
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Custumer { get; set; }

        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                 .HasLen(Custumer.ToString(), 36, "Customer", "Identificador do cliente é inválido")
                 .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenum item foi encotrado")
                 );

            return IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }

        public decimal Quantity { get; set; }


    }
}

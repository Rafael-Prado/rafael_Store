using FluentValidator;
using RafaelStore.Domain.StoreContext.Enums;
using RafaelStore.Shared.Commands;
using System;
using System.Collections.Generic;

namespace RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Inputs
{
    public class AddAddressCommand: Notifiable, ICommands
    {

        public Guid Id { get; set; }
        public string Street { get;set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        bool ICommands.Valid()
        {
            return IsValid;
        }
    }
}

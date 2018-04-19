using Microsoft.VisualStudio.TestTools.UnitTesting;
using RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using RafaelStore.Domain.StoreContext.Handlers;
using RafaelStore.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RafaelStore.Tests.Handler
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public void MetodoValidDeveRetornorTrue()
        {
            var command = new CreateCustumerCommad();
            command.FirstName = "Rafael";
            command.LestName = "Prado";
            command.Document = "12332323232";
            command.Email = "rafael@hotmail.com";
            command.Phone = "12332323232";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);

        }
    }
}

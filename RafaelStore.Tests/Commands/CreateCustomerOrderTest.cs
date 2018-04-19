using Microsoft.VisualStudio.TestTools.UnitTesting;
using RafaelStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;

namespace RafaelStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerOrderTest
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

            Assert.AreEqual(true, command.Valid());

        }

    }
}

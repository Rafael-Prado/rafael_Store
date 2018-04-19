using Microsoft.VisualStudio.TestTools.UnitTesting;
using RafaelStore.Domain.StoreContext.Entities;
using RafaelStore.Domain.StoreContext.ValuesObject;

namespace RafaelStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Rafael", "Prado");
            var document = new Document("12312322221");
            var email = new Email("rafael@email.com");

            var c = new Customer(name, document, email, "11121212");
            var mouse = new Product("Mouse", "Rato", "image.png", 10.50M, 10);
            var teclado = new Product("Teclado", "teclado", "image.png", 10.50M, 10);
            var impressora = new Product("Impressora", "impressora", "image.png", 122.50M, 10);
            var cadeira = new Product("Cadeira", "cadeira", "image.png", 222.50M, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(impressora, 5));
            //order.AddItem(new OrderItem(cadeira, 5));

            //Realizei o pedido
            order.Place();

            //Verificar se o pedido é valido
            var validacao = order.IsValid;

            //Simulando um pagamento
            order.Pay();
            //simular envio 
            order.Ship();
            //simular cancelamento
            order.cancel();
        }
    }
}

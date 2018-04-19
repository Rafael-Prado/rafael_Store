using Microsoft.VisualStudio.TestTools.UnitTesting;
using RafaelStore.Domain.StoreContext.Entities;
using RafaelStore.Domain.StoreContext.Enums;
using RafaelStore.Domain.StoreContext.ValuesObject;

namespace RafaelStore.Tests.Entities
{
    [TestClass]
    public class OrdersTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Product _acer;

        private Customer _custumer;
        private Order _order;
        public OrdersTests()
        {
            var name = new Name("Rafael", "Prado");
            var document = new Document("11111111111");
            var email = new Email("rafael@prado.com");
            _custumer = new Customer(name, document, email, "121121212211");
            _order = new Order(_custumer);

            _mouse = new Product("Mouse dd", "Mouse dd","image.png", 99M, 10);
            _keyboard = new Product("keyboard dd", "keyboard dd", "image.png", 99M, 10);
            _chair = new Product("chair dd", "chair dd", "image.png", 99M, 10);
            _monitor = new Product("monitor dd", "monitor dd", "image.png", 99M, 10);
            _acer = new Product("acer dd", "acer dd", "image.png", 99M, 10);
        }

        //Consigo criar um novo pedido
        [TestMethod]
        public void CriarUmNovoPedido()
        {
            
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar um pedido o status deve ser created 
        [TestMethod]
        public void AoCriarPedidoStatusDeveSerCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }
        //Ao adicionar um novo item a quantidade deve mudar
        [TestMethod]
        public void AoAdicionarDoisItensQuantidadeDeveSerDois()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_keyboard, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }
        //Ao adicionar um novo item deve subtrair a quantidade de um produto
        [TestMethod]
        public void AoAdicionarUmNovoItemQuantidadeProdutoDeveSubtrair()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }
        //Ao confirmar pedido deve gerar um numero
        [TestMethod]
        public void DeveRetornarUmNumeroPedido()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }
        //Ao pagar pedido, o status deve ser pago
        [TestMethod]
        public void StatusdoPedidoDeveSerPago()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }
        //Dados 10 prdutos, deve aver dua entregas
        [TestMethod]
        public void SeTiverMaisDe5ProddutosDeveTerMais1Entrega()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }
        // Ao cancelar pedido, o status deve ser cancelado
        [TestMethod]
        public void PedidoCanceladoStatusDeveSerCancelado()
        {
            _order.cancel();
            Assert.AreEqual(EOrderStatus.Camceled, _order.Status);
        }
        //Ao cancelar pedido, as entregas deven ser canceladas
        [TestMethod]
        public void PedidoCanceladoDeveCancelarTodasAsEntregas()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
            
        }
    }
}
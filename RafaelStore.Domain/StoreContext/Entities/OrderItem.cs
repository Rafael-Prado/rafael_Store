using FluentValidator;
using RafaelStore.Shared.Entities;

namespace RafaelStore.Domain.StoreContext.Entities
{
    public class OrderItem: Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantidade", "Produto fora de estoque");

            product.DecriaseQuantity(quantity);
           
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}

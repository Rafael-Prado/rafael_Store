using FluentValidator;
using RafaelStore.Domain.StoreContext.Enums;
using RafaelStore.Shared.Entities;
using System;

namespace RafaelStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estmatedDeliveryDate)
        {
            CreatedDate = DateTime.Now;
            EstmatedDeliveryDate = estmatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreatedDate { get; private set; }
        public DateTime EstmatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //se data entrega for no passado não entregar
            Status = EDeliveryStatus.Shipped;
        }

            public void Cancel()
        {
            //se o status ja estiver entregue não pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
        
    }
}

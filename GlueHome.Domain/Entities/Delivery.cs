using GlueHome.Domain.Common;
using GlueHome.Domain.Enums;
using GlueHome.Domain.ValueObjects;
using System;

namespace GlueHome.Domain.Entities
{
    public class Delivery : AuditableEntity
    {
        private DeliveryStatus _status;
        public DeliveryStatus Status
        {
            get => AccessWindow.EndTime < DateTime.UtcNow && _status != DeliveryStatus.Completed ? DeliveryStatus.Expired : _status;
            private set => _status = value; //Changing Status is controlled in the domain level.
        } 

        public AccessWindow AccessWindow { get; set; }

        public Recipient Recipient { get; set; }

        public Order Order { get; set; }

        public void UpdateDeliveryStatus(DeliveryStatus newStatus)
        {
            if (AccessWindow.EndTime > DateTime.UtcNow)
            {
                Status = newStatus;
            }
        }
    }
}

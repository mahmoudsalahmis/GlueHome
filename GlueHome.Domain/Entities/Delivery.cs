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

        /// <summary>
        /// Handle updating delivery status
        /// </summary>
        /// <param name="newStatus">The new delivery status</param>
        /// <exception cref="ArgumentException"></exception>
        public void UpdateDeliveryStatus(DeliveryStatus newStatus)
        {
            switch (newStatus)
            {
                case DeliveryStatus.Created:
                    throw new ArgumentException("Cannot Change Delivery Status to Created", nameof(Status));
                case DeliveryStatus.Approved: //Users may approve a delivery before it starts.
                    if (Status == DeliveryStatus.Created)
                    {
                        Status = newStatus;
                    }
                    else
                    {
                        throw new ArgumentException($"Cannot approve delivery with status equal to {Status}",
                            nameof(Status));
                    }
                    break;
                case DeliveryStatus.Completed: //Partner may complete a delivery, that is already in approved state.
                    if (Status == DeliveryStatus.Approved)
                    {
                        Status = newStatus;
                    }
                    else
                    {
                        throw new ArgumentException($"Cannot complete delivery with status equal to {Status}",
                            nameof(Status));
                    }
                    break;
                case DeliveryStatus.Cancelled: //Either the partner or the user should be able to cancel a pending delivery (in state created or approved ).
                    if (Status == DeliveryStatus.Approved || Status == DeliveryStatus.Created)
                    {
                        Status = newStatus;
                    }
                    else
                    {
                        throw new ArgumentException($"Cannot cancel delivery with status equal to {Status}",
                            nameof(Status));
                    }
                    break;
            }
        }
    }
}

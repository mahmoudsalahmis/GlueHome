using GlueHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlueHome.Persistence.Configurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Delivery");

            builder.HasKey(d => d.Id);

            builder.OwnsOne(t => t.Order).Property(d => d.OrderNumber).HasColumnName("OrderNumber");
            builder.OwnsOne(t => t.Order).Property(d => d.Sender).HasColumnName("OrderSender");

            builder.OwnsOne(t => t.AccessWindow).Property(d => d.StartTime).HasColumnName("AccessWindowStartTime");
            builder.OwnsOne(t => t.AccessWindow).Property(d => d.EndTime).HasColumnName("AccessWindowEndTime");

            builder.OwnsOne(t => t.Recipient).Property(d => d.Name).HasColumnName("RecipientName");
            builder.OwnsOne(t => t.Recipient).Property(d => d.Address).HasColumnName("RecipientAddress");
            builder.OwnsOne(t => t.Recipient).Property(d => d.Email).HasColumnName("RecipientEmail");
            builder.OwnsOne(t => t.Recipient).Property(d => d.PhoneNumber).HasColumnName("RecipientPhone");
        }
    }
}

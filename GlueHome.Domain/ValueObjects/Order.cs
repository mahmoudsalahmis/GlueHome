namespace GlueHome.Domain.ValueObjects
{
    public record Order
    {
        public string OrderNumber { get; init; }

        public string Sender { get; init; }
    }
}

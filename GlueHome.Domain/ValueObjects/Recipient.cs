namespace GlueHome.Domain.ValueObjects
{
    public record Recipient
    {
        public string Name { get; init; }

        public string Address { get; init; }

        public string Email { get; init; }

        public string PhoneNumber { get; init; }
    }
}

using System;

namespace GlueHome.Domain.ValueObjects
{
    public record AccessWindow
    {
        public DateTime StartTime { get; init; }

        public DateTime EndTime { get; init; }
    }
}

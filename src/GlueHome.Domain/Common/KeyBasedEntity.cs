using System;

namespace GlueHome.Domain.Common
{
    public class KeyBasedEntity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}

using System;

namespace GlueHome.Domain.Common
{
    public class AuditableEntity : KeyBasedEntity
    {
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }
    }
}

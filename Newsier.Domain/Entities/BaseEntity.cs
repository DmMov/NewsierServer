using System;

namespace Newsier.Domain.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}

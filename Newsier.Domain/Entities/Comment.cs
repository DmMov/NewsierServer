using System.Collections.Generic;

namespace Newsier.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Value { get; set; }

        public string PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public string PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}

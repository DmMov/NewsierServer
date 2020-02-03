using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            Comments = new HashSet<Comment>();
        }

        public string Value { get; set; }

        public string PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public string PublicationId { get; set; }
        public Publication Publication { get; set; }

        public string ParentId { get; set; }
        public Comment Parent { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

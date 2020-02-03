using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Domain.Entities
{
    public class Publication : BaseEntity
    {
        public Publication()
        {
            Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }
        public string Value { get; set; }

        public string PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

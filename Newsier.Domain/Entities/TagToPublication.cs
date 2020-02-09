using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Domain.Entities
{
    public class TagToPublication : BaseEntity
    {
        public string TagId { get; set; }
        public Tag Tag { get; set; }

        public string PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}

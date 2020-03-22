using System.Collections.Generic;

namespace Newsier.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Publications = new HashSet<Publication>();
        }

        public string Name { get; set; }

        public ICollection<Publication> Publications { get; set; }
    }
}

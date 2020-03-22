using System.Collections.Generic;

namespace Newsier.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
            TagsToPublications = new HashSet<TagToPublication>();
        }

        public string Value { get; set; }

        public ICollection<TagToPublication> TagsToPublications { get; set; }
    }
}

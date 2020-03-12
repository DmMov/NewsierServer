using System.Collections.Generic;

namespace Newsier.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public Publisher()
        {
            Publications = new HashSet<Publication>();
            Comments = new HashSet<Comment>();
        }

        public string Image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Publication> Publications { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

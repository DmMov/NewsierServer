﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Domain.Entities
{
    public class Publication : BaseEntity
    {
        public Publication()
        {
            Comments = new HashSet<Comment>();
            TagsToPublications = new HashSet<TagToPublication>();
        }

        public string Title { get; set; }
        public string Value { get; set; }

        public string PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<TagToPublication> TagsToPublications { get; set; }
    }
}
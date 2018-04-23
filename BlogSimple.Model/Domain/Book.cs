using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Common;

namespace BlogSimple.Model.Domain
{
    public class Book: Entity<int>
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Author Author { get; set; }
    }
}

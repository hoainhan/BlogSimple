using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Common;

namespace BlogSimple.Model.Domain
{
    public class Author:Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}

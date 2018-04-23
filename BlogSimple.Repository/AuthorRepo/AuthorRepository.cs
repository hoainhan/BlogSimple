using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSimple.Model;
using BlogSimple.Model.Domain;
using BlogSimple.Repository;

namespace BlogSimple.Repository
{
    public class AuthorRepository : GenericRepository<Author,BlogSimpleContext>, IAuthorRepository
    {
        public AuthorRepository(BlogSimpleContext dbContext) : base(dbContext)
        {
        }
        public Author GetById(int id)
        {
            return Find(x => x.Id == id).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSimple.Model;
using BlogSimple.Repository;
using BlogSimple.Model.Domain;

namespace BlogSimple.Repository
{
    public class BookRepository:GenericRepository<Book,BlogSimpleContext>, IBookRepository
    {
        public BookRepository(BlogSimpleContext dbContext) : base(dbContext)
        {
        }

        public Book GetById(int id)
        {
            return Find(x=>x.Id == id).FirstOrDefault();
        }
    }
}

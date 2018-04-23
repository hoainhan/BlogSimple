using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Repository;
using BlogSimple.Model.Domain;

namespace BlogSimple.Repository
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        Book GetById(int id);
    }
}

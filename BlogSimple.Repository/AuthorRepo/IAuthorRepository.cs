using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Domain;
using BlogSimple.Repository;

namespace BlogSimple.Repository
{
    public interface IAuthorRepository: IGenericRepository<Author>
    {
        Author GetById(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Domain;
using BlogSimple.Repository;
using BlogSimple.Repository.UnitOfWork;
using BlogSimple.Service;

namespace BlogSimple.Service
{
    public class AuthorService: EntityService<Author>, IAuthorService
    {
        private IAuthorRepository _authorRepository;
        private IUnitOfWork _unitOfWork;
        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork) : base( authorRepository, unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

    }
}

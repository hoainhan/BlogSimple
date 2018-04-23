using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Domain;
using BlogSimple.Repository;
using BlogSimple.Repository.UnitOfWork;
using BlogSimple.Service;

namespace BlogSimple.Service
{
    public class BookService: EntityService<Book>, IBookService
    {
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;
        public BookService( IBookRepository bookRepository, IUnitOfWork unitOfWork) : base( bookRepository, unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

    }
}

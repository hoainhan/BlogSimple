
using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Common;
using BlogSimple.Repository;
using BlogSimple.Repository.UnitOfWork;

namespace BlogSimple.Service
{
    public class EntityService<T> : IEntityService<T> where T: BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public EntityService( IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = genericRepository;
        }
        public void Create(T entity)
        {
            _repository.Insert(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}

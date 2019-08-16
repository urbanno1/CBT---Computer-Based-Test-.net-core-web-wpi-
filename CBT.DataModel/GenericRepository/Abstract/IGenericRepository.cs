using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CBT.DataModel.GenericRepository.Abstract
{
   public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(object id);
        TEntity GetObject(Expression<Func<TEntity, bool>> where);
        TEntity GetSingleObject(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAllObject(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllObject();
        void InsertObject(TEntity entity);
        void InsertRangeOfObejct(IEnumerable<TEntity> entity);
        void UpdateObject(TEntity entityToUpdate);
        void DeleteObject(object id);
        void DeleteRangeOfObject(IEnumerable<TEntity> entity);
        TEntity GetFirstObject(Expression<Func<TEntity, bool>> predicate);
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}

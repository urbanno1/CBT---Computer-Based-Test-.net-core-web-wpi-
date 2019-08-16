using CBT.DataModel.DataModel;
using CBT.DataModel.GenericRepository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CBT.DataModel.GenericRepository.Concrete
{
   public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region private variables
        private CBTDbContext _context;
        private DbSet<TEntity> DbSet;
        #endregion

        #region Constructor
        public GenericRepository(CBTDbContext context)
        {
            this._context = context;
            this.DbSet = _context.Set<TEntity>();
        }


        #endregion

        #region public methods
        public void DeleteObject(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public void DeleteRangeOfObject(IEnumerable<TEntity> entity)
        {
            DbSet.RemoveRange(entity);
        }

        public IEnumerable<TEntity> FindAllObject(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = DbSet;
            return query.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAllObject()
        {
            return DbSet.ToList();
        }

        public TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public TEntity GetFirstObject(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.First<TEntity>(predicate);
        }

        public TEntity GetObject(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).FirstOrDefault<TEntity>();
        }

        public TEntity GetSingleObject(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }

        public void InsertObject(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void InsertRangeOfObejct(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        public void UpdateObject(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = DbSet;
            return query.Any(predicate);
        }

        #endregion
    }
}

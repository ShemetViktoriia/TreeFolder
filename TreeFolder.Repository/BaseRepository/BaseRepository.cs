using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TreeFolder.Repository.BaseRepository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        // ctor
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        #region Get Methods
        public virtual TEntity Find(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual ICollection<TType> Get<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class
        {
            return _context.Set<TEntity>().Where(where).Select(select).ToList();
        }

        public virtual ICollection<TType> Get<TType>(Expression<Func<TEntity, TType>> select) where TType : class
        {
            return _context.Set<TEntity>().Select(select).ToList();
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }
        #endregion

        #region Update Methods
        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }
        #endregion

        #region Add Methods
        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        #endregion

        #region Delete Methods
        public virtual void Delete(int id)
        {
            TEntity ent = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(ent);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        #endregion
    }
}

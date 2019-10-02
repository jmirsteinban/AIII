using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class DALGenericImpl<TEntity> : IDALGeneric<TEntity> where TEntity : class
    {
        protected readonly BDContext context;

        public DALGenericImpl(BDContext _context)
        {
            context = _context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Attach(entity);
                context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public TEntity Get(int id)
        {
            try
            {
                return context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return context.Set<TEntity>().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return context.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

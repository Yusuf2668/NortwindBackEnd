using Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.EntityFramework
{
    public class EfEntityRepositoryBase<TIEntity, TContext> : IEntityRepository<TIEntity>
        where TIEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TIEntity> GetAll(Expression<Func<TIEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TIEntity>().ToList()
                    : context.Set<TIEntity>().Where(filter).ToList();
            }
        }

        public TIEntity Get(Expression<Func<TIEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TIEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TIEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TIEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TIEntity entity)
        {
            using (TContext context = new TContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

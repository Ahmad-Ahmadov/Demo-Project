using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using var context = new TContext();
            var addedEntity = context.Entry(entity);
            entity.GetType().GetProperties()[0].SetValue(entity, GetNextId());
            addedEntity.State= EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State= EntityState.Deleted;
            context.SaveChanges(); 
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return context.Set<TEntity>().FirstOrDefault(filter);
        }
        
        public List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State= EntityState.Modified;  
            context.SaveChanges();
        }
        public int GetNextId()
        {
            using var context = new TContext();
            var result = context.Set<TEntity>().ToList().Select(t => t.GetType()
            .GetProperties()[0].GetValue(t)).LastOrDefault() as int?;
            return result + 1 ?? 1;
        }
    }
}

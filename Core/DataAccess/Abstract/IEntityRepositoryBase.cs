using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteAll();
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        int GetNextId();
    }
}

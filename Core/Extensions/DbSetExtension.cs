using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.Extensions
{
    public static class DbSetExtension
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class,IEntity,new()
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}

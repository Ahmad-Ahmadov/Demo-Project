using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;

namespace DataAccess.Abstract
{
    public interface IBookDal : IEntityRepositoryBase<Book>
    {        
    }
}

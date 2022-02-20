using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Core.Result.Abstract;
using Core.Result.Concrete;
using Business.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        [CacheRemoveAspect("Business.Concrete.IAuthorService")]
        [ValidationAspect(typeof(AuthorValidator))]
        public IResult Add(Author author)
        {
            _authorDal.Add(author);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Concrete.IAuthorService")]
        public IResult Delete(Author author)
        {
            _authorDal.Delete(author);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Author> Get(int id)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll());
        }

        [CacheRemoveAspect("Business.Concrete.IAuthorService")]
        [ValidationAspect(typeof(AuthorValidator))]
        public IResult Update(Author author)
        {
            _authorDal.Update(author);
            return new SuccessResult();
        }
    }
}

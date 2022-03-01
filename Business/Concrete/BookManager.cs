using Business.Abstract;
using Business.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [CacheRemoveAspect("Business.Concrete.IBookService")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Concrete.IBookService")]
        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Concrete.IBookService")]
        public IResult DeleteAll()
        {
            _bookDal.DeleteAll();
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Book> Get(int id)
        {
           return new SuccessDataResult<Book>(_bookDal.Get(b => b.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        [CacheRemoveAspect("Business.Concrete.IBookService")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult();
        }
    }
}

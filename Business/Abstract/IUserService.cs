using Core.Entities.Concrete;
using Core.Result.Abstract;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByEmail(string email);
    }
}

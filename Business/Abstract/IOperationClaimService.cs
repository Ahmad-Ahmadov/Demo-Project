using Core.Entities.Concrete;
using Core.Result.Abstract;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IResult DeleteAll();
        IDataResult<List<OperationClaim>> GetAll();
        IDataResult<OperationClaim> Get(int id);
    }
}

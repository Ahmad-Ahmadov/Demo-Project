using Core.Result.Abstract;

namespace Core.Result.Concrete
{
    public class ErrorResult :Result ,IResult
    {
        public ErrorResult(string message):base(message,false)
        {
        }
        public ErrorResult() : base(false)
        {

        }
    }
}

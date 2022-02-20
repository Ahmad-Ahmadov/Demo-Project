using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Concrete
{
    public class Result :IResult
    {
        public string Message { get ; set; }
        public bool Success { get; set; }
        public Result(string message,bool success) : this(success)
        {
                Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public Result()
        {
        }
       
    }
}

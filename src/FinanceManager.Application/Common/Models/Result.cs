using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.Application.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new Result(succeeded: true, errors: null);
        }

        public static Result Failure(params string[] errors)
        {
            return new Result(succeeded: false, errors);
        }
    }
}

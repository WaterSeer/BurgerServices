using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("One or ore validation failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationException> failures):this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => ErrorMessage)
                .ToDictionary(failuresGroup => failuresGroup.Key, failureGroup => failureGroup.ToArray());
        }





        public IDictionary<string, string[]> Errors { get; }
    }
}

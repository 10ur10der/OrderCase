using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool status, string message) : this(status)
        {
            Message = message;
        }

        public Result(bool status)
        {
            Status = status;
        }

        public bool Status { get; set; }

        public string Message { get; set; }
    }
}

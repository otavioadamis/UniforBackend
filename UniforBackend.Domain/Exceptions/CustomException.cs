using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public ErrorResponse ErrorResponse { get; }

        public CustomException(ErrorResponse errorResponse) : base(errorResponse.Message)
        {
            ErrorResponse = errorResponse;
        }
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}

using Golden_Leaf_Back_End.Models.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golden_Leaf_Back_End.Filters
{
    public class ErrorResponseFilter : IExceptionFilter
    {        
        public void OnException(ExceptionContext context)
        {
            var errorResponse = ErrorResponse.From(context.Exception);
            context.Result = new ObjectResult(errorResponse) { StatusCode = 500 };
        }

    }
}

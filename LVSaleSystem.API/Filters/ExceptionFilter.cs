using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LVSaleSystem.API.Exceptions;
using LVSaleSystem.API.DTO;

namespace LVSaleSystem.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ResourceNotFoundException ex)
            {
                var errorResult = new ErrorResponse
                {
                    Title = "LV Sale System Error",
                    Message = ex.Message,
                    StatusCode = ex.StatusCode
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
            }
            else
            {
                var errorResult = new ErrorResponse
                {
                    Title = "LV Sale System Error",
                    Message = "Internal server error",
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
            }

            _logger.LogError(context.Exception, "Exception caught by: exception filter");
        }

    }
}

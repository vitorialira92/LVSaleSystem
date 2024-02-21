using LVSaleSystem.API.DTO;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LVSaleSystem.API.Filters
{
    public class CustomerAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly TokenService _service;

        public CustomerAuthorizationFilter(TokenService service) { _service = service; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var value))
            {

                var errorResult = new ErrorResponse
                {
                    Title = "LV Sale Authorization Error",
                    Message = "Unauthorized: you must be logged in to access the system",
                    StatusCode = StatusCodes.Status401Unauthorized
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };

                return;
            }
            else
            {
                var token = _service.GetToken(value);

                if (token == null)
                {
                    var errorResult = new ErrorResponse
                    {
                        Title = "LV Sale Authorization Error",
                        Message = "Unauthorized: invalid token",
                        StatusCode = StatusCodes.Status401Unauthorized
                    };

                    context.Result = new JsonResult(errorResult)
                    {
                        StatusCode = errorResult.StatusCode
                    };
                    return;
                }


                if (token.Role != Model.Users.UserRole.Customer)
                {
                    var errorResult = new ErrorResponse
                    {
                        Title = "LV Sale Authorization Error",
                        Message = "Unauthorized: customers only",
                        StatusCode = StatusCodes.Status401Unauthorized
                    };

                    context.Result = new JsonResult(errorResult)
                    {
                        StatusCode = errorResult.StatusCode
                    };
                }
            }



        }
    }
}

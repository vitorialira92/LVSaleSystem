using LVSaleSystem.API.Data;
using LVSaleSystem.API.DTO;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LVSaleSystem.API.Filters
{
    public class AdminAuthorizationFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _service = context.HttpContext.RequestServices.GetService<TokenService>();

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

                if(token == null)
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
                

                if(token.Role != Model.Users.UserRole.Admin)
                {
                    var errorResult = new ErrorResponse
                    {
                        Title = "LV Sale Authorization Error",
                        Message = "Unauthorized: admins only",
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

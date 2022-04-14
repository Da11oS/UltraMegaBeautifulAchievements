using System;
using Achievements.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Achievements.WebApplication.Utils
{
    /// <summary>
    /// Атрибут авторизации
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute: Attribute, IAuthorizationFilter
    {
        public int Role { get; set; }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else if (Role != 0 && user.Role != (UserRole)Role)
            {
                // didnt matched with set role
                context.Result = new JsonResult(new { message = "Forbidden. No access for this user" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
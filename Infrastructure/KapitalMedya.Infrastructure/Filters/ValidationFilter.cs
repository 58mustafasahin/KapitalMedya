using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace KapitalMedya.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(p => p.Value.Errors.Any())
                    .ToDictionary(error => error.Key, error => error.Value.Errors.Select(p => p.ErrorMessage)).ToArray();
                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}

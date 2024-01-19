using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevFreela.Application.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            IEnumerable<string> messages = context.ModelState
               .SelectMany(e => e.Value.Errors)
               .Select(e => e.ErrorMessage).AsEnumerable();

            context.Result = new BadRequestObjectResult(messages);
        }
       
        await next();
    }
}

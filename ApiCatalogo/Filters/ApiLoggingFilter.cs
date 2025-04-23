using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ApiCatalogo.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Action {ActionName} is executing.", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Action {ActionName} has executed.", context.ActionDescriptor.DisplayName);
        }
    }
}
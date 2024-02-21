using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace LVSaleSystem.API.Filters
{
    public class LoggingAttributeFilter : IActionFilter
    {
        private readonly ILogger _logger; 
        private Stopwatch _stopwatch;

        public LoggingAttributeFilter(ILogger<LoggingAttributeFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var executionTime = _stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} finished | Executed in {executionTime} ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            _logger.LogInformation($"Starting {context.ActionDescriptor.DisplayName}");
        }
    }
}

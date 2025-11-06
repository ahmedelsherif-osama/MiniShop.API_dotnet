using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiniShopAPI.Filters;

public class LogActionFilter : IActionFilter
{
    private Stopwatch _sw = new();
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _sw.Start();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _sw.Stop();
        Console.WriteLine($"{context.ActionDescriptor.DisplayName} took {_sw.Elapsed.Seconds} seconds!");
    }
}
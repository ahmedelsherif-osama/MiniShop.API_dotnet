namespace MiniShopAPI.Middlewares;

class SourceHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public SourceHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var source = context.Request.Headers["X-Source-System"].FirstOrDefault() ?? "Uknown";
        Console.WriteLine($"Integration request from {source}");

        context.Response.Headers.Append("X-Handled-By", "SourceHeaderMiddleware");

        // what is an http context
        await _next(context);
    }
}
using Microsoft.AspNetCore.Http;

namespace ExecutionContext.App;

public class MyService(IHttpContextAccessor accessor)
{
    public bool CheckUser(string username)
    {
        var context = accessor.HttpContext ?? throw new InvalidOperationException("Context Should not be null here");
        return context.Request.Headers["UserName"] == username;
    }
}
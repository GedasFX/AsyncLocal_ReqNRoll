using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace ExecutionContext.App.Tests;

[Binding]
public class UserStartup(Reqnroll.ScenarioContext scenarioContext)
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        var accessor = scenarioContext.Get<IServiceProvider>().GetRequiredService<IHttpContextAccessor>();
        
        // Prepopulate context with some default values.
        accessor.HttpContext = new DefaultHttpContext()
        {
            Request =
            {
                Headers =
                {
                    ["UserId"] = "12345",
                    ["UserName"] = "Alice"
                }
            }
        };
    }
}
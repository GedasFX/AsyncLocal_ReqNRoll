using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace ExecutionContext.App.Tests;

[Binding]
public class Startup(Reqnroll.ScenarioContext scenarioContext)
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        AppServiceProvider.ServiceProvider = new ServiceCollection()
            .AddHttpContextAccessor()
            .AddScoped<MyService>()
            .BuildServiceProvider();
    }

    [BeforeScenario(Order = BeforeTestRunAttribute.DefaultOrder - 1000)]
    public void BeforeScenario()
    {
        var scope = AppServiceProvider.ServiceProvider.CreateScope();
        
        scenarioContext.Set(scope);
        scenarioContext.Set(scope.ServiceProvider);
    }
    
    [AfterScenario(Order = BeforeTestRunAttribute.DefaultOrder + 1000)]
    public void AfterScenario()
    {
        scenarioContext.Get<IServiceScope>().Dispose();
    }
}
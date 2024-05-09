using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace ExecutionContext.App.Tests.Bindings;

[Binding]
public class MainBindings(ScenarioContext scenarioContext)
{
    [When(@"test is run")]
    public void WhenTestIsRun()
    {
        Assert.True(scenarioContext.Get<IServiceProvider>().GetRequiredService<MyService>().CheckUser("Alice"));
    }
}
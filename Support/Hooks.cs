using OpenQA.Selenium;
using ReqnrollSelenium.Drivers;

[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 10)]
namespace ReqnrollSelenium.Support
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _driver;
        readonly IReqnrollOutputHelper _outputHelper;
        readonly ScenarioContext _scenarioContext;

        public Hooks(IReqnrollOutputHelper outputHelper, ScenarioContext scenarioContext)
        {
            _outputHelper = outputHelper;
            _scenarioContext = scenarioContext;

            if (_driver != null)
                _driver = _scenarioContext.Get<IWebDriver>();
        }

        [BeforeScenario]
        public void CreateDriver()
        {
            _driver = DriverFactory.GetDriver();
            _driver.Manage().Window.Maximize();
            _scenarioContext.Set(_driver);
            _outputHelper.WriteLine("Driver inicializado com sucesso.");
        }

        [AfterScenario]
        public void DisposeDriver()
        {
            _driver?.Dispose();
            _outputHelper.WriteLine("Driver encerrado com sucesso.");
        }
    }
}

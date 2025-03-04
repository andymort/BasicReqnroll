using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace BasicReqnroll.Framework
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver? webDriver;

        private const string ChromeMaximizeArgument = "--start-maximized";
        private const string ChromeLanguageArgument = "--lang=en-GB";
        private const string ChromeAgentEnvironmentVariable = "ChromeWebDriver";
        private const string ChromeExeFilename = "chromedriver.exe";

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        private ChromeDriver CreateChromeWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument(ChromeMaximizeArgument);
            options.AddArgument(ChromeLanguageArgument);

            Console.WriteLine("Using Chrome Browser");

            var chromePath = Environment.GetEnvironmentVariable(ChromeAgentEnvironmentVariable);
            if (!string.IsNullOrEmpty(chromePath))
            {
                // if we are running in a Devops hosted agent
                Console.WriteLine($"Chrome path is {options.BinaryLocation}");
                var agentService = ChromeDriverService.CreateDefaultService(chromePath, ChromeExeFilename);
                return new ChromeDriver(agentService, options);
            }

            var service = ChromeDriverService.CreateDefaultService();
            return new ChromeDriver(service, options);
        }

        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        [BeforeScenario()]
        public void BeforeScenario()
        {
            // Create the chrome webdriver
            this.webDriver = CreateChromeWebDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(this.webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (this.webDriver is not null)
            {
                this.webDriver.Close();
                this.webDriver.Quit();
            }
        }
    }
}
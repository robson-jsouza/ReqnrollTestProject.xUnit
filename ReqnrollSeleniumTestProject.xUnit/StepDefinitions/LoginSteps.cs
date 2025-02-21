using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollSeleniumTestProject.xUnit.Helpers;
using Xunit.Sdk;

namespace ReqnrollSeleniumTestProject.xUnit.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private string _scenarioName;
        private ScenarioContext _scenarioContext;

        [BeforeScenario]
        public void SetUp(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            // If you want to run tests in headless mode (without opening the browser), update the ChromeDriver initialization like below:
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);

            // Making this, the browser will be opened
            //_driver = new ChromeDriver(); // Launch Chrome

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _scenarioName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://localhost:7075/");
        }

        [When(@"I enter a valid username and password")]
        public void WhenIEnterValidCredentials()
        {
            _driver.FindElement(By.Id("username")).SendKeys("admin");
            _driver.FindElement(By.Id("password")).SendKeys("password");
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _driver.FindElement(By.Id("loginBtn")).Click();
        }

        [Then(@"I should be redirected to the home screen")]
        public void ThenIShouldBeRedirectedToTheHomeScreen()
        {
            try
            {
                Assert.Contains("/Home/Index", _driver.Url);
            }
            catch (XunitException)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, _scenarioName);
                throw; // Re-throw to ensure test fails
            }
        }

        [AfterScenario]
        public void TearDown()
        {
            if (_scenarioContext.TestError != null)
            {
                string screenshotPath = ScreenshotHelper.CaptureScreenshot(_driver, _scenarioName);
                // If you're using Reqnroll's reports(e.g., SpecFlow+LivingDoc), you can attach the screenshot to the test results,
                // by doing this:
                _scenarioContext["ScreenshotPath"] = screenshotPath;
            }
            _driver.Quit(); // Close browser
        }
    }
}

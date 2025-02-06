using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;





namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class hooks1 : Utility
    {
        private static IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public hooks1(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ReportHelper.InitializeReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ReportHelper.FlushReport();
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenarioWithTag()
        {
            

                string browserType = Baseclass.Configuration["Browser"];
                switch (browserType)
                {
                    case "Chrome":
                        driver = new ChromeDriver();
                        break;
                    case "Edge":
                        string edgeDriverPath = "C:\\Users\\HariniGandhi\\Downloads\\edgedriver_win64";
                        driver = new EdgeDriver(edgeDriverPath);
                        break;
                }
            
           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            _scenarioContext.Set(driver, "WebDriver");
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepInfo = ScenarioContext.Current.StepContext.StepInfo.Text;

            if (ScenarioContext.Current.TestError == null)
            {
                ReportHelper.test.Log(AventStack.ExtentReports.Status.Pass, $"{stepType} Step Passed: {stepInfo}");
            }
            else
            {
                ReportHelper.test.Log(AventStack.ExtentReports.Status.Fail, $"{stepType} Step Failed: {stepInfo}");
                ReportHelper.test.Log(AventStack.ExtentReports.Status.Fail, ScenarioContext.Current.TestError.Message);
                var screenshotPath = ReportHelper.CaptureScreenshot(driver);
                ReportHelper.test.AddScreenCaptureFromPath(screenshotPath);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();

        }
    }
}
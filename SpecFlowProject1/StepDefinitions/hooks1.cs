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




namespace SpecFlowProject1.StepDefinitions { 
[Binding]
public class hooks1 : Utility
{
    public static IWebDriver driver;
    public Home_page home_Page;
    public LoginPage loginobject;




    private  readonly ScenarioContext _scenarioContext;

        public hooks1(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenarioWithTag()
        {
            String BrowserType = Baseclass.Configuration["Browser"];
            switch (BrowserType) {
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



        [AfterScenario]
        public void AfterScenario()
        {

            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();

        }

        




    }
}

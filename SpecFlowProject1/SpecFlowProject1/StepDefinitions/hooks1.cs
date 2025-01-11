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
    public  class hooks1 : Utility
    {
        public IWebDriver driver;
        public Home_page home_Page;
        public LoginPage loginobject;




        [BeforeFeature(Order =1)]
        public  void GivenLaunchTheBrowser()
        {
            String BrowserType = Baseclass.Configuration["Browser"];


            switch (BrowserType)
            {
                case "Chrome":

                    driver = new ChromeDriver();
                    implicitwait(driver);
                    break;

                case "Edge":
                    string edgeDriverPath = "C:\\Users\\HariniGandhi\\Downloads\\edgedriver_win64";
                    driver = new EdgeDriver(edgeDriverPath);
                    implicitwait(driver);
                    break;

            }


        }
        [BeforeFeature(Order = 2)]

        public  void LogintoHirstPortal()
        {
            home_Page = new Home_page(driver);
            home_Page.navigatetourl();
            loginobject = new LoginPage(driver);
            loginobject.login();
            ExplicitWaitUntilPagegetsloaded(driver);

            

        }
        
        public static IWebDriver searchobject()
        {
            return driver;
        }


    }
}

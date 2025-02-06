using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace SpecFlowProject1.Pages
{
    public class Home_page:Utility
    {

        [FindsBy(How = How.XPath, Using = "//p[text()='Jobseeker Login']")]
        public IWebElement Jobseekarlink;
        [FindsBy(How = How.XPath, Using = "//span[text()='Sign In']")]
        public  IWebElement SigninLink;
        IWebDriver driver;
       
        public Home_page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
       
        public LoginPage navigatetourl()
        {
            driver.Navigate().GoToUrl(Baseclass.Configuration["HomepageURL"]);
            driver.Manage().Window.Maximize();
            Jobseekarlink.Click();
            SigninLink.Click();
            ExplicitWaitUntilPagegetsloaded(driver);
            return new LoginPage(driver);
        }

        
    }
}

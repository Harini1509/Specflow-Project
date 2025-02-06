using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.DOM;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;


namespace SpecFlowProject1.Pages
{
    public class Utility
    {
        public void implicitwait(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }
        public void switchtowindow(IWebDriver driver)
        {

            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
        public void ExplicitWaitUntilPagegetsloaded(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(driver =>
            {
                string readyState = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString();
                return readyState.Equals("complete"); 
            });

        }
        public void action(IWebDriver driver,IWebElement submit)
        {
            Actions ac = new Actions(driver);
            ac.Click(submit).Build().Perform();
        }

        public void WaituntilElementAppears(IWebDriver driver,IWebElement Apply)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => Apply.Displayed);
        }
    }
}

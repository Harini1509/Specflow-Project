using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public  class Confirmationpage : Utility
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='no-jobs-title']//following-sibling::div")]
        public IWebElement confirm;

        public Confirmationpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public Boolean confirmation()
        {
            //Thread.Sleep(3000);
            //string elementText = (string)js.ExecuteScript("return document.getElementsByClassName('job-closed')[0].innerText;");
            ExplicitWaitUntilPagegetsloaded(driver);

            Console.WriteLine(confirm.Text);
            if ((confirm.Text).Contains("You have successfully applied "))
            {
                return true;
            }
            return false;
        }
    }
}

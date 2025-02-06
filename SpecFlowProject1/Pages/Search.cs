using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Reflection.Metadata;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;



namespace SpecFlowProject1.Pages
{
    public class Search : Utility
    {
        IWebDriver driver;
        Boolean flag = false;
        IJavaScriptExecutor js;


        String title;
        [FindsBy(How = How.XPath, Using = "//div[@class='categories ']/child::div[position()=3]")]
        public IWebElement searchlink;
        [FindsBy(How = How.XPath, Using = "//input[@class='sc-cQFLBn cQDyth']")]
        public IWebElement jobname;
        [FindsBy(How = How.XPath, Using = "//div[@class='filters experience']")]
        public IWebElement dropdown;
        [FindsBy(How = How.XPath, Using = "//div[@class='filters experience']/child::div[2]/child::ul/child::li")]
        public IList<IWebElement> exprange;
        [FindsBy(How = How.XPath, Using = "//form[@class='search-wrapper']/child::button")]
        public IWebElement submit;
        [FindsBy(How = How.XPath, Using = "//div[@class='job-apply-checkbox']/child::input")]
        public IList<IWebElement> checkbox;
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Apply All']")]
        public IWebElement Apply;
        [FindsBy(How = How.XPath, Using = "//button[text()='Apply']")]
        public IWebElement ApplyAll;
        [FindsBy(How = How.XPath, Using = "//div[@class='no-jobs-title']//following-sibling::div")]
        public IWebElement confirm;

        public Search(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        public void Navigatetosearchpage()
        {

            searchlink.Click();

        }

        public void Enterpreference(String job)
        {


            jobname.SendKeys(job);
            dropdown.Click();
            foreach (IWebElement element in exprange)
            {
                String Experience = element.Text;
                if (Experience.Equals(Baseclass.Configuration["Experience"]))
                {
                    element.Click();
                    break;

                }

            }

            action(driver, submit);
            WaituntilElementAppears(driver, ApplyAll);

            //Actions ac = new Actions(driver);
            //ac.Click(submit).Build().Perform();

            // Thread.Sleep(2000);


        }
     public void Selectapplicablejobs()
        {

            foreach (IWebElement job in checkbox)
            {

                if (job.Enabled == true)
                {
                    flag = true;
                    string id = job.GetAttribute("id");
                    js = (IJavaScriptExecutor)driver;
                   js.ExecuteScript("arguments[0].scrollIntoView();", job);
                    string script = $"document.getElementById('{id}').click();";
                    js.ExecuteScript(script);
                    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                }
          }

      }
        public Boolean Applyforjobs()
        {
            if (flag == true)
            {
                Apply.Click();
                switchtowindow(driver);
                ExplicitWaitUntilPagegetsloaded(driver);

                //Thread.Sleep(3000);
         }

            return flag;
       }

  }
}

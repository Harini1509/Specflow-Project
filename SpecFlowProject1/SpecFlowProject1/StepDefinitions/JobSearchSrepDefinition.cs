using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Pages;
using System;
using System.Configuration;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;

using System.IO;
using Microsoft.Extensions.Configuration.Json;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;


namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class JobSearchSrepDefinition:Utility
    {
        public IWebDriver driver;
        public Search Osearch;
       // Home_page home_Page;
        Confirmationpage Oconfirm;
        Boolean result;

        //[Given(@"Launch the browser")]
        //public void GivenLaunchTheBrowser()
        //{
        //    String BrowserType = Baseclass.Configuration["Browser"];
           

        //    switch (BrowserType)
        //    {
        //        case "Chrome":
                    
        //                driver = new ChromeDriver();
        //            implicitwait(driver);
        //                break;
                    
        //        case "Edge":
        //            string edgeDriverPath = "C:\\Users\\HariniGandhi\\Downloads\\edgedriver_win64";
        //            driver = new EdgeDriver(edgeDriverPath);
        //            implicitwait(driver);
        //            break;

        //    }
            

        //}
        



        //[Given(@"User in the Hirist Home Page")]
        //public void GivenUserInTheHiristHomePage()
        //{
        //    home_Page = new Home_page(driver);
        //    Osearch = home_Page.navigatetourl();
        //}


  

       
        //[When(@"User Clicks on Advanced Search Link")]
        //public void WhenUserClicksOnAdvancedSearchLink()
        //{
        //    Osearch.Navigatetosearchpage();
        //}
        [Given(@"User in the Hirst Job Seach Page")]
        public void GivenUserInTheHirstJobSeachPage()
        {
            driver = hooks1.searchobject();
            Osearch = new Search(driver);
            Osearch.Navigatetosearchpage();
        }


        [Then(@"User should see search preferences")]
        public void ThenUserShouldSeeSearchPreferences()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='heading']")).Text.Equals("Search for Jobs, Companies, Courses"));
        }
        [When(@"User enters ""([^""]*)"" and click search")]
        public void WhenUserEntersAndClickSearch(string jobPreference)
        {
            
            Osearch.Enterpreference(jobPreference);
        }



        
        [Then(@"applicable jobs should display")]
        public void ThenApplicableJobsShouldDisplay()
        {
           
            Assert.IsTrue(Osearch.checkbox.Count > 0);
        }
        [When(@"user select all jobs")]
        public void WhenUserSelectAllJobs()
        {
            Osearch.Selectapplicablejobs();
        }
        [When(@"click on Apply")]
        public void WhenClickOnApply()
        {
            result= Osearch.Applyforjobs();
        }
        [Then(@"Jobs should be applied successfully")]

        public void ThenJobsShouldBeAppliedSuccessfully()
        {
            if (result == true)
            {
                Oconfirm=new Confirmationpage(driver);
                Assert.IsTrue(Oconfirm.confirmation());
            }
            else
            {
                Console.WriteLine("No recent jobs");

            }
            driver.Close();
        }


        [AfterScenario]
        public void AfterScenario()
        {

            driver.Close();
        }




    }
}

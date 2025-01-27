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
        public Home_page home_Page;
        public LoginPage loginobject;
        private readonly ScenarioContext _scenarioContext;


        public JobSearchSrepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"Launch the browser")]
        public void GivenLaunchTheBrowser()
        {
            driver = _scenarioContext.Get<IWebDriver>("WebDriver");
        }




        [Given(@"User in the Hirist Home Page")]
        public void GivenUserInTheHiristHomePage()
        {
            home_Page = new Home_page(driver);
             home_Page.navigatetourl();
        }





        //[When(@"User Clicks on Advanced Search Link")]
        //public void WhenUserClicksOnAdvancedSearchLink()
        //{
        //    Osearch.Navigatetosearchpage();
        //}
        [Given(@"User in the Hirst Job Search Page")]
        public void GivenUserInTheHirstJobSeachPage()
        {
            

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
           

        }


        




    }
}

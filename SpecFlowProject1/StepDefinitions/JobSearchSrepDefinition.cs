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
    public class JobSearchSrepDefinition : Utility
    {
        public IWebDriver driver;
        public Search searchobject;
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
            loginobject = home_Page.navigatetourl();
            searchobject = loginobject.login();
        }
        [When(@"User Clicks on Job Search")]
        public void WhenUserClicksOnJobSearch()
        {
            searchobject.Navigatetosearchpage();
        }   

       [Then(@"User should see search preferences")]
        public void ThenUserShouldSeeSearchPreferences()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='heading']")).Text.Equals("Search for Jobs, Companies, Courses"));
        }
        [When(@"User enters ""([^""]*)"" and click search")]
        public void WhenUserEntersAndClickSearch(string jobPreference)
        {

            searchobject.Enterpreference(jobPreference);

        }

        [Then(@"applicable jobs should display")]
        public void ThenApplicableJobsShouldDisplay()
        {

            Assert.IsTrue(searchobject.checkbox.Count > 0);
        }
        [When(@"user select all jobs")]
        public void WhenUserSelectAllJobs()
        {
            searchobject.Selectapplicablejobs();
        }
        [When(@"click on Apply")]
        public void WhenClickOnApply()
        {
            result = searchobject.Applyforjobs();
        }
        [Then(@"Jobs should be applied successfully")]

        public void ThenJobsShouldBeAppliedSuccessfully()
        {
            if (result == true)
            {
                Oconfirm = new Confirmationpage(driver);
                Assert.IsTrue(Oconfirm.confirmation());
            }
            else
            {
                Console.WriteLine("No recent jobs");

            }


        }

    }
}

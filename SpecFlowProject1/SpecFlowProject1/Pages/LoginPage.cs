using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SeleniumExtras.PageObjects;

namespace SpecFlowProject1.Pages
{
    public class LoginPage :Utility
    {

        [FindsBy(How = How.XPath, Using = "//input[@id='login-email-input']")]
        public IWebElement Emailid;
        [FindsBy(How = How.XPath, Using = "//input[@id='loginPassword']")]
        public IWebElement Password;
        [FindsBy(How = How.XPath, Using = "//button[@id='loginSubmit']")]
        public IWebElement Login;
        IWebDriver driver;
       
        public LoginPage(IWebDriver driver)
        {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
        
        }
        public void login()
        {
        Emailid.SendKeys(Baseclass.Configuration["Username"]);
        Password.SendKeys(Baseclass.Configuration["Password"]);
        Login.Click();
           ExplicitWaitUntilPagegetsloaded(driver);




        }



        












    }
}



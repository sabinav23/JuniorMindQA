using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Refit;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace PlanITpoker.Specs
{
    [Binding]
    public class PlanITpokerSteps
    {
        private IWebDriver driver;
        private HomePage home;
        private LoginPage login;
        private string _errorMessage;
        private object _loginResponse;

        public PlanITpokerSteps()
        {
            this.driver = new ChromeDriver();
            this.home = new HomePage(driver);
            driver.Navigate().GoToUrl("https://www.planitpoker.com/");
            this.login = home.ClickLogin();
        }

        [Given(@"the first input is ""(.*)""")]
        public void GivenTheFirstInputIs(string username)
        {
            login.Username = username;
        }
        
        [Given(@"the second input is ""(.*)""")]
        public void GivenTheSecondInputIs(string password)
        {
            login.Password = password;
        }
        
        [When(@"clicking the login button")]
        public void WhenTheClickingTheLoginButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            login.InputUserName(login.Username);
            login.InputPassword(login.Password);
            login.GetLoginBtn().Click();
            _errorMessage = login.GetErrorMessage();
        }
        
        [Then(@"the title of the current page should be ""(.*)""")]
        public void ThenTheTitleOfTheCurrentPageShouldBe(string title)
        {
            driver.Title.Equals(title);
            
        }

    }
}

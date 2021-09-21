using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanITpoker
{
    public class LoginPage
    {
        IWebDriver driver;

        private By emailInput = By.CssSelector("input[type='email']");
        private By passwordInput = By.CssSelector("input[type='password']");
        private By loginBtn = By.ClassName("btn-login");
        private By errorMessage = By.ClassName("alert-danger");

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetEmailInput()
        {
            return driver.FindElement(emailInput);
        }

        public IWebElement GetPasswordInput()
        {
            return driver.FindElement(passwordInput);
        }

        public IWebElement GetLoginBtn()
        {
            return driver.FindElement(loginBtn);
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessage).Text;
        }

        public void InputUserName(string username)
        {
            this.GetEmailInput().SendKeys(username);
        }
        public void InputPassword(string username)
        {
            this.GetPasswordInput().SendKeys(username);
        }


        public CreateNewRoomPopup ClickLogin()
        {
            return new CreateNewRoomPopup(driver);
        }
        
    }
}

using System;
using System.Threading;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace DukeTransmission.UITests.Pages
{
    public class LoginPage : PageBase
    {
        private const string PartialUrl = "Login/UserLogin.aspx?";

        public LoginPage(RemoteWebDriver driver) : base(driver){}

        public static LoginPage NavigateToThisPageViaUrl(RemoteWebDriver driver)
        {
            driver.Navigate().GoToUrl(_baseWebsiteUrl + PartialUrl);
            return new LoginPage(driver);
        }

        public HomePage LogIn(string username, string password)
        {
            _loginField.Clear();
            _loginField.SendKeys(username);
            var passwordField = _driver.FindElementWait(By.Id("password"));
            passwordField.Clear();
            passwordField.SendKeys(password);
            _loginButton.Click();
            return new HomePage(_driver);
        }

        public IWebElement _loginField => _driver.FindElementById("username");
        public IWebElement _passwordField => _driver.FindElementById("password");
        public IWebElement _loginButton => _driver.FindElementById("btnSubmit");


#pragma warning disable 649
        /*  [FindsBy(How = How.Id, Using = "username")]
          private IWebElement _loginField;

          [FindsBy(How = How.Id, Using = "password")]
          private IWebElement _passwordField;

          [FindsBy(How = How.Id, Using = "btnSubmit")]
          private IWebElement _loginButton; */
#pragma warning restore 649
    }
}

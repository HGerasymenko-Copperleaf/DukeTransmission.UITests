using System;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.Pages.Components.AlternativeValuePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace DukeTransmission.UITests.Pages
{
    public class AlternativeValuePage : PageBase
    {
        public AlternativeValuePage(RemoteWebDriver driver) : base(driver)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(d => _driver.FindElementById("busyIndicator").GetAttribute("class").Contains("hide"));
        }

        public IWebElement _valueModelsTab => _driver.FindElementById("valueModelsTab");
        
        public static AlternativeValuePage NavigateToThisPageViaUrl(RemoteWebDriver driver, string partialUrl)
        {
            driver.Navigate().GoToUrl(_baseWebsiteUrl + partialUrl + "valueModelsTab");
            return new AlternativeValuePage(driver);
        }

        public ValueModelsTab OpenValueModelTab()
        {
            _valueModelsTab.Click();
            return new ValueModelsTab(_driver);
        }

        public QuestionnairesTab OpenQuestionnairesTab(string partialUrl)
        {
            _driver.Navigate().GoToUrl(_baseWebsiteUrl + partialUrl + "questionnairesTab");
            return new QuestionnairesTab(_driver);
        }

   }
}

using System;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace DukeTransmission.UITests.Pages.Components
{
    public class AnswerQuestionnairesDialog : PageBase
    {
        public AnswerQuestionnairesDialog(RemoteWebDriver driver) : base(driver)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            wait.Until(d => IsDisplayed);
        }

        private bool IsDisplayed => _driver.IsElementVisible(By.XPath("//div[@class='k-widget k-window']"));

#pragma warning disable 649
        [FindsBy(How = How.Id, Using = "baselineQuestionnaireTab")]
        private IWebElement _baselineTab;

        [FindsBy(How = How.Id, Using = "impactQuestionnaireTab")]
        private IWebElement _outcomeTab;

        [FindsBy(How = How.XPath, Using = "//a[@aria-label='Close']")]
        private IWebElement _closeButton; 

#pragma warning restore 649
    }
}
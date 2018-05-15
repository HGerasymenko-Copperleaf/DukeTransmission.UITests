using System;
using System.Configuration;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PageFactory = SeleniumExtras.PageObjects.PageFactory;

namespace DukeTransmission.UITests.Bases
{
    /// <summary>
    /// Base Page to define functionality shared by all pages,
    /// e.g., initialize elements on the page 
    /// </summary>
    public abstract class PageBase
    {
        protected readonly RemoteWebDriver _driver;
        protected readonly WebDriverWait _wait;
        protected static readonly Uri _baseWebsiteUrl = new Uri(ConfigurationManager.AppSettings["baseWebsiteUrl"]);

        protected PageBase(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
    }
}

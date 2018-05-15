using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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
        protected static readonly Uri _baseWebsiteUrl = new Uri(ConfigurationManager.AppSettings["copperleafWebsiteUrl"]);

        protected PageBase(RemoteWebDriver driver)
        {
            _driver = driver;
            //PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
    }
}

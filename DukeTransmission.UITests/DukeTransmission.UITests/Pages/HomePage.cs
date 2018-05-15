using DukeTransmission.UITests.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace DukeTransmission.UITests.Pages
{
    public class HomePage : PageBase
    {
        public HomePage(RemoteWebDriver driver) : base(driver) { }
    }
}

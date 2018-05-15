using System;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace DukeTransmission.UITests.Pages.Components.AlternativeValuePage
{
    public class QuestionnairesTab : PageBase
    {
        public QuestionnairesTab(RemoteWebDriver driver) : base(driver)
        {
            WaitForComponentToLoad();
        }

        public void WaitForComponentToLoad()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(d => _driver.FindElementById("busyIndicator").GetAttribute("class").Contains("hide"));
        }

        public bool IsDisplayed => _driver.IsElementVisible(By.XPath("//span[@title='Questionnaires']"));

        public void SelectValueModel(ValueModels valueModel)
        {
            IWebElement element;
            switch (valueModel)
            {
                case ValueModels.FinancialRisk:
                    element = _financialRiskModel;
                    break;
                case ValueModels.FinancialImpact:
                    element = _financialImpactModel;
                    break;
                case ValueModels.CyberSecurityRisk:
                    element = _cyberSecurityRiskModel;
                    break;
                case ValueModels.ElectricReliabilityRisk:
                    element = _electricReliabilityRiskModel;
                    break;
                case ValueModels.EmployeeProductivityImpact:
                    element = _employeeProductityImpactModel;
                    break;
                case ValueModels.ComplianceRisk:
                    element = _complianceRiskModel;
                    break;
                case ValueModels.EnvironmentalRisk:
                    element = _environmentalRiskModel;
                    break;
                case ValueModels.PublicPropertyRisk:
                    element = _publicPropertyRiskModel;
                    break;
                case ValueModels.IndustrialSafetyRisk:
                    element = _industrialSafetyRiskModel;
                    break;
                case ValueModels.TransmissionStationEquipmentRisk:
                    element = _transmissionStationEquipmentRisk;
                    break;
                case ValueModels.TransmissionReliabilityRisk:
                    element = _transmissionReliabilityRisk;
                    break;
                case ValueModels.TransmissionLineRisk:
                    element = _transmissionLineRisk;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(valueModel), valueModel, null);
            }
            element.Click();
            WaitForComponentToLoad();
        }

        public AnswerQuestionnairesDialog OpenAnswerQuestionnairesDialog()
        {
            return new AnswerQuestionnairesDialog(_driver);
        }

        public void SelectValueSummaryTab()
        {
            _valueSummaryTab.Click();
        }

        public ValueDetailsGrid SelectValueDetailsTab()
        {
            _valueMeasureDetailsTab.Click();
            return new ValueDetailsGrid(_driver);
        }

        //value models on Questionnaires tab
        private IWebElement _cyberSecurityRiskModel => _driver.FindElementByXPath("//span[text()='Cyber Security Risk']");
        private IWebElement _financialRiskModel => _driver.FindElementWait(By.XPath("//span[text()='Financial Risk']"));
        private IWebElement _financialImpactModel => _driver.FindElementWait(By.XPath("//span[text()='Financial Impact']"));
        private IWebElement _electricReliabilityRiskModel => _driver.FindElementWait(By.XPath("//span[text()='Electric Reliability Risk']"));
        private IWebElement _employeeProductityImpactModel => _driver.FindElementWait(By.XPath("//span[text()='Employee Productivity Impact']"));
        private IWebElement _complianceRiskModel => _driver.FindElementWait(By.XPath("//span[text()='Compliance Risk']"));
        private IWebElement _environmentalRiskModel => _driver.FindElementWait(By.XPath("//span[text()='Environmental Risk']"));
        private IWebElement _publicPropertyRiskModel => _driver.FindElementWait(By.XPath("//span[text()='Public Property Risk']"));
        private IWebElement _industrialSafetyRiskModel => _driver.FindElementWait(By.XPath("//span[text()='Industrial / Personnel Safety Risk']"));
        private IWebElement _transmissionStationEquipmentRisk => _driver.FindElementWait(By.XPath("//span[text()='Transmission Station Equipment Risk']"));
        private IWebElement _transmissionReliabilityRisk => _driver.FindElementWait(By.XPath("//span[text()='Transmission Reliability Risk']"));
        private IWebElement _transmissionLineRisk => _driver.FindElementWait(By.XPath("//span[text()='Transmission Line Risk']"));

        //child grids
        private IWebElement _valueSummaryTab => _driver.FindElementById("valueSummaryTab");
        private IWebElement _valueMeasureDetailsTab => _driver.FindElementById("valueMeasureDetailsTab");

    }
}

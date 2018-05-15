using System;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DukeTransmission.UITests.Pages.Components.AlternativeValuePage
{
    public class ValueDetailsGrid : PageBase
    {
        public ValueDetailsGrid(RemoteWebDriver driver): base(driver) { }

        public void SelectValueMeasure(ValueMeasures valueMeasure)
        {
            switch (valueMeasure)
            {
                case ValueMeasures.FinancialRisk:
                    _financialRiskValueMeasure.Click();
                    break;
                case ValueMeasures.FinancialRiskForTransmissionStation:
                    _financialRiskForTransStationValueMeasure.Click();
                    break;
                case ValueMeasures.FinancialImpactCapital:
                    _financialImpactCapitalValueMeasure.Click();
                    break;
                case ValueMeasures.ElectricReliabilityRisk:
                    _electricReliabilityRiskValueMeasure.Click();
                    break;
                case ValueMeasures.EmployeeProductivityImpact:
                    _employeeProductityImpactValueMeasure.Click();
                    break;
                case ValueMeasures.ComplianceRisk:
                    _complianceRiskValueMeasure.Click();
                    break;
                case ValueMeasures.PublicPropertyRisk:
                    _publicPropertyRiskValueMeasure.Click();
                    break;
                case ValueMeasures.IndustrialSafetyRisk:
                    _industrialSafetyRiskValueMeasure.Click();
                    break;
                case ValueMeasures.TransmissionReliabilityRisk:
                    _transmissionReliabilityRisk.Click();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(valueMeasure), valueMeasure, null);
            }
        }

        public InspectBreakdownDialog OpenInspectBreakdownDialog()
        {
            _inspectBreakdownButton.Click();
            return new InspectBreakdownDialog(_driver);
        }

        // value measures
        private IWebElement _financialRiskValueMeasure => _driver.FindElementWait(By.XPath("//span[@class='cl-enum-label-measurecategory-risk']"));
        private IWebElement _financialRiskForTransStationValueMeasure => _driver.FindElementWait(By.XPath("(//span[@class='cl-enum-label-measurecategory-risk'])[2]"));
        private IWebElement _financialImpactCapitalValueMeasure => _driver.FindElementWait(By.XPath("//span[@class='cl-enum-label-measurecategory-benefit' and contains(., 'Capital')]"));
        private IWebElement _electricReliabilityRiskValueMeasure => _driver.FindElementWait(By.XPath("//span[@class='cl-enum-label-measurecategory-benefit']"));
        private IWebElement _employeeProductityImpactValueMeasure => _driver.FindElementWait(By.XPath("//div[@class='cl-resizable-grid-container']//span[@class='cl-enum-label-measurecategory-benefit']"));
        private IWebElement _complianceRiskValueMeasure => _driver.FindElementWait(By.XPath("//span[@class='cl-enum-label-measurecategory-risk']"));
        private IWebElement _publicPropertyRiskValueMeasure => _driver.FindElementWait(By.XPath("//span[@class='cl-enum-label-measurecategory-risk']"));
        private IWebElement _industrialSafetyRiskValueMeasure => _driver.FindElementWait(By.XPath("//span[@class='cl-enum-label-measurecategory-risk']"));
        private IWebElement _transmissionReliabilityRisk => _driver.FindElementWait(By.XPath("//span[@class='cl-enum-label-measurecategory-risk' and contains(., 'Transmission Reliability Risk')]"));

        //toolbar buttons
        private IWebElement _inspectBreakdownButton => _driver.FindElementWait(By.XPath("//div[@class='cl-resizable-grid-toolbar-container-with-title cl-container']//a[@title='Inspect Breakdown']"));
        
    }
}

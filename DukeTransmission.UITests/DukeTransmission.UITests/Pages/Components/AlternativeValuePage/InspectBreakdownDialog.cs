using System;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace DukeTransmission.UITests.Pages.Components.AlternativeValuePage
{
    public class InspectBreakdownDialog : PageBase
    {
        public InspectBreakdownDialog(RemoteWebDriver driver) : base(driver)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => _driver.FindElement(By.XPath("//div[@class='k-widget k-window']")) != null);
        }

        public string BaselineResult => _driver.FindElementText(By.XPath("(//table[@class='k-selectable']//div[@class='cl-colored-cell'])[1]" +
                                                                          "/following-sibling::div"));
        public string FinancialImpactOutcome => _driver.FindElementText(By.XPath("(//div[@class='cl-breakdown-grid-container k-pane']//td[@class='cl-numeric-col'])[1]"));
        public string EmpProductivityImpactOutcome => _driver.FindElementText(By.XPath("//div[@class='k-grid-content k-auto-scrollable']//tr[2]/td[@class='cl-numeric-col'][1]"));
        public string ComplianceRiskBaselineResult => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//td[1]/div)[2]"));

        public string ElectReliabilityRiskBaselineResult => _driver.FindElementText(By.XPath("(//div[@class='cl-breakdown-grid-container k-pane']//td[@class='cl-numeric-col'])[1]"));
        public string IndustrialSafetyRiskBaselineResult => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//td[@class='cl-numeric-col'][1]/div)[2]"));
        public string TransReliabilityRiskBaselineResult => _driver.FindElementText(By.XPath("(//div[@class='cl-breakdown-grid-container k-pane']//td[@class='cl-numeric-col']//div)[2]"));
        public string FinancialRiskConsequenceValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[@class='k-alt'][1]//div)[3]"));

        public string FinancialRiskLikelihoodValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[@class='k-alt'][1]" +
                                                                                       "//following-sibling::tr//div)[2]"));
        public string TransStationModel_FinRiskConsequenceValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[@class='k-alt']//div)[2]"));
        public string FinancialImpactCapitalConsequenceValue => _driver.FindElementText(By.XPath("(//div[@class='cl-breakdown-grid-container k-pane']//tr[@class='k-alt'])[2]//td[1]"));
        public string FinancialImpactCapitalLikelihoodValue => _driver.FindElementText(By.XPath("(//div[@class='cl-breakdown-grid-container k-pane']" +
                                                                                                "//div[@class='k-grid-content k-auto-scrollable']//tr)[3]//td[1]"));
        public string ElectReliabilityRiskConsequenceValue => _driver.FindElementText(By.XPath("//div[@class='cl-breakdown-grid-container k-pane']" +
                                                                                               "//div[@class='k-grid-content k-auto-scrollable']//tr[2]/td[1]"));
        public string ElectReliabilityRiskLikelihoodValue => _driver.FindElementText(By.XPath("//div[@class='k-grid-content k-auto-scrollable']//tr[3]/td[1]"));
        public string EmpProductivityImpactConsequenceValue => _driver.FindElementText(By.XPath("//div[@class='k-grid-content k-auto-scrollable']//tr[2]//td[@class='cl-numeric-col'][1]"));
        public string EmpProductivityImpactLikelihoodValue => _driver.FindElementText(By.XPath("//div[@class='k-grid-content k-auto-scrollable']//tr[3]/td[1]"));
        public string ComplianceRiskConsequenceValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[@class='k-alt']//td[@class='cl-numeric-col'][1]//div)[2]"));
        public string ComplianceRiskLikelihoodValue => _driver.FindElementText(By.XPath("//div[@class='k-grid-content k-auto-scrollable']//tr[3]/td[1]/div[2]"));
        public string PublicPropertyRiskConsequenceValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[@class='k-alt']//div)[2]"));
        public string PublicPropertyRiskLikelihoodValue => _driver.FindElementText(By.XPath("//div[@class='k-grid-content k-auto-scrollable']//tr[3]/td[1]/div[2]"));
        public string IndustrialSafetyRiskConsequenceValue => _driver.FindElementText(By.XPath("(//div[@class='cl-breakdown-grid-container k-pane']//td[@class='cl-numeric-col'][1]/div)[4]"));
        public string IndustrialSafetyRiskLikelihoodValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[3]//div)[2]"));
        public string TransmissionReliabilityRiskConsequenceValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[@class='k-alt'][1]//div)[2]"));
        public string TransmissionReliabilityRiskLikelihoodValue => _driver.FindElementText(By.XPath("(//div[@class='k-grid-content k-auto-scrollable']//tr[3]//div)[2]"));
    }
}

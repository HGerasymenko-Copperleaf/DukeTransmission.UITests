using System;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.Pages;
using DukeTransmission.UITests.Pages.Components.AlternativeValuePage;
using DukeTransmission.UITests.TestData;
using NUnit.Framework;

namespace DukeTransmission.UITests.Tests
{
    public class TransmissionStationEquipmentRiskModelTests : TestBase
    {
        protected HomePage _homePage;
        private const string _partialUrl =
            "Pages/AlternativeValue/Views/AlternativeValue.aspx?id=6089&altid=4933&tabId=";

        protected AlternativeValuePage _alternativeValuePage;
        private ValueDetailsGrid _valueDetailsTab;

        public override void BeforeAll()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            var loginPage = LoginPage.NavigateToThisPageViaUrl(_driver);
            _homePage = loginPage.LogIn(LoginData.CopperleafAccount.Email, LoginData.CopperleafAccount.Password);
        }

        public override void BeforeEach()
        {
            if (_driver.Url != _baseWebsiteUrl + _partialUrl)
            {
                _alternativeValuePage = AlternativeValuePage.NavigateToThisPageViaUrl(_driver, _partialUrl);
            }

            //open Alternative Value > Questionnaires Tab
            var questionnairesTab = _alternativeValuePage.OpenQuestionnairesTab(_partialUrl);
            
            //select Transmission Station Equipment Risk value model
            questionnairesTab.SelectValueModel(ValueModels.TransmissionStationEquipmentRisk);
            _valueDetailsTab = questionnairesTab.SelectValueDetailsTab();
        }


        [Test]
        public void FinancialRiskMeasure_CheckBaselineResult()
        {
            // open Breakdown dialog for Financial Risk value measure
            _valueDetailsTab.SelectValueMeasure(ValueMeasures.FinancialRiskForTransmissionStation);
            var inspectBreakdownDialog = _valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate value unit result
            var consequence = decimal.Parse(inspectBreakdownDialog.TransStationModel_FinRiskConsequenceValue);
            var likelihood = decimal.Parse(inspectBreakdownDialog.FinancialRiskLikelihoodValue);
            var expected = Math.Round((consequence * likelihood), 1);
            var actual = Math.Round(decimal.Parse(inspectBreakdownDialog.BaselineResult), 1);

            Assert.AreEqual(expected, actual,
                $"Expected Value Units Result should be {expected}, but it was {actual}.");
        }

        [Test]
        public void TransmissionReliabilityRiskMeasure_CheckBaselineResult()
        {
            // open Breakdown dialog for Transmission Reliability Risk value measure
            _valueDetailsTab.SelectValueMeasure(ValueMeasures.TransmissionReliabilityRisk);
            var inspectBreakdownDialog = _valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate value unit result
            var consequence = decimal.Parse(inspectBreakdownDialog.TransStationModel_FinRiskConsequenceValue);
            var likelihood = decimal.Parse(inspectBreakdownDialog.FinancialRiskLikelihoodValue);
            var expected = Math.Round((consequence * likelihood), 1);
            var actual = Math.Round(decimal.Parse(inspectBreakdownDialog.BaselineResult), 1);

            Assert.AreEqual(expected, actual,
                $"Expected Value Units Result should be {expected}, but it was {actual}.");
        }

        [Test]
        public void IndustrialPersonalSafetyRiskMeasure_CheckBaselineResult()
        {
            // open Breakdown dialog for Transmission Reliability Risk value measure
            _valueDetailsTab.SelectValueMeasure(ValueMeasures.IndustrialSafetyRisk);
            var inspectBreakdownDialog = _valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate value unit result
            var consequence = decimal.Parse(inspectBreakdownDialog.IndustrialSafetyRiskConsequenceValue);
            var likelihood = decimal.Parse(inspectBreakdownDialog.IndustrialSafetyRiskLikelihoodValue);
            var expected = Math.Round((consequence * likelihood), 1);
            var actual = Math.Round(decimal.Parse(inspectBreakdownDialog.IndustrialSafetyRiskBaselineResult), 1);

            Assert.AreEqual(expected, actual,
                $"Expected Value Units Result should be {expected}, but it was {actual}.");
        }

        [Test]
        public void ComplianceRiskMeasure_CheckBaselineResult()
        {
            // open Breakdown dialog for Transmission Reliability Risk value measure
            _valueDetailsTab.SelectValueMeasure(ValueMeasures.ComplianceRisk);
            var inspectBreakdownDialog = _valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate value unit result
            var consequence = decimal.Parse(inspectBreakdownDialog.ComplianceRiskConsequenceValue);
            var likelihood = decimal.Parse(inspectBreakdownDialog.ComplianceRiskLikelihoodValue);
            var expected = Math.Round((consequence * likelihood), 1);
            var actual = Math.Round(decimal.Parse(inspectBreakdownDialog.ComplianceRiskBaselineResult), 1);

            Assert.AreEqual(expected, actual,
                $"Expected Value Units Result should be {expected}, but it was {actual}.");
        }
    }
}

using System;
using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.Pages;
using DukeTransmission.UITests.TestData;
using NUnit.Framework;

namespace DukeTransmission.UITests.Tests
{
    public class TransmissionReliabilityRiskModelTests : TestBase
    {
        protected HomePage _homePage;
        private const string _partialUrl = "Pages/AlternativeValue/Views/AlternativeValue.aspx?id=6090&altid=4934&tabId=";

        public override void BeforeAll()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            var loginPage = LoginPage.NavigateToThisPageViaUrl(_driver);
            _homePage = loginPage.LogIn(LoginData.CopperleafAccount.Email, LoginData.CopperleafAccount.Password);
        }


        [Test] 
        public void TransmissionReliabilityRiskMeasure_CheckBaselineResult()
        {
            //open Alternative Value > Questionnaires Tab
            var alternativeValuePage = AlternativeValuePage.NavigateToThisPageViaUrl(_driver, _partialUrl);
            var questionnairesTab = alternativeValuePage.OpenQuestionnairesTab(_partialUrl);

            //select Transmission Reliability Risk value model
            questionnairesTab.SelectValueModel(ValueModels.TransmissionLineRisk);
            var valueDetailsTab = questionnairesTab.SelectValueDetailsTab();

            // open Breakdown dialog for Transmission Reliability Risk value measure
            valueDetailsTab.SelectValueMeasure(ValueMeasures.TransmissionReliabilityRisk);
            var inspectBreakdownDialog = valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate value unit result
            var consequence = decimal.Parse(inspectBreakdownDialog.TransmissionReliabilityRiskConsequenceValue);
            var likelihood = decimal.Parse(inspectBreakdownDialog.TransmissionReliabilityRiskLikelihoodValue);
            var expected = Math.Round(consequence * likelihood, 2); 
            var actual = Math.Round(decimal.Parse(inspectBreakdownDialog.TransReliabilityRiskBaselineResult), 2);

            Assert.AreEqual(expected, actual, $"Expected Value Units Result should be {expected}, but it was {actual}.");
        }
    }
}

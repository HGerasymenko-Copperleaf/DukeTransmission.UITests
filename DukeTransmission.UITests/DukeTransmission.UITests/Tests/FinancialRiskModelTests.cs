using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.Pages;
using DukeTransmission.UITests.TestData;
using NUnit.Framework;

namespace DukeTransmission.UITests.Tests
{
    public class FinancialRiskModelTests : TestBase
    {
        protected HomePage _homePage;
        private const string _partialUrl = "Pages/AlternativeValue/Views/AlternativeValue.aspx?id=6078&altid=4922&tabId=";

        public override void BeforeAll()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            var loginPage = LoginPage.NavigateToThisPageViaUrl(_driver);
            _homePage = loginPage.LogIn(LoginData.CopperleafAccount.Email, LoginData.CopperleafAccount.Password);
        }


        [Test]
        public void FinancialRiskMeasure_CheckBaselineResult()
        {
            //open Alternative Value > Questionnaires Tab
            var alternativeValuePage = AlternativeValuePage.NavigateToThisPageViaUrl(_driver, _partialUrl);
            var questionnairesTab = alternativeValuePage.OpenQuestionnairesTab(_partialUrl);

            //select Financial Risk value model
            questionnairesTab.SelectValueModel(ValueModels.FinancialRisk);
            var valueDetailsTab = questionnairesTab.SelectValueDetailsTab();

            // open Breakdown dialog for Financial Risk value measure
            valueDetailsTab.SelectValueMeasure(ValueMeasures.FinancialRisk);
            var inspectBreakdownDialog = valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate value unit result
            var consequence = decimal.Parse(inspectBreakdownDialog.FinancialRiskConsequenceValue);
            var likelihood = decimal.Parse(inspectBreakdownDialog.FinancialRiskLikelihoodValue);
            var expected = (consequence * likelihood); 
            var actual = decimal.Parse(inspectBreakdownDialog.BaselineResult);

            Assert.AreEqual(expected, actual, $"Expected Value Units Result should be {expected}, but it was {actual}.");
        }
    }
}

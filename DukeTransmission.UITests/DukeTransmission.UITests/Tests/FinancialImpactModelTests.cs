using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.Pages;
using DukeTransmission.UITests.TestData;
using NUnit.Framework;

namespace DukeTransmission.UITests.Tests
{
    public class FinancialImpactModelTests : TestBase
    {
        protected HomePage _homePage;
        private const string _partialUrl = "Pages/AlternativeValue/Views/AlternativeValue.aspx?id=4921&altid=4921&tabId=";

        public override void BeforeAll()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            var loginPage = LoginPage.NavigateToThisPageViaUrl(_driver);
            _homePage = loginPage.LogIn(LoginData.CopperleafAccount.Email, LoginData.CopperleafAccount.Password);
        }


        [Test]
        public void FinancialImpactMeasure_CheckBaselineResult()
        {
            //open Alternative Value > Questionnaires Tab
            var alternativeValuePage = AlternativeValuePage.NavigateToThisPageViaUrl(_driver, _partialUrl);
            var questionnairesTab = alternativeValuePage.OpenQuestionnairesTab(_partialUrl);

            //select Financial Impact value model
            questionnairesTab.SelectValueModel(ValueModels.FinancialImpact);
            var valueDetailsTab = questionnairesTab.SelectValueDetailsTab();

            // open Breakdown dialog for Financial Impact Capital value measure
            valueDetailsTab.SelectValueMeasure(ValueMeasures.FinancialImpactCapital);
            var inspectBreakdownDialog = valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate outcome
            var consequence = inspectBreakdownDialog.FinancialImpactCapitalConsequenceValue.Substring(1);
            var likelihood = inspectBreakdownDialog.FinancialImpactCapitalLikelihoodValue;
            var expected = double.Parse(consequence) * double.Parse(likelihood);
            var actual = double.Parse(inspectBreakdownDialog.FinancialImpactOutcome.Substring(1));

            Assert.AreEqual(expected, actual, $"Expected Outcome should be {expected}, but it was {actual}");
        }
    }
}

using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.Pages;
using DukeTransmission.UITests.TestData;
using NUnit.Framework;

namespace DukeTransmission.UITests.Tests
{
    public class EmployeeProductivityImpactModelTests : TestBase
    {
        protected HomePage _homePage;
        private const string _partialUrl = "Pages/AlternativeValue/Views/AlternativeValue.aspx?id=6081&altid=4925&tabId=";

        public override void BeforeAll()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            var loginPage = LoginPage.NavigateToThisPageViaUrl(_driver);
            _homePage = loginPage.LogIn(LoginData.CopperleafAccount.Email, LoginData.CopperleafAccount.Password);
        }


        [Test]
        public void EmployeeProductivityMeasure_CheckBaselineResult()
        {
            //open Alternative Value > Questionnaires Tab
            var alternativeValuePage = AlternativeValuePage.NavigateToThisPageViaUrl(_driver, _partialUrl);
            var questionnairesTab = alternativeValuePage.OpenQuestionnairesTab(_partialUrl);

            //select Employee Productivity Impact value model
            questionnairesTab.SelectValueModel(ValueModels.EmployeeProductivityImpact);
            var valueDetailsTab = questionnairesTab.SelectValueDetailsTab();

            // open Breakdown dialog for Employee Productivity Impact value measure
            valueDetailsTab.SelectValueMeasure(ValueMeasures.EmployeeProductivityImpact);
            var inspectBreakdownDialog = valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate outcome
            var consequence = inspectBreakdownDialog.EmpProductivityImpactConsequenceValue.Substring(1);
            var likelihood = inspectBreakdownDialog.EmpProductivityImpactLikelihoodValue;
            var expected = double.Parse(consequence) * double.Parse(likelihood);
            var actual = double.Parse(inspectBreakdownDialog.EmpProductivityImpactOutcome.Substring(1));

            Assert.AreEqual(expected, actual, $"Expected Outcome should be {expected}, but it was {actual}.");
        }
    }
}

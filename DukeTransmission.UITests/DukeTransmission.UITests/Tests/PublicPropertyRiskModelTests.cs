using DukeTransmission.UITests.Bases;
using DukeTransmission.UITests.enums;
using DukeTransmission.UITests.Pages;
using DukeTransmission.UITests.TestData;
using NUnit.Framework;

namespace DukeTransmission.UITests.Tests
{
    public class PublicPropertyRiskModelTests : TestBase
    {
        protected HomePage _homePage;
        private const string _partialUrl = "Pages/AlternativeValue/Views/AlternativeValue.aspx?id=6084&altid=4928&tabId=";

        public override void BeforeAll()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            var loginPage = LoginPage.NavigateToThisPageViaUrl(_driver);
            _homePage = loginPage.LogIn(LoginData.CopperleafAccount.Email, LoginData.CopperleafAccount.Password);
        }


        [Test]
        public void PublicPropertyRiskMeasure_CheckBaselineResult()
        {
            //open Alternative Value > Questionnaires Tab
            var alternativeValuePage = AlternativeValuePage.NavigateToThisPageViaUrl(_driver, _partialUrl);
            var questionnairesTab = alternativeValuePage.OpenQuestionnairesTab(_partialUrl);

            //select Public Property Risk value model
            questionnairesTab.SelectValueModel(ValueModels.PublicPropertyRisk);
            var valueDetailsTab = questionnairesTab.SelectValueDetailsTab();

            // open Breakdown dialog for Public Property Risk value measure
            valueDetailsTab.SelectValueMeasure(ValueMeasures.PublicPropertyRisk);
            var inspectBreakdownDialog = valueDetailsTab.OpenInspectBreakdownDialog();

            //calculate value unit result
            var consequence = decimal.Parse(inspectBreakdownDialog.PublicPropertyRiskConsequenceValue);
            var likelihood = decimal.Parse(inspectBreakdownDialog.PublicPropertyRiskLikelihoodValue);
            var expected = (consequence * likelihood); 
            var actual = decimal.Parse(inspectBreakdownDialog.BaselineResult);

            Assert.AreEqual(expected, actual, $"Expected Value Units Result should be {expected}, but it was {actual}.");
        }
    }
}

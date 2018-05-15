using System.Configuration;

namespace DukeTransmission.UITests.TestData
{
    public static class LoginData
    {
        public static readonly Account GmailAccount = new Account(
            ConfigurationManager.AppSettings["username"], 
            ConfigurationManager.AppSettings["password"]
        );

        public static readonly Account CopperleafAccount = new Account(
            ConfigurationManager.AppSettings["copperleaf_username"],
            ConfigurationManager.AppSettings["copperleaf_password"]);
    }
}

using System.Configuration;

namespace DukeTransmission.UITests.TestData
{
    public static class LoginData
    {
        public static readonly Account GmailAccount = new Account(
            ConfigurationManager.AppSettings["username"], 
            ConfigurationManager.AppSettings["password"]
        );
    }
}

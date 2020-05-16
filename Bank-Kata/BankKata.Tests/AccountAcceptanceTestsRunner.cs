using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankKata.Tests
{
    [TestClass]
    public class AccountAcceptanceTestsRunner
    {
        [TestMethod]
        [Ignore("Feature not yet implemented")]
        public void PrintStatementAcceptanceTestRunner()
        {
            new AccountAcceptanceTests().PrintStatementAcceptanceTest();
        }
    }
}
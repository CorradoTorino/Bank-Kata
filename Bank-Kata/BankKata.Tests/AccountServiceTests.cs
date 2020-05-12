using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankKata.UnitTests
{
    public interface IClock
    {
        public DateTime Now();
    }

    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        [Ignore("Feature not yet implemented")]
        public void PrintStatementAcceptanceTest()
        {
            // Arrange
            var clockMock = new Mock<IClock>();
            
            var consoleMock = new Mock<IConsole>();
            var consoleCalls = new List<string>();
            consoleMock.Setup(m => m.WriteLine(Capture.In(consoleCalls)));
            
            var account = new Account(clockMock.Object, consoleMock.Object);

            // Act
            clockMock.Setup((x) => x.Now()).Returns(new DateTime(2012, 01, 10));
            account.Deposit(1000);

            clockMock.Setup((x) => x.Now()).Returns(new DateTime(2012, 01, 13));
            account.Deposit(2000);

            clockMock.Setup((x) => x.Now()).Returns(new DateTime(2012, 01, 14));
            account.Withdraw(500);

            account.PrintStatement();

            // Assert
            consoleCalls.Should().BeEquivalentTo(new string[]
            {
                "Date       || Amount || Balance",
                "14/01/2012 || -500   || 2500",
                "13/01/2012 || 2000   || 3000",
                "10/01/2012 || 1000   || 1000",
            });
        }
    }

    public interface IConsole
    {
        void WriteLine(string lineToBePrinted);
    }
}

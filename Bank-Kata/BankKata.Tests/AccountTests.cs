using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankKata.Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Deposit_RecordTransaction()
        {
            // Arrange
            const int amount = 1000;
            var dateTime = new DateTime(2020, 05, 11);

            var clockMock = new Mock<IClock>();
            clockMock.Setup((x) => x.Now()).Returns(dateTime);

            var consoleMock = new Mock<IConsole>();
            var transactionRepositoryMock = new Mock<ITransactionRepository>();

            var account = new Account(clockMock.Object, consoleMock.Object, transactionRepositoryMock.Object);

            // Act
            account.Deposit(amount);

            // Assert
            transactionRepositoryMock.Verify(
                (repository)=>repository.Record(
                    It.Is<Transaction>(transaction=>transaction.TransactionDate == dateTime && transaction.Amount == amount)));
        }

        [TestMethod]
        public void Withdraw_RecordTransaction()
        {
            // Arrange
            const int amount = 1000;
            var dateTime = new DateTime(2020, 05, 11);

            var clockMock = new Mock<IClock>();
            clockMock.Setup((x) => x.Now()).Returns(dateTime);

            var consoleMock = new Mock<IConsole>();
            var transactionRepositoryMock = new Mock<ITransactionRepository>();

            var account = new Account(clockMock.Object, consoleMock.Object, transactionRepositoryMock.Object);

            // Act
            account.Withdraw(amount);

            // Assert
            transactionRepositoryMock.Verify(
                (repository) => repository.Record(
                    It.Is<Transaction>(transaction => transaction.TransactionDate == dateTime && transaction.Amount == -amount)));
        }
    }
}

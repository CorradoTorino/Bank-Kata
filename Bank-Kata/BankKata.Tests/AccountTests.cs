using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankKata.Tests
{
    [TestClass]
    public class AccountTests
    {
        const int amount = 1000;
        readonly DateTime DateTime = new DateTime(2020, 05, 11);

        readonly Mock<IClock> ClockMock = new Mock<IClock>();
        readonly Mock<IConsole> ConsoleMock = new Mock<IConsole>();
        readonly Mock<ITransactionRepository> TransactionRepositoryMock = new Mock<ITransactionRepository>();

        private Account Sut;

        [TestInitialize]
        public void Initialize()
        {
            this.ClockMock.Setup((x) => x.Now()).Returns(this.DateTime);

            this.Sut = new Account(
                this.ClockMock.Object,
                this.ConsoleMock.Object,
                this.TransactionRepositoryMock.Object);
        }

        [TestMethod]
        public void Deposit_RecordTransaction()
        {
            // Arrange

            // Act
            this.Sut.Deposit(amount);

            // Assert
            this.TransactionRepositoryMock.Verify(
                (repository)=>repository.Record(
                    It.Is<Transaction>(transaction=>transaction.TransactionDate == this.DateTime && transaction.Amount == amount)));
        }

        [TestMethod]
        public void Withdraw_RecordTransaction()
        {
            // Arrange

            // Act
            this.Sut.Withdraw(amount);

            // Assert
            this.TransactionRepositoryMock.Verify(
                (repository) => repository.Record(
                    It.Is<Transaction>(transaction => transaction.TransactionDate == this.DateTime && transaction.Amount == -amount)));
        }

        [TestMethod]
        public void PrintStatement_CallStatementPrinterWithAllTransactions()
        {
            // Arrange
            var transactionLists = new List<Transaction>()
            {
                new Transaction(new DateTime(2020, 04, 15), 500 ),
                new Transaction(new DateTime(2020, 04, 14), -1000),
            };

            this.TransactionRepositoryMock.Setup(x => x.GetAll()).Returns(transactionLists);

            var consoleOutputs = new List<string>();

            this.ConsoleMock.Setup(x => x.WriteLine(Capture.In(consoleOutputs)));
            
            // Act
            Sut.PrintStatement();

            // Assert
            consoleOutputs.Should().BeEquivalentTo(new List<string>
            {
                "Date       || Amount || Balance",
                "15/01/2020 || 500    ||  -500",
                "14/01/2020 || -1000  || -1000",
            });
        }
    }
}

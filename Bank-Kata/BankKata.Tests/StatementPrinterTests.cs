using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankKata.Tests
{
    [TestClass]
    public class StatementPrinterTests
    {
        readonly Mock<IConsole> consoleMock = new Mock<IConsole>();
        StatementPrinter sut;

        [TestInitialize]
        public void TestInitialize()
        {
            this.sut = new StatementPrinter(consoleMock.Object);
        }

        [TestMethod]
        public void StatementPrinter_WhenTransactionIsEmpty_ReturnsHeader()
        {
            // Arrange
            var expectedOutput = "Date       || Amount || Balance".Replace(" ", "");

            // Act
            sut.PrintStatement(new List<Transaction>());

            // Assert
            consoleMock.Verify(console => console.WriteLine(
                    It.Is<string>(s => s.Replace(" ", "") == expectedOutput)),
                Times.Once);
        }

        [TestMethod]
        public void StatementPrinter_WhenTransactionIsNull_ReturnsHeader()
        {
            // Arrange
            var expectedOutput = "Date       || Amount || Balance".Replace(" ", "");

            // Act
            sut.PrintStatement(null);

            // Assert
            consoleMock.Verify(console => console.WriteLine(
                    It.Is<string>(s => s.Replace(" ", "") == expectedOutput)),
                Times.Once);
        }

        [TestMethod]
        public void StatementPrinter_WhenTransactionsToBePrintedAreNotEmpty_ReturnsHeaderAndTransactions()
        {
            // Arrange
            var consoleOutput = new List<string>();
            consoleMock.Setup(m => m.WriteLine(Capture.In(consoleOutput)));
            
            var transactions = new List<Transaction>()
            {
                new Transaction(new DateTime(2010,5,4), 2000)
            };
            
            var expectedOutput = new List<string>()
            {
                "Date || Amount || Balance".Replace(" ", ""),
                "04/05/2010||2000||2000".Replace(" ", "")
            };
            
            // Act
            sut.PrintStatement(transactions);

            // Assert
            consoleOutput.Should().BeEquivalentTo(expectedOutput);
        }
    }
}

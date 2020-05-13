using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankKata.Tests
{
    [TestClass]
    public class TransactionRepositoryTests
    {
        [TestMethod]
        public void GetAll_WhenTransactionsAreRecorded_ReturnTransactionsInTheSameOrder()
        {
            // Arrange
            var transactionsRecorded = new List<Transaction>()
            {
                new Transaction(new DateTime(2020, 04, 15), 500 ),
                new Transaction(new DateTime(2020, 04, 15), -1000),
            };

            var sut = new TransactionRepository();

            foreach (var transaction in transactionsRecorded)
            {
                sut.Record(transaction);
            }
            
            // Act
            var transactions = sut.GetAll();

            // Assert
            transactions.Should().BeEquivalentTo(transactionsRecorded);
        }
    }
}

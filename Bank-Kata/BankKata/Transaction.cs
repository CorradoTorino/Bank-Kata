using System;

namespace BankKata
{
    public class Transaction
    {
        public readonly int Amount;

        public readonly DateTime TransactionDate;

        public Transaction(DateTime transactionDate, int amount)
        {
            TransactionDate = transactionDate;
            Amount = amount;
        }
    }
}
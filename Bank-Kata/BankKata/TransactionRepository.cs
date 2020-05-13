using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> Transactions = new List<Transaction>();

        public void Record(Transaction transaction)
        {
            this.Transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return this.Transactions.ToList();
        }
    }
}
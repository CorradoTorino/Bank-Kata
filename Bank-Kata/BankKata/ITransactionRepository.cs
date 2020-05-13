using System.Collections;
using System.Collections.Generic;

namespace BankKata
{
    public interface ITransactionRepository
    {
        void Record(Transaction transaction);
        
        IEnumerable<Transaction> GetAll();
    }
}
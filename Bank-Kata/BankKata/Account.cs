using System;

namespace BankKata
{
    public class Account
    {
        private readonly IClock clock;
        private readonly ITransactionRepository transactionRepository;
        private readonly IStatementPrinter statementPrinter;

        public Account(IClock clock, ITransactionRepository transactionRepository,
            IStatementPrinter statementPrinter)
        {
            this.clock = clock;
            this.transactionRepository = transactionRepository;
            this.statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            var transaction = new Transaction(this.clock.Now(), amount);
            this.transactionRepository.Record(transaction);
        }

        public void Withdraw(int amount)
        {
            var transaction = new Transaction(this.clock.Now(), -amount);
            this.transactionRepository.Record(transaction);
        }

        public void PrintStatement()
        {
            this.statementPrinter.PrintStatement(this.transactionRepository.GetAll());
        }
    }
}
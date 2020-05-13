using System;

namespace BankKata
{
    public class Account
    {
        private readonly IClock clock;
        private readonly IConsole console;
        private readonly ITransactionRepository transactionRepository;

        public Account(IClock clock, IConsole console, ITransactionRepository transactionRepository)
        {
            this.clock = clock;
            this.console = console;
            this.transactionRepository = transactionRepository;
        }

        public Account(IClock clock, IConsole console): this(clock, console, new TransactionRepository())
        {
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
            throw new NotImplementedException();
        }
    }
}
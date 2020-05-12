using System;

namespace BankKata.Tests
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
            this.transactionRepository.RecordTransaction(new Transaction(this.clock.Now(), amount));
        }

        public void Withdraw(int amount)
        {
            throw new NotImplementedException();
        }

        public void PrintStatement()
        {
            throw new NotImplementedException();
        }
    }
}
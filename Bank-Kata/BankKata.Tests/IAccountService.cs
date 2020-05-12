using System;

namespace BankKata.UnitTests
{
    public class Account
    {
        private readonly IClock clock;
        private readonly IConsole console;

        public Account(IClock clock, IConsole consoleMockObject)
        {
            this.clock = clock;
            this.console = consoleMockObject;
        }

        public void Deposit(int amount)
        {
            throw new NotImplementedException();
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
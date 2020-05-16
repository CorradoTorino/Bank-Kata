using System.Collections.Generic;

namespace BankKata
{
    public class StatementPrinter : IStatementPrinter
    {
        private readonly IConsole console;

        public StatementPrinter(IConsole console)
        {
            this.console = console;
        }

        public void PrintStatement(IEnumerable<Transaction> transactions)
        {
        }
    }
}
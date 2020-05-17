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
            this.PrintHeader();
            this.PrintTransactions(transactions);
        }

        private void PrintHeader()
        {
            this.console.WriteLine("Date||Amount||Balance");
        }

        private void PrintTransactions(IEnumerable<Transaction> transactions)
        {
            if (transactions == null)
            {
                return;
            }
            
            foreach (var transaction in transactions)
            {
                this.console.WriteLine($"{transaction.TransactionDate:dd/MM/yyyy}||{transaction.Amount}||{transaction.Amount}");
            }
        }
    }
}
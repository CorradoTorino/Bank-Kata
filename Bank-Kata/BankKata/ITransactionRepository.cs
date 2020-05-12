namespace BankKata
{
    public interface ITransactionRepository
    {
        void RecordTransaction(Transaction transaction);
    }
}
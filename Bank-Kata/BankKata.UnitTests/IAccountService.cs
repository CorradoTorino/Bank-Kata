namespace Bank_Kata.UnitTests
{
    public interface IAccountService
    {
        void deposit(int amount);
        void withdraw(int amount);
        void printStatement();
    }
}
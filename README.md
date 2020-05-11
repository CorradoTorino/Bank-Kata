# Bank-Kata
A kata for training Outside In TDD. 

Write a class named `Account` that implements the following public interface:

```csharp
public interface AccountService
{
    void deposit(int amount); 
    void withdraw(int amount); 
    void printStatement();
}
```
You cannot change the public interface of this class.
Here's the specification for an acceptance test that expresses the desired behavior.

```
Given a client makes a deposit of 1000 on 10-01-2012
And a deposit of 2000 on 13-01-2012
And a withdrawal of 500 on 14-01-2012
When they print their bank statement
Then they would see:

Date       || Amount || Balance
14/01/2012 || -500   || 2500
13/01/2012 || 2000   || 3000
10/01/2012 || 1000   || 1000
```

- We're using `ints` for the money amounts to keep the auxiliaries as simple as possible. 
- Don't worry about spacing and indentation in the statement output.
- Use the acceptance test to guide your progress towards the solution.
- When in doubt, go for the simplest solution!

This kata is taken from [Katalist](https://katalyst.codurance.com/bank) 
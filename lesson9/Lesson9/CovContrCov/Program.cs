using System;

namespace CovContrCov
{
	class Program
	{
		static void Main(string[] args)
		{
			IBank<Account> ordinaryBank = new Bank<Account>();
			Account account = ordinaryBank.CreateAccount(23);

			Bank<DepositAccount> depositBank = new Bank<DepositAccount>();
			DepositAccount depositAccount = depositBank.CreateAccount(56);

			//we can't do this without <out T>
			IBank<Account> ordinaryBankAccount = new Bank<DepositAccount>();

			ITransaction<Account> ordinAccTrans = new Transaction<Account>();
			ordinAccTrans.DoTransaction(new Account(), 500);

			//to do this, we must specify <in T>
			ITransaction<DepositAccount> depAccTrans = new Transaction<Account>();
			depAccTrans.DoTransaction(new DepositAccount(), 600);

		}
	}

	class Account
	{
		public virtual void Transfer(int s)
		{
			Console.WriteLine($"Transfered {s} dollars.");
		}
	}

	class DepositAccount : Account
	{
		public override void Transfer(int s)
		{
			Console.WriteLine($"Transfered {s} dollars with deposit account.");
		}
	}

	interface IBank<out T>
	{
		T CreateAccount(int s);
	}

	class Bank<T> : IBank<T> where T : Account, new()
	{
		public T CreateAccount(int s)
		{
			T account = new T();
			account.Transfer(s);
			return account;
		}
	}

	interface ITransaction<in T>
	{
		void DoTransaction(T account, int sum);
	}

	class Transaction<T> : ITransaction<T> where T : Account
	{
		public void DoTransaction(T account, int sum)
		{
			account.Transfer(sum);
		}
	}
}

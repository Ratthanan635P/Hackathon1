using EWallet.DataAccess.Contexts;
using EWallet.DataAccess.Repositories;
using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using System;

namespace TestConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");
			EWalletContext context = new EWalletContext();
			IUserRepository user = new UserRepository(context);
			RegisterUserDto register = new RegisterUserDto() {
				Email = "test5@t.t",
				BrithDate = new DateTime(1991, 1, 9),
				Phone = "0904178488",
				FristName = "Ratthanan",
				LastName ="Poulai",
				Password="Gg123456789",
				Salt="asdfghjkl123456789"
            };
			user.Register(register);

		}
	}
}

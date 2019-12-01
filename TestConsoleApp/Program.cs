using EWallet.DataAccess.Contexts;
using EWallet.DataAccess.Repositories;
using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using EWallet.Domain.Interfaces.Services;
using System;

namespace TestConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
//			Console.WriteLine("Hello World!");
//			EWalletContext context = new EWalletContext();
//			IUserRepository user = new UserRepository(context);
//			IAgrentRepository Agrent = new AgrentRepository(context);

//			var result = Agrent.GenarateTopup(10, "test05@tt.tt");
//			Console.WriteLine(result.RefNo);
//			Console.WriteLine(user.CheckBalance("test02@tt.tt"));
//			bool isSaccess = user.TopUp("test05@tt.tt", result.RefNo, "test02@tt.tt");
//			if (isSaccess)
//			{
//				Console.WriteLine("success");
//				Console.WriteLine(user.CheckBalance("test02@tt.tt"));
//			}
//			else
//			{
//				Console.WriteLine("No success");
//				Console.WriteLine(user.CheckBalance("test02@tt.tt"));
//			}

//			isSaccess = user.Payment("test02@tt.tt", 50, "test06@tt.tt");
//			if (isSaccess)
//			{
//				Console.WriteLine("success payment");
//				Console.WriteLine(user.CheckBalance("test02@tt.tt"));
//			}
//			else
//			{
//				Console.WriteLine("No success payment");
//				Console.WriteLine(user.CheckBalance("test02@tt.tt"));
//			}

//			marchant01 test06@tt.tt
//marchant02  test07 @tt.tt

//			for (int i = 0; i < 10; i++)
//			{
//				RegisterUserDto register = new RegisterUserDto()
//				{
//					Email = "test0" + i + "@tt.tt",
//					BrithDate = new DateTime(1991, 1, 9),
//					Phone = "0904" + i + "78488",
//					FristName = "Ratthanan" + i,
//					LastName = "Poulai",
//					Password = "Gg123456789" + i,
//					Salt = "asdfghjkl123456789" + i
//				};
//				user.Register(register);
//			}
		}
	}
}

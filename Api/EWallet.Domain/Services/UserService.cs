using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Services
{
	public class UserService : IUserService
	{
		public bool ChangePassword(string email, string password, string newpassword)
		{
			throw new NotImplementedException();
		}

		public double CheckBalance(string email)
		{
			throw new NotImplementedException();
		}

		public bool CheckUserAccount(string email)
		{
			throw new NotImplementedException();
		}

		public bool EditDataUser(DetailUserAccountDto data)
		{
			throw new NotImplementedException();
		}

		public DetailUserAccountDto GetDataUser(string email)
		{
			throw new NotImplementedException();
		}

		public List<Transactions> History(string email)
		{
			throw new NotImplementedException();
		}

		public DetailUserAccountDto LogIn(string email, string password)
		{
			throw new NotImplementedException();
		}

		public bool LogOut(string email)
		{
			throw new NotImplementedException();
		}

		public bool Register(RegisterUserDto registerUserDto)
		{
			throw new NotImplementedException();
		}
	}
}

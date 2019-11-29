using EWallet.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Interfaces.Services
{
	public interface IUserService
	{
		bool Register(RegisterUserDto registerUserDto);
		bool CheckUserAccount(string email);
		DetailUserAccountDto LogIn(string email,string password);
		bool LogOut(string email);
      //  bool GetData(string email);		
	}
}

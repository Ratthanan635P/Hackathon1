using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Interfaces.Repositories
{
	public interface IUserRepository
	{
		//string AddUser(string email, string password, string salt);
		////ดึง Salt โดย Username 
		////string GetSaltByUser(string userName);
		////Update For Forgotpassword
		//string UpdateUser(string email, string password, string salt);
		////ดึง Salt และ Password โดย Username เพื่อ Check
		//User GetUserByEmail(string email);
		////Update ActiveStatus to false  =>  Logout
		//string UpdateActiveStatus(string email);
		////

		bool Register(User registerUserDto);
		//
		bool CheckUserAccount(string email);
		//
		User LogIn(string email, string password);
		//
		bool EditDataUser(User data);
		//
		bool LogOut(string email);
		//
		User GetDataUser(string email);
		//
		bool ChangePassword(string email, string password, string newpassword);
		//
		double CheckBalance(string email);
		//
		List<Transactions> History(string email);

	}
}

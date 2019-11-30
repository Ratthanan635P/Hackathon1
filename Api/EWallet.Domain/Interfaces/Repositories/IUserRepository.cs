using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Interfaces.Repositories
{
	public interface IUserRepository
	{
		//
		bool Register(RegisterUserDto registerUserDto);
		//
		bool CheckUserAccount(string email);
		//
		User LogIn(string email, string password);
		//
		bool EditDataUser(DetailUserAccountDto data);
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
		//
		bool TopUp(string emailSender, string refno, string emailReceive);
		//
		bool Payment(string emailSender, double money, string emailReceive);
		//
		bool CheckTopUp(string refno);
	}
}

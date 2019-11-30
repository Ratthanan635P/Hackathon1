using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Interfaces.Services
{
	public interface IUserService
	{
		//
		bool Register(RegisterUserDto registerUserDto);
		//
		bool CheckUserAccount(string email);
		//
		DetailUserAccountDto LogIn(string email,string password);
		//
		bool EditDataUser(DetailUserAccountDto data);
		//
		bool LogOut(string email);
		//
		DetailUserAccountDto GetDataUser(string email);
		//
		bool ChangePassword(string email, string password, string newpassword);
		//
		double CheckBalance(string email);
		//
		List<Transactions> History(string email);
		bool TopUp(string emailSender, string refno, string emailReceive);
		//
		bool Payment(string emailSender, double money, string emailReceive);
		//
		bool CheckTopUp(string refno);
	}
}

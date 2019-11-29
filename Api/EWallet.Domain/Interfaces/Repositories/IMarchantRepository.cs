using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Interfaces.Repositories
{
	public interface IMarchantRepository
	{
		// Register
		//bool RegisterMarchant(Marchant marchant);
		//  login(email ,password)
		Marchant LogIn(string email, string password);
		//  GenarateTopup(double money)==>	จะได้ referrence 
		//string GenarateTopup(double money);
		//  history(Accountid) => List<Transaction>
		List<Transactions> History(string email);
		//  CheckBalance()==>	จะได้ double 
		double CheckBalance(string email);
	}
}

using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Interfaces.Repositories
{
	public interface IAgrentRepository
	{
		// Register
		//bool RegisterAgrent(Agrent agrent);
		//  login(email ,password)
		Agrent LogIn(string email, string password);
		//  GenarateTopup(double money)==>	จะได้ referrence 
		TopUpDto GenarateTopup(double money,string email);
		//  history(Accountid) => List<Transaction>
		List<Transactions> History(string email);
		//  CheckBalance()==>	จะได้ double 
		double CheckBalance(string email);
	}
}

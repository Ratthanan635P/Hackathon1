﻿using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace EWallet.Domain.Interfaces.Services
{
	public interface IAgrentService
	{
		//  login(email ,password)
		DetailAgrentDto LogIn(string email, string password);
		//  GenarateTopup(double money)==>	จะได้ referrence 
		TopUpDto GenarateTopup(double money,string email);
		//  history(Accountid) => List<Transaction>
		List<Transactions> History(string email);
		//  CheckBalance()==>	จะได้ double 
		double CheckBalance(string email);
	}
}

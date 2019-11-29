using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Services
{
	public class AgrentService : IAgrentService
	{
		private IAgrentService agrentService;
		public AgrentService(IAgrentService agrentService)
		{
			this.agrentService = agrentService;

		}
		public double CheckBalance(string email)
		{
			double result = agrentService.CheckBalance(email);
			return result;
		}

		public string GenarateTopup(double money)
		{
			throw new NotImplementedException();
		}

		public List<Transactions> History(string email)
		{
			throw new NotImplementedException();
		}

		public DetailAgrentDto LogIn(string email, string password)
		{
			throw new NotImplementedException();
		}
	}
}

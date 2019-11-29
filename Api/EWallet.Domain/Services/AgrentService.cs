using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using EWallet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Services
{
	public class AgrentService : IAgrentService
	{
		private IAgrentRepository agrentRepository;
		public AgrentService(IAgrentRepository agrentRepository)
		{
			this.agrentRepository = agrentRepository;

		}
		public double CheckBalance(string email)
		{
			double result = agrentRepository.CheckBalance(email);
			return result;
		}

		public TopUpDto GenarateTopup(double money,string email)
		{
			
			TopUpDto result = agrentRepository.GenarateTopup(money, email);
			return result;
			//throw new NotImplementedException();
		}

		public List<Transactions> History(string email)
		{
			var result = agrentRepository.History(email);
			return result;
			//throw new NotImplementedException();
		}

		public DetailAgrentDto LogIn(string email, string password)
		{
			var result = agrentRepository.LogIn(email, password);
			DetailAgrentDto detailAgrent = new DetailAgrentDto()
			{ 
				Id=result.Id,
				AccountEWallet=result.AccountEWallet,
				NameShop=result.NameAgrent
             };
			return detailAgrent;
			//throw new NotImplementedException();
		}
	}
}

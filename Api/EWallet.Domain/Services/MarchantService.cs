using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Services
{

		public class MarchantService : IMarchantService
		{
			private IMarchantService marchantService;
			public MarchantService(IMarchantService marchantService)
			{
				this.marchantService = marchantService;

			}
			public double CheckBalance(string email)
			{
				double result = marchantService.CheckBalance(email);
				return result;
			}

			//public TopUpDto GenarateTopup(double money, string email)
			//{

			//	TopUpDto result = marchantService.GenarateTopup(money, email);
			//	return result;
			//	//throw new NotImplementedException();
			//}

			public List<Transactions> History(string email)
			{
				var result = marchantService.History(email);
				return result;
				//throw new NotImplementedException();
			}

			public DetailMarchantDto LogIn(string email, string password)
			{
				var result = marchantService.LogIn(email, password);
				DetailMarchantDto detailMargent = new DetailMarchantDto()
				{
					Id = result.Id,
					AccountEWallet = result.AccountEWallet,
					NameShop = result.NameShop
				};
				return detailMargent;
				//throw new NotImplementedException();
			}
		}
	
}

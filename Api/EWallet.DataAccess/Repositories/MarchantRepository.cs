using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAccess.Repositories
{
	public class MarchantRepository : IMarchantRepository
	{
		public double CheckBalance(string email)
		{
			throw new NotImplementedException();
		}

		//public string GenarateTopup(double money)
		//{
		//	throw new NotImplementedException();
		//}

		public List<Transactions> History(string email)
		{
			throw new NotImplementedException();
		}

		public Marchant LogIn(string email, string password)
		{
			throw new NotImplementedException();
		}

		public bool RegisterMarchant(Marchant marchant)
		{
			throw new NotImplementedException();
		}
	}
}

using EWallet.DataAccess.Contexts;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWallet.DataAccess.Repositories
{
	public class AgrentRepository : IAgrentRepository
	{
		private readonly EWalletContext _context;
		private Random random;
		public AgrentRepository(EWalletContext context)
		{
			_context = context;
			random = new Random();
		}
		public double CheckBalance(string email)
		{
			var user = _context.AccountEWallets.Where(x => x.Email == email).FirstOrDefault();
			if (user == null)
			{
				return 0;
			}
			else
			{
				return user.AccountEWallet.Balance;
			}
		}

		public string GenarateTopup(double money)
		{
			throw new NotImplementedException();
		}

		public List<Transactions> History(string email)
		{
			throw new NotImplementedException();
		}

		public Agrent LogIn(string email, string password)
		{
			throw new NotImplementedException();
		}

		public bool RegisterAgrent(Agrent agrent)
		{
			throw new NotImplementedException();
		}
	}
}

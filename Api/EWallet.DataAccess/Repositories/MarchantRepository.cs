using EWallet.DataAccess.Contexts;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWallet.DataAccess.Repositories
{
	public class MarchantRepository : IMarchantRepository
	{
		private readonly EWalletContext _context;
		private Random random;
		public MarchantRepository(EWalletContext context)
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
				return user.Balance;
			}
		}

		//public string GenarateTopup(double money)
		//{
		//	throw new NotImplementedException();
		//}

		public List<Transactions> History(string email)
		{
			DateTime lastmonth = DateTime.Now.AddDays(-30);
			var result = _context.Transactions.Where(x => x.Receive.Email == email && x.IsDelete == false && x.Sender.Email == email && x.CreateDate <= DateTime.Now && x.CreateDate > (lastmonth)).OrderBy(X => X.CreateDate).ToList();

			//var  result= user.Where(x=>x.CreateDate<=DateTime.Now&&x.CreateDate>(lastmonth)).GroupBy(x => x.CreateDate.Month).ToList();
			return result;
		}

		public Marchant LogIn(string email, string password)
		{
			var result = _context.Marchants.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
			if (result == null)
			{
				return result;
			}
			else
			{
				//_context.SaveChanges();
				return result;
			}
		}

		//public bool RegisterMarchant(Marchant marchant)
		//{
		//	throw new NotImplementedException();
		//}
	}
}

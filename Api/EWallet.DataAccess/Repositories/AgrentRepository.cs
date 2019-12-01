using EWallet.DataAccess.Contexts;
using EWallet.Domain.Dtos;
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
				return user.Balance;
			}
		}

		public TopUpDto GenarateTopup(double money,string email)
		{
			//throw new NotImplementedException();
			//agrent.Email
			//	Random random = new Random();
			var agrent = _context.Agrents.Where(x=>x.Email==email).FirstOrDefault();
			if (agrent==null)
			{
				return null;
              }
			string refno = RandomCode();
			GenrateTopUp genrate = new GenrateTopUp() { 
              IsDelete=false,
			  Agrent =agrent,
			  CreateDate=DateTime.Now,
			  ExpireDate=DateTime.Now.AddMinutes(5),
			  IsUsed=false,
			  Money=money,
			  RefNo= refno,
			  UpdateDate=DateTime.Now,
			  UpdateBy= agrent.Id
			};
			_context.GenrateTopUp.Add(genrate);
			_context.SaveChanges();
			TopUpDto topUpDto = new TopUpDto()
			{
				Money=money,
				RefNo=refno,
				ExpireDate=genrate.ExpireDate
			};
			return topUpDto;
		}
		public string RandomCode()
		{
			const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, random.Next(20,20))
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}
		public List<Transactions> History(string email)
		{
			DateTime lastmonth = DateTime.Now.AddDays(-30);
			var result = _context.Transactions.Where(x => (x.Sender.Email == email) && x.CreateDate <= DateTime.Now && x.CreateDate > (lastmonth)).OrderBy(X => X.CreateDate).ToList();

			//var  result= user.Where(x=>x.CreateDate<=DateTime.Now&&x.CreateDate>(lastmonth)).GroupBy(x => x.CreateDate.Month).ToList();
			return result;
		}

		public Agrent LogIn(string email, string password)
		{
			var result = _context.Agrents.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
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

		//public bool RegisterAgrent(Agrent agrent)
		//{
		//	throw new NotImplementedException();
		//}
	}
}

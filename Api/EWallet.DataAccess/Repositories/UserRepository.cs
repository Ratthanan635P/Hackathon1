using EWallet.DataAccess.Contexts;
using EWallet.Domain.Entities;
using EWallet.Domain.Helpers;
using EWallet.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EWallet.Domain.Dtos;

namespace EWallet.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly EWalletContext _context;
		private Random random;
		public UserRepository(EWalletContext context)
		{
			_context = context;
			random = new Random();
		}
		public bool ChangePassword(string email, string password, string newpassword)
		{
			var result = _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
			if (result == null)
			{
				return false;
			}
			else
			{
				result.Password = newpassword;
				_context.SaveChanges();
				return true;
			}
		}

		public double CheckBalance(string email)
		{
			var user = _context.Users.Where(x => x.Email == email && x.IsDelete == false).FirstOrDefault();
			if (user == null)
			{
				return 0;
			}
			else
			{
				return  user.AccountEWallet.Balance;
			}			
		}

		public bool CheckUserAccount(string email)
		{
			var user = _context.Users.Where(x => x.Email == email && x.IsDelete == false).FirstOrDefault();
			if (user == null)
			{
				return false;
			}
			else
			{
				return true;
			}
			
		}

		public bool EditDataUser(DetailUserAccountDto data)
		{
			//throw new NotImplementedException();
			var user = _context.Users.Where(x => x.Email == data.Email && x.IsDelete == false).FirstOrDefault();
			user.BrithDate = data.BrithDate;
			user.FristName = data.FristName;
			user.LastName = data.LastName;
			user.Phone = data.Phone;
			user.UpdateDate = DateTime.Now;		
			_context.SaveChanges();

			return true;
		}

		public User GetDataUser(string email)
		{
			var user = _context.Users.Where(x => x.Email == email && x.IsDelete == false).FirstOrDefault();
			return user;
		}

		public List<Transactions> History(string email)
		{
			//throw new NotImplementedException();
			DateTime lastmonth = DateTime.Now.AddDays(-30);
			var result = _context.Transactions.Where(x => x.Receive.Email == email && x.IsDelete == false&& x.Sender.Email == email&& x.CreateDate <= DateTime.Now && x.CreateDate > (lastmonth)).OrderBy(X=>X.CreateDate).ToList();
			
			//var  result= user.Where(x=>x.CreateDate<=DateTime.Now&&x.CreateDate>(lastmonth)).GroupBy(x => x.CreateDate.Month).ToList();
			return result;
		}

		public User LogIn(string email, string password)
		{
			//throw new NotImplementedException();
			var result = _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
			if (result == null)
			{
				return result;
			}
			else
			{

				_context.SaveChanges();
				return result;
			}
		}
		public bool LogOut(string email)
		{
			var user = _context.Users.Where(x => x.Email == email && x.IsDelete == false).FirstOrDefault();
			user.Active = Enums.Status.InActive;
			user.ActiveDateTime = DateTime.Now;
			user.UpdateDate = DateTime.Now;			
			_context.SaveChanges();
			return true;
		}
		public bool Register(RegisterUserDto registerUserDto)
		{

			User user = new User()
			{
				IsDelete = false,
				FristName=registerUserDto.FristName,
				LastName=registerUserDto.LastName,
				BrithDate=registerUserDto.BrithDate,
				CreateDate= DateTime.Now,
				Password=registerUserDto.Password,
				Email=registerUserDto.Email,
				Phone=registerUserDto.Phone,
				Salt=registerUserDto.Salt
			};
			_context.Users.Add(user);
			_context.SaveChanges();

			int UpperId = random.Next(100, 999);
			int MidId = random.Next(100, 999);
			int LowperId = random.Next(1000, 9999);
			string idAccount = UpperId.ToString()+ MidId.ToString() + LowperId.ToString();
			while (true)
			{
				try
				{
					AccountEWallet result = _context.AccountEWallets.Where(x => x.AccountWallet == idAccount).SingleOrDefault();
					if (result == null)
					{
						break;
					}
					else
					{
						UpperId = random.Next(100, 999);
						MidId = random.Next(100, 999);
						LowperId = random.Next(1000, 9999);
						idAccount = UpperId.ToString() + MidId.ToString() + LowperId.ToString();
					}

				}
				catch (Exception ex)
				{
					break;
				}
			}
			AccountEWallet account = new AccountEWallet()
			{
				AccountWallet= idAccount,
				Email = registerUserDto.Email,
				Balance = 0,
				IsDelete = false,
				CreateDate = DateTime.Now,
				UpdateBy=1,
				UpdateDate = DateTime.Now
			};
			_context.AccountEWallets.Add(account);
			_context.SaveChanges();
			AccountEWallet AccountEWalletsId= _context.AccountEWallets.FirstOrDefault(x => x.Email == registerUserDto.Email);

			var updateAccountId = _context.Users.FirstOrDefault(x => x.Email == registerUserDto.Email);
			updateAccountId.AccountEWallet = AccountEWalletsId;
			_context.SaveChanges();
			return true;
		}
	}
}

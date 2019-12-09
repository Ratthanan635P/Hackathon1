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
			var user = _context.Users.Include(x=>x.AccountEWallet).Where(x => x.Email == email && x.IsDelete == false).FirstOrDefault();
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
			var result = _context.Transactions.Where(x => x.Receive.Email == email && x.IsDelete == false&& x.Sender.Email == email&& x.CreateDate <= DateTime.Now && x.CreateDate >= (lastmonth)).OrderBy(X=>X.CreateDate).ToList();
			
			
			return result;
		}

		public User LogIn(string email, string password)
		{
			//throw new NotImplementedException();
			var result = _context.Users.Include(x=>x.AccountEWallet).Where(x => x.Email == email && x.Password == password).FirstOrDefault();
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
					string error= ex.Message;
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
		public bool TopUp(string emailSender, string refno, string emailReceive)
		{
			var agrent = _context.Agrents.FirstOrDefault(x => x.Email == emailSender);
			if (agrent == null)
			{
				return false;
            }
			var Customer = _context.Users.FirstOrDefault(x => x.Email == emailReceive);
			if (Customer == null)
			{
				return false;
			}
			var topUp = _context.GenrateTopUp.FirstOrDefault(x => x.RefNo == refno);
			//var Customer = _context.Users.FirstOrDefault(x => x.Email == emailReceive);
			if (topUp.ExpireDate <= DateTime.Now)
			{
				return false;
			}
			Transactions transactions = new Transactions()
			{
				 CreateDate=DateTime.Now,
				 IsDelete=false,
				 Money= topUp.Money,
				 ReceiveTransaction=Enums.Transactions.TopUp,
				 SenderTransaction = Enums.Transactions.TopUp,
				 RefNo="T"+topUp.RefNo,
				 Receive = Customer.AccountEWallet,
				 Sender = agrent.AccountEWallet,
				 UpdateDate = DateTime.Now,
				 UpdateBy = Customer.Id
			};
			_context.Transactions.Add(transactions);
			Customer.AccountEWallet.Balance += topUp.Money;
			Customer.UpdateDate = transactions.CreateDate;
			topUp.IsUsed = true;
			_context.SaveChanges();

			return true;			
		}
		public bool Payment(string emailSender, double money, string emailReceive)
		{
			
			var customer = _context.Users.Include(x=>x.AccountEWallet).FirstOrDefault(x => x.Email == emailSender);
			if (customer == null)
			{
				return false;
			}
			var marchant = _context.Marchants.Include(x => x.AccountEWallet).FirstOrDefault(x => x.Email == emailReceive);
			if (marchant == null)
			{
				return false;
			}
			var marchantAccount = _context.AccountEWallets.FirstOrDefault(x => x.Email == emailReceive);
			if (marchantAccount == null)
			{
				return false;
			}
			string UpperId = (DateTime.Now.Year+""+ DateTime.Now.Month+""+ DateTime.Now.Date).ToString();
			int MidId = random.Next(100, 999);
			int LowperId = random.Next(1000, 9999);
			string idPaymaent = UpperId + MidId.ToString() + LowperId.ToString();
			Transactions transactions = new Transactions()
			{
				CreateDate = DateTime.Now,
				IsDelete = false,
				Money = money,
				ReceiveTransaction = Enums.Transactions.Receive,
				SenderTransaction = Enums.Transactions.Paymant,
				RefNo = "P"+ idPaymaent,
				Receive = customer.AccountEWallet,
				Sender = marchantAccount,
				UpdateDate = DateTime.Now,
				UpdateBy = customer.Id
			};
			_context.Transactions.Add(transactions);
			customer.AccountEWallet.Balance -= money;
			customer.UpdateDate = transactions.CreateDate;
		    marchantAccount.Balance += money;
			marchantAccount.UpdateDate = transactions.CreateDate;
			_context.SaveChanges();
			return true;
		}
		public bool CheckTopUp(string refno)
		{
			var topUp = _context.GenrateTopUp.FirstOrDefault(x => x.RefNo == refno);
			//var Customer = _context.Users.FirstOrDefault(x => x.Email == emailReceive);
			if (topUp.ExpireDate >= DateTime.Now)
			{
				return true;
			}
			return false;
		}
	}
}

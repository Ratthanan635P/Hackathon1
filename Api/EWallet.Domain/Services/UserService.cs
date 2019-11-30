using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using EWallet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWallet.Domain.Services
{
	public class UserService : IUserService
	{
		private IUserRepository userRepository;
		public UserService(IUserRepository userRepository)
		{
			this.userRepository = userRepository;

		}
		public bool ChangePassword(string email, string password, string newpassword)
		{
			bool result = userRepository.ChangePassword(email, password, newpassword);
			return result;
		}

		public double CheckBalance(string email)
		{
			double result = userRepository.CheckBalance(email);
			return result;
		}



		public bool CheckUserAccount(string email)
		{
			bool result = userRepository.CheckUserAccount(email);
			return result;
		}

		public bool EditDataUser(DetailUserAccountDto data)
		{
			var result = userRepository.EditDataUser(data);			
			return result;
		}

		public DetailUserAccountDto GetDataUser(string email)
		{
			var result = userRepository.GetDataUser(email);
			DetailUserAccountDto detailUser = new DetailUserAccountDto()
			{
				AccountEWallet=result.AccountEWallet,
				BrithDate=result.BrithDate,
				Email=result.Email,
				FristName=result.FristName,
				ImageBackground=result.ImageBackground,
				LastName=result.LastName,
				Phone=result.Phone
            };
			return detailUser;
		}

		public List<Transactions> History(string email)
		{
			var result = userRepository.History(email);
			return result;
			//var result1 = result.GroupBy(x=>x.CreateDate.Month).ToList();
		}

		public DetailUserAccountDto LogIn(string email, string password)
		{
			var result = userRepository.LogIn(email,password);
			DetailUserAccountDto detailUser = new DetailUserAccountDto()
			{
				AccountEWallet = result.AccountEWallet,
				BrithDate = result.BrithDate,
				Email = result.Email,
				FristName = result.FristName,
				ImageBackground = result.ImageBackground,
				LastName = result.LastName,
				Phone = result.Phone
			};
			return detailUser;
		}

		public bool LogOut(string email)
		{
			//throw new NotImplementedException();
			var result = userRepository.LogOut(email);
			return result;
		}


		public bool Register(RegisterUserDto registerUserDto)
		{
			
			var result = userRepository.Register(registerUserDto);
			return result;
		}

		public bool TopUp(string emailSender, string refno, string emailReceive)
		{
			var result = userRepository.TopUp(emailSender, refno, emailReceive);
			return result;
		}
		public bool Payment(string emailSender, double money, string emailReceive)
		{
			var result = userRepository.Payment(emailSender,money,emailReceive);
			return result;
		}
		public bool CheckTopUp(string refno)
		{
			var result = userRepository.CheckTopUp(refno);
			return result;
		}
	}
}

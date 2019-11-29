﻿using EWallet.Domain.Dtos;
using EWallet.Domain.Entities;
using EWallet.Domain.Interfaces.Repositories;
using EWallet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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
	}
}

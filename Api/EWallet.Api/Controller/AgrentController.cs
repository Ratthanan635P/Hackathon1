using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWallet.Api.Functions;
using EWallet.Api.Models;
using EWallet.Api.Models.Commands;
using EWallet.Domain.Dtos;
using EWallet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EWallet.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class AgrentController : ControllerBase
    {
		private IAgrentService _agrentService;
		private ValidateMethods validateMethods;
		public AgrentController(IAgrentService _agrentService)
		{
			this._agrentService = _agrentService;
			validateMethods = new ValidateMethods();
		}
		//[AllowAnonymous]
		[HttpPost("LogIn")]
		public IActionResult LogInUser([FromBody]AuthenticateModel model)
		{
			string error = "";
			if (string.IsNullOrEmpty(model.Email))
			{
				error = " Email is null";
				return BadRequest(new { message = error });
			}
			if (string.IsNullOrEmpty(model.Password))
			{
				error = " Password is null";
				return BadRequest(new { message = error });
			}
			if (!((validateMethods.CheckRegEx_UserName(model.Email)) && (model.Email.Length > validateMethods.LengthEmail) && (model.Email.Length < 50)))
			{
				error = " Email is Invalid!";
				return BadRequest(new { message = error });
			}
			if (!((validateMethods.CheckRegEx_Password(model.Password)) && (model.Password.Length > validateMethods.LengthPassword) && (model.Password.Length < 50)))
			{
				if (error != "")
				{
					error = " Email and Password is Invalid! ";
					return BadRequest(new { message = error });
				}
				else
				{
					error = " Password is Invalid!";
					return BadRequest(new { message = error });
				}
			}

			//Call Api Check email and Password

			if (error == "")
			{
				try
				{
					var user = _agrentService.LogIn(model.Email, model.Password);
					if (user == null)
						return BadRequest(new { message = "Not Found" });
					return Ok(user);
				}
				catch (Exception ex)
				{
					error = ex.Message;
				}
				return BadRequest(new { message = error });
			}
			else
			{
				return BadRequest(new { message = error });

			}

		}
		[HttpPost("History")]
		public IActionResult History([FromBody]string email)
		{
			string error = "";
			if (string.IsNullOrEmpty(email))
			{
				error = " Email is null";
				return BadRequest(new { message = error });
			}
			if (!((validateMethods.CheckRegEx_UserName(email)) && (email.Length > validateMethods.LengthEmail) && (email.Length < 50)))
			{
				error = " Email is Invalid!";
				return BadRequest(new { message = error });
			}


			//Call Api Check email and Password

			if (error == "")
			{
				try
				{
					var user = _agrentService.History(email);
					if (user == null)
						return BadRequest(new { message = "Not Found" });
					return Ok(user);
				}
				catch (Exception ex)
				{
					error = ex.Message;
				}
				return BadRequest(new { message = error });
			}
			else
			{
				return BadRequest(new { message = error });

			}

		}
		[HttpPost("TopUp")]
		public IActionResult TopUp([FromBody]GenTopUpModel model)
		{
			string error = "";
			//if (string.IsNullOrEmpty(email))
			//{
			//	error = " Email is null";
			//	return BadRequest(new { message = error });
			//}
			//if (!((validateMethods.CheckRegEx_UserName(email)) && (email.Length > validateMethods.LengthEmail) && (email.Length < 50)))
			//{
			//	error = " Email is Invalid!";
			//	return BadRequest(new { message = error });
			//}


			//Call Api Check email and Password

			if (error == "")
			{
				try
				{
					var user = _agrentService.GenarateTopup(model.Money,model.AgrentId);
					if (user == null)
						return BadRequest(new { message = "Not Found" });
					return Ok(user);
				}
				catch (Exception ex)
				{
					error = ex.Message;
				}
				return BadRequest(new { message = error });
			}
			else
			{
				return BadRequest(new { message = error });

			}

		}
		//[HttpPost("LogOut")]
		//public IActionResult LogOut([FromBody]string email)
		//{
		//	string error = "";
		//	RespondModel respond = new RespondModel();
		//	if (string.IsNullOrEmpty(email))
		//	{
		//		error = " Email is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_UserName(email)) && (email.Length > validateMethods.LengthEmail) && (email.Length < 50)))
		//	{
		//		error = " Email is Invalid!";
		//		return BadRequest(new { message = error });
		//	}


		//	//Call Api Check email and Password

		//	if (error == "")
		//	{
		//		try
		//		{
		//			respond.Status = _agrentService(email);
		//			if (respond.Status == false)
		//				return BadRequest(new { message = "" });
		//			return Ok(respond);
		//		}
		//		catch (Exception ex)
		//		{
		//			error = ex.Message;
		//		}
		//		return BadRequest(new { message = error });
		//	}
		//	else
		//	{
		//		return BadRequest(new { message = error });

		//	}
		//}
		////[AllowAnonymous]
		//[HttpPost("Register")]
		//public IActionResult Register([FromBody]RegisterModel model)
		//{
		//	string error = "";
		//	if (string.IsNullOrEmpty(model.Email))
		//	{
		//		error = " Email is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (string.IsNullOrEmpty(model.Password))
		//	{
		//		error = " Password is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_UserName(model.Email)) && (model.Email.Length > validateMethods.LengthEmail) && (model.Email.Length < 50)))
		//	{
		//		error = " Email is Invalid!";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_Password(model.Password)) && (model.Password.Length > validateMethods.LengthPassword) && (model.Password.Length < 50)))
		//	{
		//		if (error != "")
		//		{
		//			error = " Email and Password is Invalid! ";
		//			return BadRequest(new { message = error });
		//		}
		//		else
		//		{
		//			error = " Password is Invalid!";
		//			return BadRequest(new { message = error });
		//		}
		//	}
		//	//vaildate  data
		//	//Call Api Check email and Password

		//	if (error == "")
		//	{
		//		try
		//		{
		//			RegisterUserDto register = new RegisterUserDto()
		//			{
		//				Email = model.Email,
		//				BrithDate = model.BrithDate,
		//				Phone = model.Phone,
		//				FristName = model.FristName,
		//				LastName = model.LastName,
		//				Password = model.LastName,
		//				Salt = "vfvfvfvfvfffvff4thrfwtetjyt"
		//			};
		//			var user = _agrentService.Register(register);
		//			if (user == false)
		//				return BadRequest(new { message = "fail" });
		//			return Ok(user);
		//		}
		//		catch (Exception ex)
		//		{
		//			error = ex.Message;
		//		}
		//		return BadRequest(new { message = error });
		//	}
		//	else
		//	{
		//		return BadRequest(new { message = error });

		//	}

		//}
		//[HttpPost("GetData")]
		//public IActionResult GetData([FromBody]string email)
		//{
		//	string error = "";
		//	if (string.IsNullOrEmpty(email))
		//	{
		//		error = " Email is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_UserName(email)) && (email.Length > validateMethods.LengthEmail) && (email.Length < 50)))
		//	{
		//		error = " Email is Invalid!";
		//		return BadRequest(new { message = error });
		//	}

		//	//Call Api Check email and Password

		//	if (error == "")
		//	{
		//		try
		//		{
		//			var user = _agrentService.(email);
		//			if (user == null)
		//				return BadRequest(new { message = "Not Found" });
		//			return Ok(user);
		//		}
		//		catch (Exception ex)
		//		{
		//			error = ex.Message;
		//		}
		//		return BadRequest(new { message = error });
		//	}
		//	else
		//	{
		//		return BadRequest(new { message = error });

		//	}

		//}
		//[HttpPost("ChangePassword")]
		//public IActionResult ChangePSW([FromBody]ChangePasswordModel model)
		//{
		//	string error = "";
		//	if (string.IsNullOrEmpty(model.Email))
		//	{
		//		error = " Email is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_UserName(model.Email)) && (model.Email.Length > validateMethods.LengthEmail) && (model.Email.Length < 50)))
		//	{
		//		error = " Email is Invalid!";
		//		return BadRequest(new { message = error });
		//	}
		//	if (string.IsNullOrEmpty(model.Password))
		//	{
		//		error = " Password is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_Password(model.Password)) && (model.Password.Length > validateMethods.LengthPassword) && (model.Password.Length < 50)))
		//	{
		//		error = " Password is Invalid!";
		//		return BadRequest(new { message = error });
		//	}
		//	if (string.IsNullOrEmpty(model.NewPassword))
		//	{
		//		error = "New Password is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_Password(model.NewPassword)) && (model.NewPassword.Length > validateMethods.LengthPassword) && (model.NewPassword.Length < 50)))
		//	{
		//		error = "New Password is Invalid!";
		//		return BadRequest(new { message = error });
		//	}
		//	//Call Api Check email and Password

		//	if (error == "")
		//	{
		//		try
		//		{
		//			var user = _agrentService.ChangePassword(model.Email, model.Password, model.NewPassword);
		//			if (user == false)
		//				return BadRequest(new { message = "fail" });
		//			return Ok(user);
		//		}
		//		catch (Exception ex)
		//		{
		//			error = ex.Message;
		//		}
		//		return BadRequest(new { message = error });
		//	}
		//	else
		//	{
		//		return BadRequest(new { message = error });

		//	}

		//}
		//double CheckBalance(string email);
		//[AllowAnonymous]
		//[HttpPost("CheckAccount")]
		//public IActionResult CheckAccount([FromBody]string email)
		//{
		//	string error = "";
		//	//string email = "";
		//	RespondModel respond = new RespondModel();
		//	if (string.IsNullOrEmpty(email))
		//	{
		//		error = " Email is null";
		//		return BadRequest(new { message = error });
		//	}
		//	if (!((validateMethods.CheckRegEx_UserName(email)) && (email.Length > validateMethods.LengthEmail) && (email.Length < 50)))
		//	{
		//		error = " Email is Invalid!";
		//		return BadRequest(new { message = error });
		//	}


		//	//Call Api Check email and Password

		//	if (error == "")
		//	{
		//		try
		//		{
		//			respond.Status = _agrentService(email);
		//			if (respond.Status == false)
		//				return BadRequest(new { message = "" });
		//			return Ok(respond);
		//		}
		//		catch (Exception ex)
		//		{
		//			error = ex.Message;
		//		}
		//		return BadRequest(new { message = error });
		//	}
		//	else
		//	{
		//		return BadRequest(new { message = error });

		//	}
		//}
	}
}
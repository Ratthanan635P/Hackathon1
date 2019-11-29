using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWallet.Api.Functions;
using EWallet.Api.Models;
using EWallet.Api.Models.Commands;
using EWallet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EWallet.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarchantController : ControllerBase
    {
		private IMarchantService _marchantService;
		private ValidateMethods validateMethods;
		public MarchantController(IMarchantService _marchantService)
		{
			this._marchantService = _marchantService;
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
					var user = _marchantService.LogIn(model.Email, model.Password);
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
					var user = _marchantService.History(email);
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
		//[HttpPost("TopUp")]
		//public IActionResult TopUp([FromBody]TopUpModel model)
		//{
		//	string error = "";
		//	//if (string.IsNullOrEmpty(email))
		//	//{
		//	//	error = " Email is null";
		//	//	return BadRequest(new { message = error });
		//	//}
		//	//if (!((validateMethods.CheckRegEx_UserName(email)) && (email.Length > validateMethods.LengthEmail) && (email.Length < 50)))
		//	//{
		//	//	error = " Email is Invalid!";
		//	//	return BadRequest(new { message = error });
		//	//}


		//	//Call Api Check email and Password

		//	if (error == "")
		//	{
		//		try
		//		{
		//			var user = _marchantService.GenarateTopup(model.Money, model.AgrentId);
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
	}
}
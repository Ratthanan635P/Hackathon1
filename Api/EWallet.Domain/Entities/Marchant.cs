﻿using EWallet.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class Marchant : BaseEntities
	{
		public byte[] ImageProfile { get; set; }
		public string NameShop { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public Enums.Status Active { get; set; }
		public DateTime ActiveDateTime { get; set; }
		// FK AccountID 
		public AccountEWallet AccountEWallet { get; set; }
		
	}
}

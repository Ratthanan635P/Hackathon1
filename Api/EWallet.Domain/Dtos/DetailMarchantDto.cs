using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Dtos
{
	public class DetailMarchantDto
	{
		public int Id { get; set; }
		public string NameShop { get; set; }
		// FK AccountID 
		public AccountEWallet AccountEWallet { get; set; }
	}
}

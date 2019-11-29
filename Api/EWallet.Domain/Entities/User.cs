using EWallet.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class User:BaseEntities
	{
		public byte[] ImageBackground { get; set; }
		public string FristName { get; set; }
		public string LastName { get; set; }
		public DateTime BrithDate { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public bool FingerPrintStattus { get; set; }

		// FK AccountID 
		public AccountEWallet AccountEWallet { get; set; }
		public Enums.Status Active { get; set; }
		public DateTime ActiveDateTime { get; set; }		
		
	}
}

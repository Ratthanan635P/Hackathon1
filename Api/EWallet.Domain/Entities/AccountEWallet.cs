﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class AccountEWallet
	{
		// PK ID 
		public int Id { get; set; }
		public string AccountWallet { get; set; }
		public string Email { get; set; }
		public double Balance { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateBy { get; set; }
		public bool IsDelete { get; set; }
		public ICollection<Transactions> TransactionReceive { get; set; }
		public ICollection<Transactions> TransactionSender { get; set; }
	}
}

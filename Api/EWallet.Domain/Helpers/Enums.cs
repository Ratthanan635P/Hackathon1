﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Helpers
{
	public class Enums
	{
		public enum Status
		{
			Active = 1,
			InActive = 2,
		}
		public enum Transactions
		{
			TopUp = 1,
			Paymant = 2,
			Receive=3
		}
	}
}

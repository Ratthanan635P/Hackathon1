﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class GenrateTopUp:BaseEntities
	{
		public string RefNo { get; set; }
		public Agrent Agrent { get; set; }
		public DateTime ExpireDate { get; set; }
		public double Money { get; set; }
		public bool IsUsed { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class BaseEntities
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateBy { get; set; }
		public bool IsDelete { get; set; }
	}
}

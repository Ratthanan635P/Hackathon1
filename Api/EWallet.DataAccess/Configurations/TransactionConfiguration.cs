using EWallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace EWallet.DataAccess.Configurations
{
	public class TransactionConfiguration : IEntityTypeConfiguration<Transactions>
	{
		public void Configure(EntityTypeBuilder<Transactions> builder)
		{
			//	throw new NotImplementedException();
			//builder.HasOne(x => x.TransactionInformation).WithMany(x => x.).HasForeignKey(x => x.);
			builder.HasOne(x => x.Sender).WithMany(x=>x.TransactionSender);
			builder.HasOne(x => x.Receive).WithMany(x=>x.TransactionReceive);		

		}
	}
}

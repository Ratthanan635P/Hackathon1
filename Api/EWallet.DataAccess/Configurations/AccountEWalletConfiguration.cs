using EWallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAccess.Configurations
{
	public class AccountEWalletConfiguration : IEntityTypeConfiguration<AccountEWallet>
	{
		public void Configure(EntityTypeBuilder<AccountEWallet> builder)
		{		
			builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
			builder.Property(x => x.AccountWallet).HasMaxLength(50).IsRequired();
			builder.Property(x => x.UpdateDate).IsRequired(true);
			builder.Property(x => x.UpdateBy).IsRequired(true);
		}
	}
}

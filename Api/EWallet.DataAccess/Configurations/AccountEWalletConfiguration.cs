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
			//
		}
	}
}

using EWallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAccess.Configurations
{
	public class GenrateTopUpConfiguration : IEntityTypeConfiguration<GenrateTopUp>
	{
		public void Configure(EntityTypeBuilder<GenrateTopUp> builder)
		{
			builder.Property(x => x.RefNo).HasMaxLength(250).IsRequired();

		}
	}
}

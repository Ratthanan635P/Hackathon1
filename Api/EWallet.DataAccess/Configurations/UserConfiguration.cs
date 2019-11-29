using EWallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAccess.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
			builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
			builder.Property(x => x.Phone).HasMaxLength(20).IsRequired();
			builder.Property(x => x.FristName).HasMaxLength(50).IsRequired();
			builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
			builder.Property(x => x.Salt).HasMaxLength(50).IsRequired();

		}
	}
}

using EWallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAccess.Configurations
{
	public class UserOTPConfiguration : IEntityTypeConfiguration<UserOTP>
	{
		public void Configure(EntityTypeBuilder<UserOTP> builder)
		{
			builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
			builder.Property(x => x.OTP).HasMaxLength(50).IsRequired();
			
		}
	}
}

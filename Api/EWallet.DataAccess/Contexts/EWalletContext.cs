using EWallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EWallet.DataAccess.Contexts
{
	public class EWalletContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Agrent> Agrents { get; set; }
		public DbSet<Marchant> Marchants { get; set; }
		public DbSet<GenrateTopUp> GenrateTopUp { get; set; }
		public DbSet<Transactions> Transactions { get; set; }
		public DbSet<UserOTP> UserOTPs { get; set; }


		private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(config => config.AddConsole());
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLoggerFactory(loggerFactory).UseSqlServer("Server=localhost;Database=EWalletDB;Trusted_Connection=True;Integrated Security = false;User Id =sa;Password=yourStrong(!)Password");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		//	modelBuilder.Entity<Transaction>()
		
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			modelBuilder.Entity<User>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
			modelBuilder.Entity<Marchant>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
			modelBuilder.Entity<Agrent>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
			modelBuilder.Entity<AccountEWallet>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
			modelBuilder.Entity<Transactions>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
		}
	}
}

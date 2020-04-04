using System;
using System.Data.Common;
using JetBrains.Annotations;
using Lykke.Common.MsSql;
using MAVN.Service.Referral.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;
using ReferralHotelState = Lykke.Service.Referral.MsSqlRepositories.Entities.ReferralHotelState;

namespace MAVN.Service.Referral.MsSqlRepositories
{
    public class ReferralContext : MsSqlContext
    {
        private const string Schema = "referral";

        public DbSet<ReferralEntity> Referrals { get; set; }
        public DbSet<FriendReferralEntity> FriendReferrals { get; set; }
        public DbSet<PurchaseReferralHistoryEntity> PurchaseReferrals { get; set; }
        public DbSet<ReferralLeadEntity> ReferralLeads { get; set; }
        public DbSet<PropertyPurchaseEntity> PropertyPurchases { get; set; }
        public DbSet<OfferToPurchaseEntity> OfferToPurchases { get; set; }
        public DbSet<ReferralHotelEntity> ReferralHotels { get; set; }

        // C-tor for EF migrations
        [UsedImplicitly]
        public ReferralContext()
            : base(Schema)
        {
        }

        public ReferralContext(DbContextOptions contextOptions) 
            : base(Schema, contextOptions)
        {
        }

        public ReferralContext(string schema, DbContextOptions contextOptions)
            : base(schema, contextOptions)
        {
        }

        public ReferralContext(string connectionString, bool isTraceEnabled) 
            : base(Schema, connectionString, isTraceEnabled)
        {
        }

        public ReferralContext(DbConnection dbConnection)
            : base(Schema, dbConnection)
        {
        }

        protected override void OnLykkeModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReferralEntity>()
                .HasIndex(b => b.ReferralCode)
                .IsUnique();

            modelBuilder.Entity<ReferralEntity>()
                .HasMany(e => e.PurchasesReferred)
                .WithOne(e => e.Referred)
                .HasForeignKey(e => e.ReferredId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReferralEntity>()
                .HasMany(e => e.PurchaseReferrers)
                .WithOne(e => e.Referrer)
                .HasForeignKey(e => e.ReferrerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReferralLeadEntity>()
                .HasMany(e => e.OffersToPurchase)
                .WithOne()
                .HasForeignKey(e => e.ReferId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReferralLeadEntity>()
                .HasMany(e => e.PropertyPurchases)
                .WithOne()
                .HasForeignKey(e => e.ReferralLeadId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder
                .Entity<ReferralHotelEntity>()
                .Property(e => e.State)
                .HasConversion(
                    v => v.ToString(),
                    v => (ReferralHotelState)Enum.Parse(typeof(ReferralHotelState), v));

            modelBuilder
                .Entity<ReferralHotelEntity>()
                .HasIndex(x => x.EmailHash);
            
            modelBuilder
                .Entity<ReferralHotelEntity>()
                .HasIndex(x => x.ReferrerId);
            
            modelBuilder
                .Entity<ReferralHotelEntity>()
                .HasIndex(x => x.ConfirmationToken);
        }
    }
}

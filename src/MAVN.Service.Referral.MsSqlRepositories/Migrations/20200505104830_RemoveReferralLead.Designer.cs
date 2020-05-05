﻿// <auto-generated />
using System;
using MAVN.Service.Referral.MsSqlRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAVN.Service.Referral.MsSqlRepositories.Migrations
{
    [DbContext(typeof(ReferralContext))]
    [Migration("20200505104830_RemoveReferralLead")]
    partial class RemoveReferralLead
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("referral")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAVN.Service.Referral.MsSqlRepositories.Entities.FriendReferralEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<Guid>("CampaignId")
                        .HasColumnName("campaign_id");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnName("creation_datetime");

                    b.Property<Guid?>("ReferredId")
                        .HasColumnName("referred_id");

                    b.Property<Guid>("ReferrerId")
                        .HasColumnName("referrer_id");

                    b.Property<int>("State")
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.ToTable("friend_referral");
                });

            modelBuilder.Entity("MAVN.Service.Referral.MsSqlRepositories.Entities.PurchaseReferralHistoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<Guid>("ReferredId")
                        .HasColumnName("referred_id");

                    b.Property<Guid>("ReferrerId")
                        .HasColumnName("referrer_id");

                    b.HasKey("Id");

                    b.HasIndex("ReferredId");

                    b.HasIndex("ReferrerId");

                    b.ToTable("purchase_referral");
                });

            modelBuilder.Entity("MAVN.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("customer_id");

                    b.Property<string>("ReferralCode")
                        .HasColumnName("referral_code")
                        .HasColumnType("varchar(64)");

                    b.HasKey("CustomerId");

                    b.HasIndex("ReferralCode")
                        .IsUnique()
                        .HasFilter("[referral_code] IS NOT NULL");

                    b.ToTable("customer_referral");
                });

            modelBuilder.Entity("MAVN.Service.Referral.MsSqlRepositories.Entities.ReferralHotelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<Guid?>("CampaignId")
                        .HasColumnName("campaign_id");

                    b.Property<string>("ConfirmationToken")
                        .HasColumnName("confirmation_token");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnName("creation_datetime");

                    b.Property<string>("EmailHash")
                        .HasColumnName("email_hash")
                        .HasColumnType("char(64)");

                    b.Property<DateTime>("ExpirationDateTime")
                        .HasColumnName("expiration_datetime");

                    b.Property<string>("FullNameHash")
                        .HasColumnName("name_hash")
                        .HasColumnType("char(64)");

                    b.Property<string>("Location")
                        .HasColumnName("location");

                    b.Property<string>("PartnerId")
                        .HasColumnName("partner_id");

                    b.Property<int>("PhoneCountryCodeId")
                        .HasColumnName("phone_country_code_id");

                    b.Property<string>("PhoneNumberHash")
                        .HasColumnName("phone_number_hash")
                        .HasColumnType("char(64)");

                    b.Property<string>("ReferrerId")
                        .HasColumnName("referrer_id");

                    b.Property<bool>("StakeEnabled")
                        .HasColumnName("stake_enabled");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmationToken");

                    b.HasIndex("EmailHash");

                    b.HasIndex("ReferrerId");

                    b.ToTable("referral_hotel");
                });

            modelBuilder.Entity("MAVN.Service.Referral.MsSqlRepositories.Entities.PurchaseReferralHistoryEntity", b =>
                {
                    b.HasOne("MAVN.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", "Referred")
                        .WithMany("PurchasesReferred")
                        .HasForeignKey("ReferredId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MAVN.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", "Referrer")
                        .WithMany("PurchaseReferrers")
                        .HasForeignKey("ReferrerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Lykke.Service.Referral.MsSqlRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lykke.Service.Referral.MsSqlRepositories.Migrations
{
    [DbContext(typeof(ReferralContext))]
    [Migration("20190612131530_AddPropertyPurchase")]
    partial class AddPropertyPurchase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("referral")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.ApprovedReferralLeadEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<Guid>("ReferralLeadId")
                        .HasColumnName("refer_lead_id");

                    b.Property<string>("SalesforceId")
                        .HasColumnName("salesforce_id")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("timestamp");

                    b.HasKey("Id");

                    b.ToTable("approved_referral_lead");
                });

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.FriendReferralHistoryEntity", b =>
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

                    b.ToTable("friend_referral");
                });

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.PropertyPurchaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<Guid>("ReferralLeadId")
                        .HasColumnName("refer_lead_id");

                    b.Property<string>("SalesforceId")
                        .HasColumnName("salesforce_id")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("timestamp");

                    b.HasKey("Id");

                    b.ToTable("property_purchase");
                });

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.PurchaseReferralHistoryEntity", b =>
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

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ReferralCode")
                        .HasColumnName("referral_code")
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("ReferralCode")
                        .IsUnique()
                        .HasFilter("[referral_code] IS NOT NULL");

                    b.ToTable("customer_referral");
                });

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.ReferralLeadEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnName("creation_datetime");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Note")
                        .HasColumnName("note")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ReferrerId")
                        .HasColumnName("referrer_id");

                    b.Property<string>("SalesforceId")
                        .HasColumnName("salesforce_id")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("referral_lead");
                });

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.FriendReferralHistoryEntity", b =>
                {
                    b.HasOne("Lykke.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", "Referred")
                        .WithMany("FriendsReferred")
                        .HasForeignKey("ReferredId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Lykke.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", "Referrer")
                        .WithMany("FriendReferrers")
                        .HasForeignKey("ReferrerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Lykke.Service.Referral.MsSqlRepositories.Entities.PurchaseReferralHistoryEntity", b =>
                {
                    b.HasOne("Lykke.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", "Referred")
                        .WithMany("PurchasesReferred")
                        .HasForeignKey("ReferredId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Lykke.Service.Referral.MsSqlRepositories.Entities.ReferralEntity", "Referrer")
                        .WithMany("PurchaseReferrers")
                        .HasForeignKey("ReferrerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

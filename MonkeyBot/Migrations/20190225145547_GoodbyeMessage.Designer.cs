﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonkeyBot.Database;

namespace MonkeyBot.Migrations
{
    [DbContext(typeof(MonkeyDBContext))]
    [Migration("20190225145547_GoodbyeMessage")]
    partial class GoodbyeMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("MonkeyBot.Database.Entities.AnnouncementEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("ChannelId");

                    b.Property<string>("CronExpression");

                    b.Property<DateTime?>("ExecutionTime");

                    b.Property<ulong>("GuildId");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("MonkeyBot.Database.Entities.BenzenFactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fact");

                    b.HasKey("Id");

                    b.ToTable("BenzenFacts");
                });

            modelBuilder.Entity("MonkeyBot.Database.Entities.FeedEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("ChannelId");

                    b.Property<ulong>("GuildId");

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("URL")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("MonkeyBot.Database.Entities.GameServerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("ChannelId");

                    b.Property<string>("GameServerType")
                        .IsRequired();

                    b.Property<string>("GameVersion");

                    b.Property<ulong>("GuildId");

                    b.Property<string>("IPAsString")
                        .IsRequired()
                        .HasColumnName("IP");

                    b.Property<DateTime?>("LastVersionUpdate");

                    b.Property<ulong?>("MessageId");

                    b.HasKey("Id");

                    b.ToTable("GameServers");
                });

            modelBuilder.Entity("MonkeyBot.Database.Entities.GameSubscriptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameName")
                        .IsRequired();

                    b.Property<ulong>("GuildId");

                    b.Property<ulong>("UserId");

                    b.HasKey("Id");

                    b.ToTable("GameSubscriptions");
                });

            modelBuilder.Entity("MonkeyBot.Database.Entities.GuildConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommandPrefix")
                        .IsRequired();

                    b.Property<ulong>("GoodbyeMessageChannelId");

                    b.Property<string>("GoodbyeMessageText");

                    b.Property<ulong>("GuildId");

                    b.Property<string>("RulesAsString")
                        .HasColumnName("Rules");

                    b.Property<ulong>("WelcomeMessageChannelId");

                    b.Property<string>("WelcomeMessageText");

                    b.HasKey("Id");

                    b.ToTable("GuildConfigs");
                });

            modelBuilder.Entity("MonkeyBot.Database.Entities.RoleButtonLinkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmoteString")
                        .IsRequired();

                    b.Property<ulong>("GuildId");

                    b.Property<ulong>("MessageId");

                    b.Property<ulong>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleButtonLinks");
                });

            modelBuilder.Entity("MonkeyBot.Database.Entities.TriviaScoreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("GuildId");

                    b.Property<int>("Score");

                    b.Property<ulong>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TriviaScores");
                });
#pragma warning restore 612, 618
        }
    }
}

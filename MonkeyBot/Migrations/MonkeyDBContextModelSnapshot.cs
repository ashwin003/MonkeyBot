﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonkeyBot.Database;

namespace MonkeyBot.Migrations
{
    [DbContext(typeof(MonkeyDBContext))]
    partial class MonkeyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("MonkeyBot.Models.Announcement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("ChannelID");

                    b.Property<string>("CronExpression");

                    b.Property<DateTime?>("ExecutionTime");

                    b.Property<ulong>("GuildID");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("MonkeyBot.Models.BenzenFact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fact")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("BenzenFacts");
                });

            modelBuilder.Entity("MonkeyBot.Models.Feed", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("ChannelID");

                    b.Property<ulong>("GuildID");

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("URL")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("MonkeyBot.Models.GameServer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("ChannelID");

                    b.Property<string>("GameServerType")
                        .IsRequired();

                    b.Property<string>("GameVersion");

                    b.Property<ulong>("GuildID");

                    b.Property<DateTime?>("LastVersionUpdate");

                    b.Property<ulong?>("MessageID");

                    b.Property<string>("ServerIP")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("GameServers");
                });

            modelBuilder.Entity("MonkeyBot.Models.GameSubscription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameName")
                        .IsRequired();

                    b.Property<ulong>("GuildID");

                    b.Property<ulong>("UserID");

                    b.HasKey("ID");

                    b.ToTable("GameSubscriptions");
                });

            modelBuilder.Entity("MonkeyBot.Models.GuildConfig", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("BattlefieldUpdatesChannel");

                    b.Property<bool>("BattlefieldUpdatesEnabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("CommandPrefix")
                        .IsRequired();

                    b.Property<string>("ConfirmedStreamerIds");

                    b.Property<ulong>("DefaultChannelId");

                    b.Property<ulong>("GoodbyeMessageChannelId");

                    b.Property<string>("GoodbyeMessageText");

                    b.Property<ulong>("GuildID");

                    b.Property<DateTime?>("LastBattlefieldUpdate");

                    b.Property<string>("Rules");

                    b.Property<bool>("StreamAnnouncementsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<ulong>("WelcomeMessageChannelId");

                    b.Property<string>("WelcomeMessageText");

                    b.HasKey("ID");

                    b.ToTable("GuildConfigs");
                });

            modelBuilder.Entity("MonkeyBot.Models.RoleButtonLink", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmoteString")
                        .IsRequired();

                    b.Property<ulong>("GuildID");

                    b.Property<ulong>("MessageID");

                    b.Property<ulong>("RoleID");

                    b.HasKey("ID");

                    b.ToTable("RoleButtonLinks");
                });

            modelBuilder.Entity("MonkeyBot.Models.TriviaScore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("GuildID");

                    b.Property<int>("Score");

                    b.Property<ulong>("UserID");

                    b.HasKey("ID");

                    b.ToTable("TriviaScores");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CodeChatApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodeChatApp.Migrations
{
    [DbContext(typeof(CodeChatContext))]
    [Migration("20190406064745_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:PostgresExtension:citext", "'citext', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CodeChatApp.Database.Models.Chat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.CodeChat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ChatId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("CodeChats");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.EventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("citext");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnName("event")
                        .HasMaxLength(16);

                    b.Property<DateTime>("EventTime")
                        .HasColumnName("event_time");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnName("ip")
                        .HasMaxLength(16);

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnName("user_agent");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("citext");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Username");

                    b.ToTable("event_log");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ChatId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("Time");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserName");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.ReceivedEmail", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("citext");

                    b.HasKey("Email");

                    b.ToTable("received_email");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.UserChat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ChatId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserName");

                    b.ToTable("UserChats");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.Users", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("citext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("citext");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnName("hash")
                        .HasMaxLength(128);

                    b.Property<string>("PhotoUrl");

                    b.HasKey("Username");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("email_idx");

                    b.ToTable("users");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.CodeChat", b =>
                {
                    b.HasOne("CodeChatApp.Database.Models.Chat", "Chat")
                        .WithMany("CodeChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.EventLog", b =>
                {
                    b.HasOne("CodeChatApp.Database.Models.Users", "EmailNavigation")
                        .WithMany("EventLogEmailNavigation")
                        .HasForeignKey("Email")
                        .HasConstraintName("event_log_email_fkey")
                        .HasPrincipalKey("Email");

                    b.HasOne("CodeChatApp.Database.Models.Users", "UsernameNavigation")
                        .WithMany("EventLogUsernameNavigation")
                        .HasForeignKey("Username")
                        .HasConstraintName("event_log_username_fkey");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.Message", b =>
                {
                    b.HasOne("CodeChatApp.Database.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CodeChatApp.Database.Models.Users", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("CodeChatApp.Database.Models.UserChat", b =>
                {
                    b.HasOne("CodeChatApp.Database.Models.Chat", "Chat")
                        .WithMany("UserChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CodeChatApp.Database.Models.Users", "User")
                        .WithMany("UserChats")
                        .HasForeignKey("UserName");
                });
#pragma warning restore 612, 618
        }
    }
}

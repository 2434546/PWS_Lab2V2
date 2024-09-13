﻿// <auto-generated />
using ForumDeDiscussion.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumDeDiscussion.Migrations
{
    [DbContext(typeof(ForumDeDiscussionDbContext))]
    partial class ForumDeDiscussionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ForumDeDiscussion.Models.Membre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("membre");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MembreId")
                        .HasColumnType("int");

                    b.Property<int>("SujetId")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MembreId");

                    b.HasIndex("SujetId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("sections");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Sujet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("sujets");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Message", b =>
                {
                    b.HasOne("ForumDeDiscussion.Models.Membre", "Membre")
                        .WithMany("Messages")
                        .HasForeignKey("MembreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForumDeDiscussion.Models.Sujet", "Sujet")
                        .WithMany("Messages")
                        .HasForeignKey("SujetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membre");

                    b.Navigation("Sujet");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Sujet", b =>
                {
                    b.HasOne("ForumDeDiscussion.Models.Section", "Section")
                        .WithMany("Sujets")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Membre", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Section", b =>
                {
                    b.Navigation("Sujets");
                });

            modelBuilder.Entity("ForumDeDiscussion.Models.Sujet", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}

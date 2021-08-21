﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vue.TodoApp;

namespace vue.todo.app.api.Migrations
{
    [DbContext(typeof(TodoAppContext))]
    [Migration("20210812171206_taskDeletedFlag")]
    partial class taskDeletedFlag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Vue.TodoApp.Model.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Important")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ListId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Vue.TodoApp.Model.TaskList", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("Vue.TodoApp.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1d41604-2ee8-4065-aca4-aa86f025bbf4"),
                            Email = "admin@mail.com",
                            Name = "Admin",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("Vue.TodoApp.Model.Task", b =>
                {
                    b.HasOne("Vue.TodoApp.Model.TaskList", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue.TodoApp.Model.User", null)
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vue.TodoApp.Model.TaskList", b =>
                {
                    b.HasOne("Vue.TodoApp.Model.User", null)
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vue.TodoApp.Model.TaskList", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Vue.TodoApp.Model.User", b =>
                {
                    b.Navigation("Lists");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}

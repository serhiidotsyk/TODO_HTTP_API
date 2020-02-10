﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TODO_HTTP_API.DataAcceess;

namespace TODO_HTTP_API.WebApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TODO_HTTP_API.DataAcceess.Entities.ListTask", b =>
                {
                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("ListId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("ListTasks");

                    b.HasData(
                        new
                        {
                            ListId = 1,
                            TaskId = 1
                        });
                });

            modelBuilder.Entity("TODO_HTTP_API.DataAcceess.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Importance")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2015, 10, 22, 12, 10, 15, 0, DateTimeKind.Unspecified),
                            Description = "Do it anyway",
                            Importance = 2,
                            IsCompleted = false,
                            IsDeleted = false,
                            Title = "Earn 1 million dollars"
                        });
                });

            modelBuilder.Entity("TODO_HTTP_API.DataAcceess.Entities.ToDoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ReturnCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("ToDoListType")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToDoLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "All Tasks",
                            ReturnCompleted = false,
                            ToDoListType = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Planned Tasks",
                            ReturnCompleted = false,
                            ToDoListType = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Important Tasks",
                            ReturnCompleted = false,
                            ToDoListType = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Today's Tasks",
                            ReturnCompleted = false,
                            ToDoListType = 0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TODO_HTTP_API.DataAcceess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John"
                        });
                });

            modelBuilder.Entity("TODO_HTTP_API.DataAcceess.Entities.ListTask", b =>
                {
                    b.HasOne("TODO_HTTP_API.DataAcceess.Entities.ToDoList", "List")
                        .WithMany("ListTasks")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TODO_HTTP_API.DataAcceess.Entities.Task", "Task")
                        .WithMany("ListTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TODO_HTTP_API.DataAcceess.Entities.ToDoList", b =>
                {
                    b.HasOne("TODO_HTTP_API.DataAcceess.Entities.User", "User")
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

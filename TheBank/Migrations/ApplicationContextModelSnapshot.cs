﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheBank2.Data;

namespace TheBank2.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheBank2.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVIP")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TheBank2.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TheBank2.Model.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<double>("CurrentSum")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfStart")
                        .HasColumnType("datetime2");

                    b.Property<double>("DepositPercent")
                        .HasColumnType("float");

                    b.Property<bool>("IsCapitalized")
                        .HasColumnType("bit");

                    b.Property<int>("MonthsCount")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsibleEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("StartSum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ResponsibleEmployeeId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("TheBank2.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("MaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("TheBank2.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheBank2.Model.Deposit", b =>
                {
                    b.HasOne("TheBank2.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("TheBank2.Model.User", "ResponsibleEmployee")
                        .WithMany()
                        .HasForeignKey("ResponsibleEmployeeId");

                    b.Navigation("Client");

                    b.Navigation("ResponsibleEmployee");
                });

            modelBuilder.Entity("TheBank2.Model.Position", b =>
                {
                    b.HasOne("TheBank2.Model.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TheBank2.Model.User", b =>
                {
                    b.HasOne("TheBank2.Model.Position", "Position")
                        .WithMany("Users")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("TheBank2.Model.Department", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("TheBank2.Model.Position", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

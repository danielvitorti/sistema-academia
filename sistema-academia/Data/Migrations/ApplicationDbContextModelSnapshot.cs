﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistema_academia.Data;

namespace sistema_academia.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("sistema_academia.Models.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnName("dataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("diaVencimento")
                        .IsRequired()
                        .HasColumnName("diaVencimento")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("enderecoBairro")
                        .IsRequired()
                        .HasColumnName("enderecoBairro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("enderecoCep")
                        .HasColumnName("enderecoCep")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("enderecoCidade")
                        .IsRequired()
                        .HasColumnName("enderecoCidade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("enderecoEstado")
                        .IsRequired()
                        .HasColumnName("enderecoEstado")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("enderecoNumero")
                        .IsRequired()
                        .HasColumnName("enderecoNumero")
                        .HasColumnType("char(15)");

                    b.Property<string>("enderecoRua")
                        .IsRequired()
                        .HasColumnName("enderecoRua")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasColumnName("sexo")
                        .HasColumnType("char(1)");

                    b.Property<string>("situacaoAluno")
                        .IsRequired()
                        .HasColumnName("situacaoAluno")
                        .HasColumnType("varchar(1)");

                    b.HasKey("id");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("sistema_academia.Models.ExercicioTreino", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Treinoid");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnName("dataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("observacao")
                        .HasColumnName("observacao")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("peso")
                        .HasColumnName("peso")
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal>("tempo")
                        .HasColumnName("tempo")
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("id");

                    b.HasIndex("Treinoid");

                    b.ToTable("ExercicioTreino");
                });

            modelBuilder.Entity("sistema_academia.Models.PagamentoAluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Alunoid");

                    b.Property<int?>("Planoid");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("tipoPagamento")
                        .IsRequired()
                        .HasColumnName("tipoPagamento")
                        .HasColumnType("char(1)");

                    b.Property<decimal>("valor")
                        .HasColumnName("valor")
                        .HasColumnType("decimal(10,4)");

                    b.HasKey("id");

                    b.HasIndex("Alunoid");

                    b.HasIndex("Planoid");

                    b.ToTable("PagamentoAluno");
                });

            modelBuilder.Entity("sistema_academia.Models.Plano", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnName("dataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("formaPagamento")
                        .IsRequired()
                        .HasColumnName("formaPagamento")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("observacao")
                        .HasColumnName("observacao")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("valor")
                        .HasColumnName("valor")
                        .HasColumnType("decimal(10,4)");

                    b.HasKey("id");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("sistema_academia.Models.PlanoAluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Alunoid");

                    b.Property<int?>("Planoid");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnName("dataCadastro")
                        .HasColumnType("datetime");

                    b.HasKey("id");

                    b.HasIndex("Alunoid");

                    b.HasIndex("Planoid");

                    b.ToTable("PlanoAluno");
                });

            modelBuilder.Entity("sistema_academia.Models.PresencaAluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Alunoid");

                    b.Property<DateTime>("dataPresenca")
                        .HasColumnName("dataPresenca")
                        .HasColumnType("datetime");

                    b.HasKey("id");

                    b.HasIndex("Alunoid");

                    b.ToTable("PresencaAluno");
                });

            modelBuilder.Entity("sistema_academia.Models.Treino", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Alunoid");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnName("dataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("objetivo")
                        .IsRequired()
                        .HasColumnName("objetivo")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("observacao")
                        .HasColumnName("observacao")
                        .HasColumnType("varchar(100)");

                    b.HasKey("id");

                    b.HasIndex("Alunoid");

                    b.ToTable("Treino");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sistema_academia.Models.ExercicioTreino", b =>
                {
                    b.HasOne("sistema_academia.Models.Treino", "Treino")
                        .WithMany("ExerciciosTreinos")
                        .HasForeignKey("Treinoid");
                });

            modelBuilder.Entity("sistema_academia.Models.PagamentoAluno", b =>
                {
                    b.HasOne("sistema_academia.Models.Aluno", "Aluno")
                        .WithMany("PagamentosAlunos")
                        .HasForeignKey("Alunoid");

                    b.HasOne("sistema_academia.Models.Plano", "Plano")
                        .WithMany("PagamentosAlunos")
                        .HasForeignKey("Planoid");
                });

            modelBuilder.Entity("sistema_academia.Models.PlanoAluno", b =>
                {
                    b.HasOne("sistema_academia.Models.Aluno", "Aluno")
                        .WithMany("PlanosAlunos")
                        .HasForeignKey("Alunoid");

                    b.HasOne("sistema_academia.Models.Plano", "Plano")
                        .WithMany("PlanosAlunos")
                        .HasForeignKey("Planoid");
                });

            modelBuilder.Entity("sistema_academia.Models.PresencaAluno", b =>
                {
                    b.HasOne("sistema_academia.Models.Aluno", "Aluno")
                        .WithMany("PresencasAlunos")
                        .HasForeignKey("Alunoid");
                });

            modelBuilder.Entity("sistema_academia.Models.Treino", b =>
                {
                    b.HasOne("sistema_academia.Models.Aluno", "Aluno")
                        .WithMany("Treinos")
                        .HasForeignKey("Alunoid");
                });
#pragma warning restore 612, 618
        }
    }
}

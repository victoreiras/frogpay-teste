﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using src.FrogPay.Infrastructure.Data;

#nullable disable

namespace src.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("src.FrogPay.Domain.Entities.DadosBancarios", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("agencia");

                    b.Property<string>("CodigoBanco")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("codigo_banco");

                    b.Property<string>("Conta")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("conta");

                    b.Property<string>("DigitoConta")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("digito_conta");

                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("DadosBancarios");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("cidade");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("complemento");

                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uuid");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("logradouro");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("numero");

                    b.Property<string>("UfEstado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("uf_estado");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.Loja", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cnpj");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_abertura");

                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uuid");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("nome_fantasia");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("razao_social");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("Lojas");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("SenhaHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("SenhaSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime>("TokenDataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.DadosBancarios", b =>
                {
                    b.HasOne("src.FrogPay.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("DadosBancarios")
                        .HasForeignKey("src.FrogPay.Domain.Entities.DadosBancarios", "IdPessoa")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("src.FrogPay.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("src.FrogPay.Domain.Entities.Endereco", "IdPessoa")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.Loja", b =>
                {
                    b.HasOne("src.FrogPay.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("Loja")
                        .HasForeignKey("src.FrogPay.Domain.Entities.Loja", "IdPessoa")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("src.FrogPay.Domain.Entities.Pessoa", b =>
                {
                    b.Navigation("DadosBancarios")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Loja")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

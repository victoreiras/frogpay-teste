using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Infrastructure.EntitiesConfiguration;
public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(x => x.Id)
            .IsUnique();
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("uuid") 
            .IsRequired();

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Cpf)
            .HasColumnName("cpf")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.DataNascimento)
            .HasColumnName("data_nascimento")
            // .HasConversion<NpgsqlTypes.NpgsqlDbType.Date>()
            .IsRequired();

        builder.Property(p => p.Ativo)
            .HasColumnName("ativo")
            .IsRequired();

        builder.Property(p => p.DataCriacao)
            .HasColumnName("data_criacao");
    }
}
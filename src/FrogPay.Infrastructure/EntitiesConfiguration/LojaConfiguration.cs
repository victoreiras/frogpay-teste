using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Infrastructure.EntitiesConfiguration;

public class LojaConfiguration : IEntityTypeConfiguration<Loja>
{
    public void Configure(EntityTypeBuilder<Loja> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(x => x.Id)
            .IsUnique();
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("uuid") 
            .IsRequired();

        builder.Property(p => p.NomeFantasia)
            .HasColumnName("nome_fantasia")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.RazaoSocial)
            .HasColumnName("razao_social")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.DataAbertura)
            .HasColumnName("data_abertura")
            .IsRequired();

        builder.HasOne(x => x.Pessoa)
            .WithOne(x => x.Loja)
            .HasForeignKey<Loja>(x => x.IdPessoa)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

    }        
}
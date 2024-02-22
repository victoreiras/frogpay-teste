using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Infrastructure.EntitiesConfiguration;

public class DadosBancariosConfiguration : IEntityTypeConfiguration<DadosBancarios>
{
    public void Configure(EntityTypeBuilder<DadosBancarios> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(x => x.Id)
            .IsUnique();
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("uuid") 
            .IsRequired();

        builder.Property(p => p.CodigoBanco)
            .HasColumnName("codigo_banco")
            .IsRequired();

        builder.Property(p => p.Agencia)
            .HasColumnName("agencia")
            .IsRequired();

        builder.Property(p => p.Conta)
            .HasColumnName("conta")
            .IsRequired();

        builder.Property(p => p.DigitoConta)
            .HasColumnName("digito_conta")
            .IsRequired();

        builder.HasOne(x => x.Pessoa)
            .WithOne(x => x.DadosBancarios)
            .HasForeignKey<DadosBancarios>(x => x.IdPessoa)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

    }        
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Infrastructure.EntitiesConfiguration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(x => x.Id)
            .IsUnique();
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("uuid") 
            .IsRequired();

        builder.Property(p => p.UfEstado)
            .HasColumnName("uf_estado")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(p => p.Cidade)
            .HasColumnName("cidade")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Bairro)
            .HasColumnName("bairro")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Logradouro)
            .HasColumnName("logradouro")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Numero)
            .HasColumnName("numero")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Complemento)
            .HasColumnName("complemento")
            .HasMaxLength(500)
            .IsRequired();

        builder.HasOne(x => x.Pessoa)
            .WithOne(x => x.Endereco)
            .HasForeignKey<Endereco>(x => x.IdPessoa)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
            
    }        
}
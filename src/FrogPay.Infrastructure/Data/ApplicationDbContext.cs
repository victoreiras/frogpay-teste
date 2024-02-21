using Microsoft.EntityFrameworkCore;
using src.FrogPay.Domain.Entities;

namespace src.FrogPay.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) 
    { 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Pessoa> Pessoas { get; set; } 
}
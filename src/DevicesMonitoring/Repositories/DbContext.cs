using DevicesMonitoring.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DevicesMonitoring.Repositories;

public class MyDbContext: DbContext
{
    public DbSet<UserModel> users { get; set; }
    public DbSet<Device> devices { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Devices)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserId);
    }

}

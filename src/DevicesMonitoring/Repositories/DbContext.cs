using DevicesMonitoring.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DevicesMonitoring.Repositories;

public class MyDbContext: DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    public DbSet<UserModel> users { get; set; }
    public DbSet<Device> devices { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>()
            .HasOne(d => d.User)
            .WithMany(u => u.Devices)
            .HasForeignKey(d => d.UserId);
    }

}

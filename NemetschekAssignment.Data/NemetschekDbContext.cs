using Microsoft.EntityFrameworkCore;
using NemetschekAssignment.Models;

namespace OndoNet.Data;
public class NemetschekDbContext(DbContextOptions<NemetschekDbContext> options) : DbContext(options)
{
    public DbSet<NemetschekDocument> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
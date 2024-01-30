using Microsoft.EntityFrameworkCore;
using Selu383.SP24.Api.Entities;

public class DataContext : DbContext
{

    public DbSet<Hotel> Hotels { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        modelBuilder.Entity<Hotel>()
            .Property(x => x.Name)
            .HasMaxLength(120);

        modelBuilder.Entity<Hotel>()
            .HasData(
            new Hotel 
            {
                Id = 1, Name = "Marriott", Address = "3545 Pickle Avenue"
            },
            new Hotel 
            {
                Id = 2, Name = "Beachside", Address = "8888 Sunny Road"
            },
            new Hotel 
            {
                Id = 3, Name = "Hotel Vitality", Address = "1234 Jerry Lane"
            }
            );
    }
}
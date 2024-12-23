namespace WM_API.Context;

public class TestContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("WMart");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pais>().HasData(
            new Pais
            {
                Id = 1,
                Nombre = "Mexico"
            });

        //builder.Entity<Estado>().HasData(
        //   new Estado
        //   {
        //       Id = 1,
        //       Nombre = "Estado de Mexico",

        //   });

        //builder.Entity<Localidad>().HasData(
        //    new Localidad
        //    {
        //        Id = 1,
        //        Nombre = "Cuautitlan",
        //        Estado = new Estado
        //        {
        //            Id = 1,
        //            Nombre = "Estado de Mexico",
        //            Pais = new Pais
        //            {
        //                Id = 1,
        //                Nombre = "Mexico"
        //            }
        //        }
        //    });
    }


    public DbSet<Estado> Estado { get; set; }
    public DbSet<Localidad> Localid { get; set; }
    public DbSet<Pais> Pais { get; set; }
    public DbSet<Terreno> Terreno { get; set; }


}

using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Offer> Offers { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
                                                          : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>().HasData(
                new Offer { Id = 1, Brand = "Lada", 
                    Model = "Vesta", 
                    Supplier = new Supplier { Name = "WAZ"}, 
                    RegistrationDate = DateTime.Now },
                new Offer { Id = 2, Brand = "Lada", 
                    Model = "Granta",
                    Supplier = new Supplier { Name = "WAZ" }, 
                    RegistrationDate = DateTime.Now },
                new Offer { Id = 3, Brand = "Lada", Model = "Granta",
                    Supplier = new Supplier { Name = "WAZ" },
                    RegistrationDate = DateTime.Now },
                new Offer { Id = 4, Brand = "zil", 
                    Model = "111",
                    Supplier = new Supplier { Name = "ZIL" },
                    RegistrationDate = DateTime.Now },
                new Offer
                {
                    Id = 5,
                    Brand = "zil",
                    Model = "114",
                    Supplier = new Supplier { Name = "ZIL" },
                    RegistrationDate = DateTime.Now
                },
                new Offer
                {
                    Id = 6,
                    Brand = "ural-next",
                    Model = "samosval",
                    Supplier = new Supplier { Name = "URAL" },
                    RegistrationDate = DateTime.Now
                },
                 new Offer
                 {
                     Id = 7,
                     Brand = "ural-next",
                     Model = "bus",
                     Supplier = new Supplier { Name = "URAL" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 8,
                     Brand = "ural-next",
                     Model = "bort",
                     Supplier = new Supplier { Name = "URAL" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 9,
                     Brand = "ural-m",
                     Model = "bus",
                     Supplier = new Supplier { Name = "URAL" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 10,
                     Brand = "gazel",
                     Model = "bus",
                     Supplier = new Supplier { Name = "GAZ" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 11,
                     Brand = "gazel",
                     Model = "combi",
                     Supplier = new Supplier { Name = "GAZ" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 12,
                     Brand = "sobol",
                     Model = "bus",
                     Supplier = new Supplier { Name = "GAZ" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 13,
                     Brand = "sobol",
                     Model = "furgon",
                     Supplier = new Supplier { Name = "GAZ" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 14,
                     Brand = "sobol",
                     Model = "combi",
                     Supplier = new Supplier { Name = "GAZ" },
                     RegistrationDate = DateTime.Now
                 },
                 new Offer
                 {
                     Id = 15,
                     Brand = "kamaz",
                     Model = "neo",
                     Supplier = new Supplier { Name = "Kamaz" },
                     RegistrationDate = DateTime.Now
                 });

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 2, Name = "Kamaz" },
                new Supplier { Id = 3, Name = "WAZ" },
                new Supplier { Id = 4, Name = "GAZ" },
                new Supplier { Id = 5, Name = "ZIL" },
                new Supplier { Id = 6, Name = "URAL" }
            );
        }
    }
}

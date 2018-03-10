using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace DsucicOmegaEdukacija.Models

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        { }

        public DbSet<Kontakt> Kontakti { get; set; }
        public DbSet<Grad> Gradovi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grad>().ToTable("Grad");
            modelBuilder.Entity<Kontakt>().ToTable("Kontakt");


            base.OnModelCreating(modelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
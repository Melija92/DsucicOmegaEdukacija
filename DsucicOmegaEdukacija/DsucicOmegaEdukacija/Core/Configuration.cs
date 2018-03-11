using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DsucicOmegaEdukacija.Core
{
    public class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            string adminRoleId;
            string userRoleId;
            if (!context.Roles.Any())
            {
                adminRoleId = context.Roles.Add(new IdentityRole("Administrator")).Id;
                userRoleId = context.Roles.Add(new IdentityRole("User")).Id;
            }
            else
            {
                adminRoleId = context.Roles.First(c => c.Name == "Administrator").Id;
                userRoleId = context.Roles.First(c => c.Name == "User").Id;
            }

            context.SaveChanges();

            if (!context.Users.Any())
            {
                var administrator = context.Users.Add(new IdentityUser("administrator") { Email = "admin@admin.com", EmailConfirmed = true });
                administrator.Roles.Add(new IdentityUserRole { RoleId = adminRoleId });

                var obicanKorisnik = context.Users.Add(new IdentityUser("obicanKorisnik") { Email = "korisnik@korisnik.com", EmailConfirmed = true });
                obicanKorisnik.Roles.Add(new IdentityUserRole { RoleId = userRoleId });

                context.SaveChanges();

                var store = new ApplicationUserStore();
                store.SetPasswordHashAsync(administrator, new ApplicationUserManager().PasswordHasher.HashPassword("administrator123"));
                store.SetPasswordHashAsync(obicanKorisnik, new ApplicationUserManager().PasswordHasher.HashPassword("korisnik123"));
            }

            context.SaveChanges();
        }
    }
}

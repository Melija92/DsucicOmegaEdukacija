namespace DsucicOmegaEdukacija.Core
{
    using DsucicOmegaEdukacija.Models;
    using System.Data.Entity;

    public class Initializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>
    {
    }
}
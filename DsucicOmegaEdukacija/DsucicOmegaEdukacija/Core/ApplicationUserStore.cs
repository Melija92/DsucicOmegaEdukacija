using DsucicOmegaEdukacija.Models;
using Microsoft.AspNet.Identity.EntityFramework;
namespace DsucicOmegaEdukacija.Core
{
    public class ApplicationUserStore : UserStore<IdentityUser>
    {
        public ApplicationUserStore() : base(new ApplicationDbContext())
        {
        }
    }
}
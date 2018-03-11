using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DsucicOmegaEdukacija.Core
{
    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {
        }
    }
}
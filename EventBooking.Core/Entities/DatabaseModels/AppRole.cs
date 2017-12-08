using Microsoft.AspNetCore.Identity;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {
        }

        public AppRole(string roleName) : base(roleName)
        {
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace EventBooking.Core.Interfaces
{
    public interface IIdentityRoleFactory
    {
        T Create<T>(string name) where T : IdentityRole;
    }
}
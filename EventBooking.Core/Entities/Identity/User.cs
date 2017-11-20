//using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class User //: IdentityUser
    {
        public byte[] ProfileImage { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

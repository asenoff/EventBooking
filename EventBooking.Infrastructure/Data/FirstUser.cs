using EventBooking.Core.Entities.DatabaseModels;

namespace EventBooking.Infrastructure.Data
{
    public class FirstUser
    {
        private AppUser user = 
            new AppUser(){
                Email = "kaloyan@asenoff.net",
                UserName = "kaloyan@asenoff.net",
                FirstName = "Kaloyan",
                LastName = "Asenov",
                EmailConfirmed = true,
                IsClubMember = true,
                Preferences = new PreferencesSet
                {
                    RecieveFullEventInfo = true,
                    RecieveMailsFromApp = true
                }
            };

        public AppUser User
        {
            get {
                return user;
            }
        }

        public static string Password { get { return "G0ly@mpr@z"; } }
    }
}

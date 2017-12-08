using EventBooking.Core.Entities.DatabaseModels;

namespace EventBooking.Infrastructure.Data
{
    public static class FirstUser
    {
        public static AppUser User
        {
            get {
                return new AppUser()
                {
                    Email = "kaloyan@asenoff.net",
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
            }
        }

        public static string Password { get { return "G0ly@mpr@z"; } }
    }
}

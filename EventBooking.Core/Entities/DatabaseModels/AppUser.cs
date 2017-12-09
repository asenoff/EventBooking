using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using limits = EventBooking.Core.Constants.Numeric.DataValidationRestrictions;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class AppUser : IdentityUser
    {
        [Required, StringLength(limits.MaxUserName)]
        public string FirstName { get; set; }

        [Required, StringLength(limits.MaxUserName)]
        public string LastName { get; set; }

        [Required]
        public bool IsClubMember { get; set; }
        
        [Required]
        public virtual PreferencesSet Preferences { get; set; }
        
        public virtual UserImage Image { get; set; }
    }
}

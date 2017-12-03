using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public abstract class AppUser : IdentityUser
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public bool IsClubMember { get; set; }

        [ForeignKey("Rights")]
        public string RightsAlias { get; set; }

        [Required]
        public virtual RightsSet Rights { get; set; }
        
        [Required]
        public virtual PreferencesSet Preferences { get; set; }
        
        public virtual UserImage Image { get; set; }
    }
}

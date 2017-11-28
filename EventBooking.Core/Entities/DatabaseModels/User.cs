using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Core.Entities.DatabaseModels
{

    [Table("Users")]
    public abstract class User
    {
        [Key, Required, EmailAddress]
        public string Mail { get; set; }

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

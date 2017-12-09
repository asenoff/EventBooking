using System.ComponentModel.DataAnnotations;
using limits = EventBooking.Core.Constants.Numeric.DataValidationRestrictions;

namespace EventBooking.Web.ApiModels
{
    public class LoginDataDTO
    {
        [Required, EmailAddress]
        public string UserName { get; set; }

        [Required, MinLength(limits.MinPasswordLength), MaxLength(limits.MaxPasswordLength)]
        public string Password { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class UserImage : Image
    {
        [ForeignKey("User")]
        public string UserMail { get; set; }

        public virtual User User { get; set; }
    }
}

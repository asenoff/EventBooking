using System.ComponentModel.DataAnnotations;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class User
    {
        [Key]
        public string Mail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Rights Rights { get; set; }
    }
}

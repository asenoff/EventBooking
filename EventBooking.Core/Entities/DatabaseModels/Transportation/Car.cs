using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Core.Entities.DatabaseModels
{

    [Table("Cars")]
    public class Car
    {
        [Key, StringLength(10)]
        public string RegistrationID { get; set; }

        [Required, StringLength(50)]
        public string Alias { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int PassengerCount { get; set; }

        public int? BikeCount { get; set; }

        public Driver Driver { get; set; }
    }
}

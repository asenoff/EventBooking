using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Core.Entities.DatabaseModels
{

    [Table("Drivers")]
    public class Driver
    {
        [Key]
        public Guid Id { get; set; }

        public string ParticipantMail { get; set; }

        public Participant Participant { get; set; }

        public Guid CarId { get; set; }

        [ForeignKey("Car")]
        public string RegistrationId { get; set; }

        public Car Car { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}

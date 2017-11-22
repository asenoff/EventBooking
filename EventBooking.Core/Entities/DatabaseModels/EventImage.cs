using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class EventImage : Image
    {
        [ForeignKey("Event")]
        public int EventID { get; set; }

        public virtual Event Event { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventBooking.Core.Entities.DatabaseModels.ManyToMany;

namespace EventBooking.Core.Entities.DatabaseModels
{
    public class Guide : Participant
    {
        public Guide()
        {
            GuidedEvents = new HashSet<EventGuide>();
        }

        [Required, StringLength(500)]
        public string Resume { get; set; }
        
        public virtual ICollection<EventGuide> GuidedEvents { get; set; }
    }
}

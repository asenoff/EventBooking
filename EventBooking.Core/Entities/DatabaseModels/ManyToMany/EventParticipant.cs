namespace EventBooking.Core.Entities.DatabaseModels.ManyToMany
{
    public class EventParticipant
    {
        public int EventId { get; set; }

        public Event Event { get; set; }

        public string ParticipantMail { get; set; }

        public Participant Participant { get; set; }
    }
}

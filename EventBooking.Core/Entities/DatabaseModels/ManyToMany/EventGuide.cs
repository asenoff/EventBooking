namespace EventBooking.Core.Entities.DatabaseModels.ManyToMany
{
    public class EventGuide
    {
        public int EventId { get; set; }

        public Event Event { get; set; }

        public string GuideMail { get; set; }

        public Guide Guide { get; set; }
    }
}

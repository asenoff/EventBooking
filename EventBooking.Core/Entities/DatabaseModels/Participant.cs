namespace EventBooking.Core.Entities.DatabaseModels
{
    public class Participant : User
    {
        public string Phone { get; set; }

        public string FaceBookLink { get; set; }
    }
}

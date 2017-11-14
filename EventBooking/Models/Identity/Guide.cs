namespace EventBooking.Models.Identity
{
    public class Guide : User
    {
        public bool ExposeMail { get; set; }

        public bool ExposePhone { get; set; }

        public bool ExposeFacebook { get; set; }

        public string Phone { get; set; }

        public string Facebook { get; set; }
    }
}

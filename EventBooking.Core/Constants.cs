namespace EventBooking.Core
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }

        public static class Numeric
        {
            public static class DataValidationRestrictions
            {
                public const int MinPasswordLength = 6, MaxPasswordLength = 30;

                public const int MinNameLength = 1, MaxUserName = 50;


            }
        }
    }
}

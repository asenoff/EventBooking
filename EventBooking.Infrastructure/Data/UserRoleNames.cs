using System;
using System.Collections.Generic;
using System.Text;

namespace EventBooking.Infrastructure.Data
{
    public static class UserRoleNames
    {
        public static string SuperAdmin { get { return "SuperAdmin"; } }

        public static string Admin { get { return "Admin"; } }

        public static string PeepAdmin { get { return "PeepAdmin"; } }

        public static string User { get { return "User"; } }

        public static List<string> GetAllRoles()
        {
            return new List<string>(new string[] { SuperAdmin, Admin, PeepAdmin, User });
        }
    }
}

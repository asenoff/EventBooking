using System;
using System.Collections.Generic;
using EventBooking.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EventBooking.Core.Factories
{
    public class IdentityRoleFactory : IIdentityRoleFactory
    {
        private readonly Dictionary<Type, Func<string, IdentityRole>> _factories;

        public IdentityRoleFactory(Dictionary<Type, Func<string, IdentityRole>> factories)
        {
            _factories = factories;
        }

        public T Create<T>(string name) where T : IdentityRole
        {
            return _factories[typeof(T)](name) as T;
        }
    }
}

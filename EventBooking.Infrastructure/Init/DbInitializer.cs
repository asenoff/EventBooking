using EventBooking.Infrastructure.Data;
using EventBooking.Core.Entities.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using EventBooking.Core.Interfaces;

namespace EventBooking.Infrastructure.Init
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        private readonly FirstUser _firstUser;

        private readonly IIdentityRoleFactory _rolesFactory;

        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, FirstUser firstUser, IIdentityRoleFactory rolesFactory)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _firstUser = firstUser;
            _rolesFactory = rolesFactory;
        }

        public async Task Seed()
        {
            if (!_context.Roles.Any())
            {
                foreach (var roleName in UserRoleNames.GetAllRoles())
                {
                    var role = _rolesFactory.Create<AppRole>(roleName);
                    await _roleManager.CreateAsync(role);
                }
            }

            if (!_context.Users.Any())
            {
                await _userManager.CreateAsync(_firstUser.User, FirstUser.Password);
                await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(_firstUser.User.Email), UserRoleNames.SuperAdmin);
            }
        }
    }
}
using EventBooking.Infrastructure.Data;
using EventBooking.Core.Entities.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace EventBooking.Infrastructure.Init
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_context.Roles.Any())
            {
                foreach (var role in UserRoleNames.GetAllRoles())
                {
                    await _roleManager.CreateAsync(new AppRole(role));
                }
            }

            if (!_context.Users.Any())
            {
                await _userManager.CreateAsync(FirstUser.User, FirstUser.Password);
                await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(FirstUser.User.Email), UserRoleNames.SuperAdmin);
            }
        }
    }
}
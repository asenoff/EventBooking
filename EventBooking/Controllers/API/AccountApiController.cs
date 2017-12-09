using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EventBooking.Infrastructure.Data;
using EventBooking.Core.Entities.DatabaseModels;
using EventBooking.Web.ApiModels;

namespace EventBooking.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, IMapper mapper, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // PUT api/accounts
        [HttpPut("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]AppUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser newUser = new AppUser {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsClubMember = false,
                Preferences = new PreferencesSet {
                    RecieveFullEventInfo = false,
                    RecieveMailsFromApp = true
                }
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                {
                    ModelState.TryAddModelError(e.Code, e.Description);
                }

                return new BadRequestObjectResult(ModelState);
            }
                
            await _appDbContext.SaveChangesAsync();
            return new OkResult();
        }
    }
}

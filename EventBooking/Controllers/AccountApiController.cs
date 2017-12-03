using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EventBooking.Infrastructure.Data;
using EventBooking.Core.Entities.DatabaseModels;

namespace EventBooking.Controllers
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
        //TODO - first seed data in roles - https://forums.asp.net/t/2122687.aspx?How+to+Seed+Data+in+Core+
        //// PUT api/accounts
        //[HttpPut("create")]
        //public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //
        //    var userIdentity = _mapper.Map<AppUser>(model);
        //    var result = await _userManager.CreateAsync(userIdentity, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        return new BadRequestObjectResult(ModelState);
        //    }
        //        
        //    await _appDbContext.SaveChangesAsync();
        //    return new OkResult();
        //}
    }
}

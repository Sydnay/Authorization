using Authorization.Dtos;
using Authorization.Entities;
using Authorization.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Authorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        AccountRepository repository;
        public ProfileController(AccountRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("aboutme")]
        [Authorize]
        public async Task<ActionResult<ProfileInfoDto>> GetProfileInfo()
        {
            var profile = await GetCurrentUserProfile();

            return profile.ToProfileInfo();
        }
        [HttpPut("update")]
        [Authorize]
        public async Task<ActionResult> UpdateProfile(UpdateProfileDto profileDto)
        {
            var profile = await GetCurrentUserProfile();

            await repository.UpdateProfile(profile, profileDto);

            return Ok(profile.ToProfileInfo());
        }
        private async Task<Profile> GetCurrentUserProfile()
        {
            ClaimsPrincipal currentUser = User;
            var email = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = await repository.GetProfile(email);
            return profile;
        }
    }
}

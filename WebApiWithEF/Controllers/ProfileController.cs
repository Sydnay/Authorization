using Authorization.Dtos;
using Authorization.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Authorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        PlaylistContext repository;
        public ProfileController(PlaylistContext repository)
        {
            this.repository = repository;
        }

        [HttpGet("aboutme")]
        [Authorize]
        public async Task<ActionResult<ProfileInfoDto>> GetProfileInfo()
        {
            ClaimsPrincipal currentUser = User;
            var email = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = repository.Profiles.FirstOrDefault(user => user.User.Email.Equals(email));

            return profile.ProfileInfo();
        }
        [HttpPut("update")]
        [Authorize]
        public async Task<ActionResult> UpdateProfile(Guid id, UpdateProfileDto profileDto)
        {
            ClaimsPrincipal currentUser = User;
            var email = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = repository.Profiles.FirstOrDefault(user => user.User.Email.Equals(email));

            profile.Gender = profileDto.Gender;
            profile.Name = profileDto.Name is null? profile.Name:profileDto.Name;
            profile.Birthday = profileDto.Birthday is null ? profile.Birthday : profileDto.Birthday;

            repository.Profiles.Update(profile);
            await repository.SaveChangesAsync();

            return Ok(profile.ProfileInfo());
        }
    }
}

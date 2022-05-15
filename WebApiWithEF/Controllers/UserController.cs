using Authorization.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWithEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        AccountRepository repository;
        public UserController(AccountRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthorizedUsers()
        {
            return Ok(await repository.GetAllUsers());
        }
        [HttpGet("user")]
        public async Task<ActionResult> GetAuthorizedUser(string email)
        {
            var user = await repository.GetUser(email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string login)
        {
            if (await repository.GetUser(login) == null)
                return NotFound();

            await repository.DeleteUser(login);

            return Ok(login);
        }
    }
}

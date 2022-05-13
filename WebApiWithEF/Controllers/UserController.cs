using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWithEF.Dtos;

namespace WebApiWithEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        PlaylistContext repository;
        public UserController(PlaylistContext repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetAllAuthorizedUsers()
        {
            return Ok(repository.GetAllUsers());
        }
        [HttpGet("user")]
        public ActionResult GetAuthorizedUser(string login)
        {
            var user = repository.GetUser(login);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        [HttpDelete]
        public ActionResult DeleteUser(string login)
        {
            if (repository.GetUser(login) == null)
                return NotFound();

            repository.DeleteUser(login);
            repository.SaveChanges();
            return Ok(login);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWithEF.Dtos;

namespace WebApiWithEF.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        DbUserRepository repository;
        public UserController(DbUserRepository repository)
        {
            this.repository = repository;
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

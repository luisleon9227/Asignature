using Asignaturas.Models;
using Asignaturas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Asignaturas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUser _user;

        public UserController(ILogger<UserController> logger, IUser user)
        {
            _logger = logger;
            _user = user;

        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            return Ok(_user.Get());
        }

        [HttpGet]
        [Route("GetUserByIdentification/{identification}")]
        public IActionResult GetUserByIdeentification(int identification)
        {
            return Ok(_user.GetUserByIdeentification(identification));
        }


        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            return Ok(_user.CreateUser(user));
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                if (_user.DeleteUser(id))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("El usuario no existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("El usuario no existe");
            }
        }



    }
}

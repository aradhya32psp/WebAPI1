using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Users>> Get() =>
            _userService.Get();

        [HttpGet("{_id:length(24)}", Name = "GetUser")]
        public ActionResult<Users> Get(string _id)
        {
            var user = _userService.Get(_id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<Users> Create(Users user)
        {
            try
            {
                _userService.Create(user);
            } catch (System.Exception ex)
            {

            }
            //return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
            return CreatedAtRoute("GetUser", new { UserName = user._id.ToString() }, user);
        }

        [HttpPut("{_id:length(24)}")]
        public IActionResult Update(string _id, Users userIn)
        {
            var user = _userService.Get(_id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(_id, userIn);

            return NoContent();
        }

        [HttpDelete("{_id:length(24)}")]
        public IActionResult Delete(string _id)
        {
            var user = _userService.Get(_id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user._id);

            return NoContent();
        }
    }
}

using DishApi.Dto;
using Microsoft.AspNetCore.Mvc;


namespace DishApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            var allUsers = userService.GetAllUsers();

            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetUserById(Guid id)
        {
            var user = userService.GetUserById(id);
            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost("AddUser")]

        public IActionResult AddUser(AddUserDto dto)
        {
            var newUser = userService.AddUser(dto);

            if (newUser is null) return NotFound();

            return Ok(newUser);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var deletedUser = userService.DeleteUser(id);

            if (!deletedUser) return NotFound();

            return Ok(deletedUser);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateUser(UpdateUserDto dto, Guid id)
        {
            var updatedUser = userService.UpdateUser(dto, id);

            if ( updatedUser is null) return NotFound();

            return Ok(updatedUser);
        }
}

}

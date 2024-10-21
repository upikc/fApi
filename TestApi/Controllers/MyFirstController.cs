using Api.entity;
using Microsoft.AspNetCore.Mvc;
using TestApi.Model;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyFirstController : ControllerBase
    {
        private readonly ILogger<MyFirstController> _logger;
        public ApiDatabaseContext DataContex = new ApiDatabaseContext();

        public MyFirstController(ILogger<MyFirstController> logger)
        {
            _logger = logger;
        }

        [HttpGet("LoginCheck")]
        public IActionResult LoginCheck(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return BadRequest();
            var user = DataContex.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user != default)
                return Ok(new UserDTO(user));
            else
                return StatusCode(406);

        }


        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            //var users = new List<User>().ToArray();
            //var x = DataContex.Users.ToArray();
            //x.CopyTo(users);
            //foreach (var user in users)
            //    user.Notes = default;

            var Users = DataContex.Users.ToList();
            var data = Users.Select(s => new UserDTO(s)).ToArray();




            return Ok(data);
        }

        [HttpGet("GetDefaultUser")]
        public IActionResult GetDefaultUser()
        {
            return Ok(new User() { Id = 99, Login = "user_login", Password = "user_password" });
        }


        [HttpGet("GetFirstUser")]
        public IActionResult GetFirstUser()
        {
            return Ok(DataContex.Users.First());
        }
    }
}

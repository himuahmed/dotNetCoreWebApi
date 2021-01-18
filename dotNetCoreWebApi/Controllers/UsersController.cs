using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using dotNetCoreWebApi.Repository;
using Microsoft.AspNetCore.Authorization;

namespace dotNetCoreWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _datingRepository;

        public UsersController(IDatingRepository datingRepository)
        {
            _datingRepository = datingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _datingRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user =await _datingRepository.GetUser(id);
            return Ok(user);
        }
    }
}

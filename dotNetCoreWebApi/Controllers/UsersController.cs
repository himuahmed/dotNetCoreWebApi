using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using dotNetCoreWebApi.Dtos;
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
        private IMapper _mapper;

        public UsersController(IDatingRepository datingRepository,IMapper mapper)
        {
            _mapper = mapper;
            _datingRepository = datingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _datingRepository.GetUsers();
            var returnedUsers = _mapper.Map<IEnumerable<UserList>>(users);
            return Ok(returnedUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user =await _datingRepository.GetUser(id);

            var returnedUser = _mapper.Map<UserForDetails>(user);
            return Ok(returnedUser);   
        }
    }
}

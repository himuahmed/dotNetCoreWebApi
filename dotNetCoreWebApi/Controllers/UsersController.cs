using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using dotNetCoreWebApi.Dtos;
using dotNetCoreWebApi.Helpers;
using dotNetCoreWebApi.Repository;
using Microsoft.AspNetCore.Authorization;

namespace dotNetCoreWebApi.Controllers
{   
    [ServiceFilter(typeof(ActivityChecker))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _datingRepository;
        private readonly IMapper _mapper;

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

        [HttpGet("{id}",Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user =await _datingRepository.GetUser(id);

            var returnedUser = _mapper.Map<UserForDetails>(user);
            return Ok(returnedUser);   
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdate userUpdate)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var fetchedUser =await _datingRepository.GetUser(id);

            _mapper.Map(userUpdate, fetchedUser);

            if (await _datingRepository.SaveAll())
            {
                return NoContent();
            }

            throw new Exception("Failed to update user");

        }
    }
}

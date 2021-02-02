using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotNetCoreWebApi.Dtos;
using dotNetCoreWebApi.Helpers;
using dotNetCoreWebApi.Models;
using dotNetCoreWebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotNetCoreWebApi.Controllers
{
    [ServiceFilter(typeof(ActivityChecker))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDatingRepository _datingRepository;

        public MessageController(IMapper mapper,IDatingRepository datingRepository)
        {
            _mapper = mapper;
            _datingRepository = datingRepository;
        }

        [HttpGet("{id}",Name = "GetMessage")]
        public async Task<IActionResult> GetMessages(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var messageFromRepo = await _datingRepository.GetMessage(id);

            if (messageFromRepo == null)
                return NotFound("Couldn't fetch message.");

            return Ok(messageFromRepo);

        }

        [HttpPost]
        public async Task<IActionResult> GetMessages(int userId, MessageDto messageDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            messageDto.SenderId = userId;
            var recipient = await _datingRepository.GetUser(messageDto.RecipientId);

            if (recipient == null)
                return NotFound("No such user");

            var message = _mapper.Map<Message>(messageDto);

            _datingRepository.Add(message);

            var messageToReturn = _mapper.Map<MessageDto>(message);

            if (await _datingRepository.SaveAll())
                return CreatedAtRoute("GetMessage", new {id = message.Id}, messageToReturn);

            throw new Exception("Couldn't send message");
        }


    }
}

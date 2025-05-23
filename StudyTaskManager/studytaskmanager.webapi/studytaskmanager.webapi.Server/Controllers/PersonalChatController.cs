﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyTaskManager.Application.Entity.PersonalChats.Commands.PersonalChatAddMessage;
using StudyTaskManager.Application.Entity.PersonalChats.Commands.PersonalChatCreate;
using StudyTaskManager.Application.Entity.PersonalChats.Commands.PersonalChatDelete;
using StudyTaskManager.Application.Entity.PersonalChats.Queries.PersonalChatGetById;
using StudyTaskManager.Application.Entity.PersonalChats.Queries.PersonalChatsGetAll;
using StudyTaskManager.Application.Entity.PersonalMessages.Queries.PersonalMessageGetAll;
using StudyTaskManager.Application.Entity.PersonalMessages.Queries.PersonalMessageTake;
using StudyTaskManager.WebAPI.Abstractions;

namespace StudyTaskManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PersonalChatController : ApiController
    {
        public PersonalChatController(ISender sender) : base(sender) { }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PersonalChatCreateCommand command,
            CancellationToken cancellationToken)
        {
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : HandleFailure(response);
        }

        //[Authorize]
        [HttpGet("{perconalChatId:guid}")]
        public async Task<IActionResult> GetPersonalChatById(
            Guid perconalChatId,
            CancellationToken cancellationToken)
        {
            var query = new PersonalChatGetByIdQuery(perconalChatId);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : HandleFailure(response);
        }
        //[Authorize]
        [HttpGet("{perconalChatId:guid}/Messages")]
        public async Task<IActionResult> GetMessageByPersonalChatId(
            Guid perconalChatId,
            CancellationToken cancellationToken)
        {
            var query = new PersonalMessageGetAllQuery(pm => pm.PersonalChatId == perconalChatId);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : HandleFailure(response);
        }

        //[Authorize]
        [HttpGet("Chats/{userId:guid}")]
        public async Task<IActionResult> GetPersonalChatsByUser(
            Guid userId,
            CancellationToken cancellationToken)
        {
            var query = new PersonalChatsGetAllQuery(pc => pc.User1Id == userId || pc.User2Id == userId);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : HandleFailure(response);
        }

        //[Authorize]
        [HttpPut]
        public async Task<IActionResult> AddMessage(
            [FromBody] PersonalChatAddMessageCommand query,
            CancellationToken cancellationToken)
        {
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : HandleFailure(response);
        }


        //[Authorize]
        [HttpDelete("{personalChatId:guid}")]
        public async Task<IActionResult> Delete(
            Guid personalChatId,
            CancellationToken cancellationToken)
        {
            var command = new PersonalChatDeleteCommand(personalChatId);
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : HandleFailure(response);
        }
    }
}

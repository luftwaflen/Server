using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IChatService _chatService;

        public ChatController(IUserService userService, IChatService chatService)
        {
            _userService = userService;
            _chatService = chatService;
        }

        [HttpGet("GetChatMessages")]
        public async Task<IActionResult> GetChatMessages(string chatId)
        {
            var chat = await _chatService.GetChatMessages(Guid.Parse(chatId));
            var response = new List<MessageResponse>();
            foreach (var message in chat)
            {
                response.Add(new MessageResponse(message.Id, message.Sender.Login, message.Text));
            }
            return Ok(response);
        }

        [HttpGet("GetUserChats")]
        public async Task<IActionResult> GetUserChats(string userId)
        {
            var chats = await _chatService.GetUserChats(Guid.Parse(userId));
            var response = new List<ChatResponse>();
            foreach (var chat in chats)
            {
                response.Add(new ChatResponse(chat.Id, chat.Name));
            }

            return Ok(response);
        }

        [HttpGet("GetChat")]
        public async Task<IActionResult> GetChat(string chatId)
        {
            var chat = await _chatService.GetChat(Guid.Parse(chatId));
            var response = new ChatResponse(chat.Id, chat.Name);
            return Ok(response);
        }

        [HttpPost("AddChatMessage")]
        public async Task<IActionResult> AddChatMessage(AddChatMessageRequest request)
        {
            var chat = await _chatService.AddMessage(Guid.Parse(request.SenderId), Guid.Parse(request.ChatId),
                request.Text);
            var response = new List<MessageResponse>();
            foreach (var message in chat)
            {
                response.Add(new MessageResponse(message.Id, message.Sender.Login, message.Text));
            }
            return Ok(response);
        }

        [HttpPost("CreateChat")]
        public async Task<IActionResult> CreateChat(CreateChatRequest request)
        {
            var newChat = new Chat(request.ChatName);
            await _chatService.AddAsync(newChat);
            await _chatService.AddUser(newChat.Id, Guid.Parse(request.FirstUserId));
            await _chatService.AddUser(newChat.Id, Guid.Parse(request.SecondUserId));
            var chats = await _chatService.GetUserChats(Guid.Parse(request.FirstUserId));
            var response = new List<ChatResponse>();
            foreach (var chat in chats)
            {
                response.Add(new ChatResponse(chat.Id, chat.Name));
            }

            return Ok(response);
        }
    }
}

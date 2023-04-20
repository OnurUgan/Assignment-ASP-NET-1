﻿using Backend.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public class MessageRequest
    {
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;

        public static implicit operator MessageEntity(MessageRequest req)
        {
            return new MessageEntity
            {
                Email = req.Email,
                Message = req.Message,
            };
        }
    }
}

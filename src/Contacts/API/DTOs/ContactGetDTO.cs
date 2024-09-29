﻿
namespace API.DTOs
{
    public class ContactGetDTO
    {
        public Guid Id { get; set; }    
        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
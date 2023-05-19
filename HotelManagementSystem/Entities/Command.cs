using System;
namespace HotelManagementSystem.Entities
{
    public class Command
    {
        public string? CommandName { get; set; }

        public string[] CommandParams { get; set; } = { };
    }
}


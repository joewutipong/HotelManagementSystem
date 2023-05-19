using System;
namespace HotelManagementSystem.Entities
{
    public class Hotel
    {
        public int Floor { get; set; }

        public int RoomPerFloor { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}


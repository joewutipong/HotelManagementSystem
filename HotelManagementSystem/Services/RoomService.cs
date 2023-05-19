using System;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Services
{
    public class RoomService
    {
        public void listAvailableRooms(List<Room> rooms)
        {
            List<Room> availableRoom = rooms.Where(temp => temp.CanBooking()).ToList();

            Console.WriteLine(string.Join(", ", availableRoom.Select(temp => temp.RoomNumber).ToArray()));
        }
    }
}


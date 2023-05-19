using System;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Services
{
    public class HotelService
    {
        public const int MaxFloor = 9;
        public const int MaxRoomPerFloor = 99;

        public Hotel CreateHotel(string[] commandParams)
        {
            int floor = Convert.ToInt32(commandParams[0]);
            int roomPerFloor = Convert.ToInt32(commandParams[1]);

            Hotel hotel = new Hotel()
            {
                Floor = floor <= MaxFloor ? floor : MaxFloor,
                RoomPerFloor = roomPerFloor <= MaxRoomPerFloor ? roomPerFloor : MaxRoomPerFloor
            };

            for (int currentFloor = 1; currentFloor <= hotel.Floor; currentFloor++)
            {
                for (int roomNumber = 1; roomNumber <= hotel.RoomPerFloor; roomNumber++)
                {
                    hotel.Rooms.Add(new Room()
                    {
                        Floor = currentFloor,
                        RoomNumber = (currentFloor * 100) + roomNumber
                    });
                }
            }

            Console.WriteLine($"Hotel created with {hotel.Floor} floor(s), {hotel.RoomPerFloor} room(s) per floor.");

            return hotel;
        }
    }
}


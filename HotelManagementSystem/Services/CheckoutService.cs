using System;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Services
{
    public class CheckoutService
    {
        public List<Room> Checkout(List<Room> rooms, string[] commandParams)
        {
            int keycardNumber = Convert.ToInt32(commandParams[0]);
            string guestName = commandParams[1];

            Room? room = rooms.Where(temp => temp.Booking?.KeycardNumber == keycardNumber).FirstOrDefault();

            if (room != null)
            {
                if (room.Booking?.GuestName != guestName)
                {
                    Console.WriteLine($"Only {room.Booking?.GuestName} can checkout with keycard number {room.Booking?.KeycardNumber}.");
                    return rooms;
                }

                room.Checkout();
                Console.WriteLine($"Room {room.RoomNumber} is checkout.");
            }

            return rooms;
        }

        public List<Room> CheckoutByFloor(List<Room> rooms, string[] commandParams)
        {
            int floor = Convert.ToInt32(commandParams[0]);

            List<Room> roomsForCheckout = rooms.Where(temp => temp.Floor == floor && temp.IsBooked()).ToList();

            string[] bookedRoomNumbers = new string[] { };
            foreach (Room room in roomsForCheckout)
            {
                room.Checkout();
            }

            Console.WriteLine($"Room {string.Join(", ", roomsForCheckout.Select(temp => temp.RoomNumber).ToArray())} are checkout.");

            return rooms;
        }
    }
}


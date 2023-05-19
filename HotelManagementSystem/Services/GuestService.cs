using System;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Services
{
    public class GuestService
    {
        public void ListGuests(List<Room> rooms)
        {
            List<Room> bookedRooms = rooms.Where(r => r.IsBooked())
                .DistinctBy(r => r.Booking?.GuestName)
                .OrderBy(r => r.Booking?.KeycardNumber)
                .ToList();

            Console.WriteLine($"{string.Join(", ", bookedRooms.Select(r => r.Booking?.GuestName).ToArray())}");
        }

        public void ListGuestsByAge(List<Room> rooms, string[] commandParams)
        {
            string inputOperator = commandParams[0];
            int guestAge = Convert.ToInt32(commandParams[1]);

            Func<Room, bool> condition;
            switch (inputOperator)
            {
                case "=":
                    condition = room => room.Booking?.GuestAge == guestAge;
                    break;
                case "==":
                    condition = room => room.Booking?.GuestAge == guestAge;
                    break;
                case "<":
                    condition = room => room.Booking?.GuestAge < guestAge;
                    break;
                case "<=":
                    condition = room => room.Booking?.GuestAge <= guestAge;
                    break;
                case ">":
                    condition = room => room.Booking?.GuestAge > guestAge;
                    break;
                case ">=":
                    condition = room => room.Booking?.GuestAge >= guestAge;
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    return;
            }

            List<Room> filtered = rooms.Where(condition).ToList();

            Console.WriteLine($"{string.Join(", ", filtered.Select(room => room.Booking?.GuestName).ToArray())}");
        }

        public void ListGuestsByFloor(List<Room> rooms, string[] commandParams)
        {
            int floor = Convert.ToInt32(commandParams[0]);

            List<Room> filtered = rooms.Where(room => room.Floor == floor && room.IsBooked()).ToList();

            Console.WriteLine($"{string.Join(", ", filtered.Select(room => room.Booking?.GuestName).ToArray())}");
        }

        public void GetGuestInRoom(List<Room> rooms, string[] commandParams)
        {
            int roomNumber = Convert.ToInt32(commandParams[0]);

            Room? room = rooms.Where(r => r.RoomNumber == roomNumber && r.IsBooked()).FirstOrDefault();

            if (room != null)
            {
                Console.WriteLine(room.Booking?.GuestName);
            }
        }
    }
}


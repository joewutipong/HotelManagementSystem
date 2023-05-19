using System;
using System.Collections.Generic;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Services
{
    public class BookingService
    {
        public List<Room> CreateBooking(List<Room> rooms, string[] commandParams)
        {
            int roomNumber = Convert.ToInt32(commandParams[0]);
            string guestName = commandParams[1];
            int guestAge = Convert.ToInt32(commandParams[2]);

            Room? room = rooms.Where(temp => temp.RoomNumber == roomNumber).FirstOrDefault();

            if (room != null)
            {
                if (!room.CanBooking())
                {
                    Console.WriteLine($"Cannot book room {roomNumber} for {guestName}, The room is currently booked by {room.Booking?.GuestName}.");

                    return rooms;
                }

                room.CreateBooking(guestName, guestAge, GetAvailableKeycardNumber(rooms));

                Console.WriteLine($"Room {room.RoomNumber} is booked by {room.Booking?.GuestName} with keycard number {room.Booking?.KeycardNumber}.");
            }

            return rooms;
        }

        public List<Room> CreateBookingByFloor(Hotel hotel, string[] commandParams)
        {
            int floor = Convert.ToInt32(commandParams[0]);
            string guestName = commandParams[1];
            int guestAge = Convert.ToInt32(commandParams[2]);

            List<Room> availableRooms = hotel.Rooms.Where(temp => temp.Floor == floor && temp.CanBooking()).ToList();

            if (availableRooms.Count() < hotel.RoomPerFloor)
            {
                Console.WriteLine($"Cannot book floor {floor} for {guestName}.");
                return hotel.Rooms;
            }

            List<string> bookedRoomNumbers = new List<string>();
            List<string> bookedKeycardNumber = new List<string>();
            foreach (Room room in availableRooms)
            {
                room.CreateBooking(guestName, guestAge, GetAvailableKeycardNumber(hotel.Rooms));

                bookedRoomNumbers.Add(room.RoomNumber.ToString());
                bookedKeycardNumber.Add(room.Booking?.KeycardNumber.ToString());
            }

            Console.WriteLine($"Room {string.Join(", ", bookedRoomNumbers)} " +
                $"are booked with keycard number " +
                $"{string.Join(", ", bookedKeycardNumber)}");

            return hotel.Rooms;
        }

        private int GetAvailableKeycardNumber(List<Room> rooms)
        {
            int?[] keyCards = rooms.Where(temp => temp.Booking?.KeycardNumber != null)
                .Select(temp => temp.Booking?.KeycardNumber)
                .OrderBy(temp => temp)
                .ToArray();

            int current = 1;
            for (int i = 0; i < keyCards.Count(); i++)
            {
                if (current != keyCards[i])
                {
                    return current;
                }

                current++;
            }

            return current;
        }
    }
}


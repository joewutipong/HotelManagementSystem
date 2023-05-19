using System;
using System.IO;
using System.Reflection;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;

internal class Program
{
    private static Hotel _hotel;

    private static HotelService _hotelService = new HotelService();
    private static BookingService _bookingService = new BookingService();
    private static RoomService _roomService = new RoomService();
    private static CheckoutService _checkoutService = new CheckoutService();
    private static GuestService _guestService = new GuestService();
    private static CommandService _commandService = new CommandService();

    private static void Main(string[] args)
    {
        try
        {
            string[] lines = File.ReadAllLines("Files/input.txt");

            foreach (string line in lines)
            {
                Command command = _commandService.GetCommand(line);

                switch (command.CommandName)
                {
                    case "create_hotel":
                        _hotel = _hotelService.CreateHotel(command.CommandParams);
                        break;
                    case "book":
                        _hotel.Rooms = _bookingService.CreateBooking(_hotel.Rooms, command.CommandParams);
                        break;
                    case "book_by_floor":
                        _hotel.Rooms = _bookingService.CreateBookingByFloor(_hotel, command.CommandParams);
                        break;
                    case "checkout":
                        _hotel.Rooms = _checkoutService.Checkout(_hotel.Rooms, command.CommandParams);
                        break;
                    case "checkout_guest_by_floor":
                        _hotel.Rooms = _checkoutService.CheckoutByFloor(_hotel.Rooms, command.CommandParams);
                        break;
                    case "list_available_rooms":
                        _roomService.listAvailableRooms(_hotel.Rooms);
                        break;
                    case "list_guest":
                        _guestService.ListGuests(_hotel.Rooms);
                        break;
                    case "list_guest_by_age":
                        _guestService.ListGuestsByAge(_hotel.Rooms, command.CommandParams);
                        break;
                    case "list_guest_by_floor":
                        _guestService.ListGuestsByFloor(_hotel.Rooms, command.CommandParams);
                        break;
                    case "get_guest_in_room":
                        _guestService.GetGuestInRoom(_hotel.Rooms, command.CommandParams);
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}
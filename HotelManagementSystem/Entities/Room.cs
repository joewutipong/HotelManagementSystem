using System;
namespace HotelManagementSystem.Entities
{
    public class Room
    {
        public int Floor { get; set; }

        public int RoomNumber { get; set; }

        public Booking? Booking { get; set; }

        public bool CanBooking()
        {
            return Booking is null;
        }

        public bool IsBooked()
        {
            return Booking is not null;
        }

        public void Checkout()
        {
            Booking = null;
        }

        public void CreateBooking(string guestName, int guestAge, int keycardNumber)
        {
            Booking = new Booking()
            {
                GuestName = guestName,
                GuestAge = guestAge,
                KeycardNumber = keycardNumber
            };
        }
    }
}


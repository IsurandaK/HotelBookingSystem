
#nullable disable
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Rooms = new HashSet<Room>();
        }

        public int BookingId { get; set; }
        public int TotalRooms { get; set; }
        public int Price { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        //Relationships
        public int CustomerId { get; set; }
        public int HotelId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
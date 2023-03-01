
#nullable disable
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int RoomPrice { get; set; }
        public string RoomAvailability { get; set; }

        //Relationships
        public int CustomerId { get; set; }
        public int? BookingId { get; set; }
        public int? HotelId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}

#nullable disable
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddressLine1 { get; set; }
        public string HotelAddressLine2 { get; set; }
        public string District { get; set; }
        public string HotelDiscription { get; set; }
        public string Availability { get; set; }

        //Relationships
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
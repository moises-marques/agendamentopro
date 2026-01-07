using System;

namespace AgendamentoPro.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public string Status { get; set; } = "Pending";
    }
}

using ConsoleApp1.Models.Enums;

namespace ConsoleApp1.Models
{
    public class Booking
    {
        public DateTime Date { get; set; }
        public OpeningHours TimeSlot { get; set; } // 0 from 17 to 19, 1 from 19 to 21
        public int Tables { get; set; }

        public override string ToString()
        {
            return $"Antal borde: {Tables} Dato: {Date.ToString("D")}, Tidspunkt: {(TimeSlot == OpeningHours.FirstHalf ? "klokken. 17 til 19" : "klokken 19 til 21")}";
        }
    }
}

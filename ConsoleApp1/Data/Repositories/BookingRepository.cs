using ConsoleApp1.Data.Repositories.Constants;
using ConsoleApp1.Models;
using ConsoleApp1.Models.Enums;
using ConsoleApp1.Processing.Utils;
using System.Text.Json;

namespace ConsoleApp1.Data.Repositories
{
    public static class BookingRepository
    {
        public static List<Tuple<DateTime, List<Booking>>> DatesWithBookings { get; } = new List<Tuple<DateTime, List<Booking>>>();

        public static void ImportBooking()
        {
            var customers = JSONLoader.LoadFromJson<List<Customer>>(FilePaths.Customers);

            foreach (var customer in customers)
            {
                if (customer.Bookings.Any())
                {
                    foreach (var booking in customer.Bookings)
                    {
                        AddBooking(booking);
                    }
                }
            }
        }

        public static void Book(DateTime newDate, int tables, OpeningHours timeSlot)
        {
            var booking = new Booking
            {
                Date = newDate,
                Tables = tables,
                TimeSlot = timeSlot
            };

            AddBooking(booking);

            //SaveToFile(booking);

            Console.WriteLine($"Booking booket: {booking}");
            Console.ReadKey();
            Console.Clear();
            Processor.Navigation();
        }

        private static void AddBooking(Booking booking)
        {
            var date = DatesWithBookings.Find(x => x.Item1 == booking.Date);

            if (date != null)
            {
                date.Item2.Add(booking);
            }
            else
            {
                DatesWithBookings.Add(Tuple.Create(booking.Date, new List<Booking>() { booking }));
            }
        }

        //private static void SaveToFile(Booking booking)
        //{
        //    var customer = new Customer("Bruger", new List<Booking>() { booking });

        //    var bookings = DatesWithBookings.SelectMany(x => x.Item2);
        //    var json = JsonSerializer.Serialize(bookings);

        //    File.WriteAllText(FilePaths.Customers, json);
        //}
    }
}

using ConsoleApp1.Data.Repositories;
using ConsoleApp1.Models;
using ConsoleApp1.Models.Enums;
using ConsoleApp1.Processing.Utils;

namespace ConsoleApp1.Processing.Services
{
    public static class BookingService
    {
        private static readonly int _tables = 10;
        private static readonly int _seatsAtTable = 4;

        public static void ShowBookingsMenu()
        {
            ShowBookingMenu();

            var input = Console.ReadLine();

            if (input == null || !input.All(char.IsDigit) || !int.TryParse(input, out var number) || number > 15)
            {
                Console.Clear();
                ShowBookingsMenu();
            }
            else
            {
                Console.Clear();
                var now = DateTime.Now;
                var newDate = now.AddDays(int.Parse(input)).Date;

                ShowBookings(newDate);
            }
        }

        public static void ShowBookings(DateTime? date = null)
        {
            var bookingsToShow = new List<Booking>();

            if (date != null)
            {
                bookingsToShow = BookingRepository.DatesWithBookings.Find(x => x.Item1 == date)?.Item2;
            }
            else
            {
                bookingsToShow = BookingRepository.DatesWithBookings.SelectMany(x => x.Item2).ToList();
            }

            if (bookingsToShow != null && bookingsToShow.Any())
            {
                ConsoleHelpers.PrintArray(bookingsToShow.OrderBy(x => x.Date).ToList());
            }
            else
            {
                Console.WriteLine("Ingen bookings");
            }

            Console.ReadKey();
            Console.Clear();
            Processor.Navigation();
        }

        public static void BookInitialize()
        {
            Console.Clear();
            ShowBookingMenu();

            var input = Console.ReadLine();

            if (input == null || !input.All(char.IsDigit) || !int.TryParse(input, out var number) || number > 15)
            {
                BookInitialize();
            }
            else
            {
                Console.Clear();
                var now = DateTime.Now;
                var newDate = now.AddDays(int.Parse(input)).Date;
                Console.WriteLine($"Du har valgt at booke d. {newDate.ToString("D")}");
                Console.WriteLine("Fortsæt! [ENTER]");
                Console.WriteLine("Annuller! [ESC]");

                var key = Console.ReadKey();
                Console.Clear();

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Vælg antal gæster (maks. 40)");
                    var guestInput = Console.ReadLine();

                    if (guestInput == null || !guestInput.All(char.IsDigit) || !int.TryParse(guestInput, out var guestNumber) || guestNumber > 40)
                    {
                        BookInitialize();
                    }
                    else
                    {
                        var tablesNeededForSeats = int.Parse(guestInput) / _seatsAtTable;

                        var timeSlotsOpen = ReturnAvailableBookingsForDate(newDate, tablesNeededForSeats);

                        if (timeSlotsOpen.Count == 0)
                        {
                            Console.WriteLine("Der er desværre ingen ledige bookinger på denne dato [ENTER]");
                            Console.ReadKey();
                            BookInitialize();
                        }
                        else
                        {
                            Console.WriteLine("Vælg tidsvindue");

                            foreach (var item in timeSlotsOpen)
                            {
                                Console.WriteLine($"{(item == OpeningHours.FirstHalf ? "Klokken 17 til 19 [1]" : "Klokken 19 til 21 [2]")}");
                            }

                            var timeSlotKey = Console.ReadKey();
                            Console.Clear();

                            if (timeSlotsOpen.Contains(OpeningHours.FirstHalf) && timeSlotKey.Key == ConsoleKey.D1)
                            {
                                BookingRepository.Book(newDate, tablesNeededForSeats, OpeningHours.FirstHalf);
                            }

                            if (timeSlotsOpen.Contains(OpeningHours.SecondHalf) && timeSlotKey.Key == ConsoleKey.D2)
                            {
                                BookingRepository.Book(newDate, tablesNeededForSeats, OpeningHours.SecondHalf);
                            }
                        }
                    }
                }

                BookInitialize();
            }
        }

        private static List<OpeningHours> ReturnAvailableBookingsForDate(DateTime date, int tables)
        {
            var bookings = BookingRepository.DatesWithBookings.Find(x => x.Item1 == date)?.Item2;
            var timeSlotsOpen = new List<OpeningHours>();

            var tableCountFirstHalf = bookings?.Where(x => x.TimeSlot == OpeningHours.FirstHalf).Sum(x => x.Tables);
            var tableCountSecondHalf = bookings?.Where(x => x.TimeSlot == OpeningHours.SecondHalf).Sum(x => x.Tables);

            if (tableCountFirstHalf + tables <= _tables || tableCountFirstHalf == null)
            {
                timeSlotsOpen.Add(OpeningHours.FirstHalf);
            }
            if (tableCountSecondHalf + tables <= _tables || tableCountSecondHalf == null)
            {
                timeSlotsOpen.Add(OpeningHours.SecondHalf);
            }

            return timeSlotsOpen;
        }

        private static void ShowBookingMenu()
        {
            Console.WriteLine("d-------------------BOOKING-------------------b");
            Console.WriteLine("Skriv hvor mange dage i fremtiden du ønsker at se. OBS: Du kan kun booke / se 15 dage ud i fremtiden");
        }
    }
}

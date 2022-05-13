using ConsoleApp1.Data.Repositories;
using ConsoleApp1.Processing.Services;
using ConsoleApp1.Processing.Utils;

namespace ConsoleApp1
{
    public static class Processor
    {
        private static bool _firstTime = true;

        public static void Navigation()
        {
            if (_firstTime)
            {
                InitializeRepositories();
            }

            ConsoleHelpers.ShowMainMenu();

            var keyInfo = Console.ReadKey();
            Console.Clear();

            if (keyInfo.Key == ConsoleKey.D1)
            {
                EmployeeService.ShowEmployeeInformation();
                ConsoleHelpers.ShowReturnToMainMenu();
            }

            if (keyInfo.Key == ConsoleKey.D2)
            {
                BookingService.BookInitialize();
                ConsoleHelpers.ShowReturnToMainMenu();
            }

            if (keyInfo.Key == ConsoleKey.D3)
            {
                BookingService.ShowBookings();
            }

            if (keyInfo.Key == ConsoleKey.D4)
            {
                BookingService.ShowBookingsMenu();
            }

            if (keyInfo.Key == ConsoleKey.D5)
            {
                CustomerService.ShowCustomerInformation();
                ConsoleHelpers.ShowReturnToMainMenu();
            }
        }

        private static void InitializeRepositories()
        {
            BookingRepository.ImportBooking();
            CustomerRepository.ImportCustomers();
            EmployeeRepository.ImportEmployees();

            _firstTime = false;
        }
    }
}

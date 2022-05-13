using ConsoleApp1.Data.Repositories;
using ConsoleApp1.Processing.Utils;

namespace ConsoleApp1.Processing.Services
{
    public static class EmployeeService
    {
        public static void ShowEmployeeInformation()
        {
            ConsoleHelpers.PrintArray(EmployeeRepository.Chefs);
            ConsoleHelpers.PrintArray(EmployeeRepository.Helpers);
            ConsoleHelpers.PrintArray(EmployeeRepository.Waiters);
        }
    }
}

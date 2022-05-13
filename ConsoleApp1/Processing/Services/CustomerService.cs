using ConsoleApp1.Data.Repositories;
using ConsoleApp1.Processing.Utils;

namespace ConsoleApp1.Processing.Services
{
    public class CustomerService
    {
        public static void ShowCustomerInformation()
        {
            ConsoleHelpers.PrintArray(CustomerRepository.Customers);
        }
    }
}

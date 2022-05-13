using ConsoleApp1.Data.Repositories.Constants;
using ConsoleApp1.Models;
using ConsoleApp1.Processing.Utils;

namespace ConsoleApp1.Data.Repositories
{
    public static class CustomerRepository
    {
        public static List<Customer> Customers { get; private set; } = new List<Customer>();

        public static void ImportCustomers()
        {
            Customers = JSONLoader.LoadFromJson<List<Customer>>(FilePaths.Customers);
        }
    }
}

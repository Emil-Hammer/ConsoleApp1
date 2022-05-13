using ConsoleApp1.Data.Repositories.Constants;
using ConsoleApp1.Models.Employees;
using ConsoleApp1.Processing.Utils;

namespace ConsoleApp1.Data.Repositories
{
    public static class EmployeeRepository
    {
        public static List<KitchenEmployee> Chefs { get; private set; } = new List<KitchenEmployee>();
        public static List<KitchenEmployee> Helpers { get; private set; } = new List<KitchenEmployee>();
        public static List<Waiter> Waiters { get; private set; } = new List<Waiter>();

        public static void ImportEmployees()
        {
            if (!Chefs.Any() || !Helpers.Any() || !Waiters.Any())
            {
                Chefs = JSONLoader.LoadFromJson<List<KitchenEmployee>>(FilePaths.Chefs);
                Helpers = JSONLoader.LoadFromJson<List<KitchenEmployee>>(FilePaths.Helpers);
                Waiters = JSONLoader.LoadFromJson<List<Waiter>>(FilePaths.Waiters);
            }
        }
    }
}

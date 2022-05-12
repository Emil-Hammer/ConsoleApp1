using ConsoleApp1.models;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public static class Processor
    {
        public static List<IEmployee> ImportEmployees()
        {
            return LoadFromJson<List<IEmployee>>("Data/employees.json");
        }

        public static List<Customer> ImportCustomers()
        {
            return LoadFromJson<List<Customer>>("Data/customers.json");
        }

        private static T LoadFromJson<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            var json = reader.ReadToEnd();
            if (json != null)
            {
                var obj = JsonConvert.DeserializeObject<T>(json);

                if (obj != null)
                {
                    return obj;
                }
            }

            throw new FileLoadException($"Could not load {filePath} correctly.");
        }
    }
}

using ConsoleApp1.Models;

namespace ConsoleApp1.models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Booking> Bookings { get; set; }

        public Customer(string name, List<Booking> bookings, Guid? id)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Bookings = bookings;
        }
    }
}

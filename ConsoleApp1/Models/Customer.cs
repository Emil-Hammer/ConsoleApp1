namespace ConsoleApp1.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Booking> Bookings { get; set; }

        public Customer(string name, List<Booking> bookings, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Bookings = bookings;
        }

        public override string ToString()
        {
            var str = $"Id: {Id}, Navn: {Name}";

            if (Bookings.Any())
            {
                str += ", Bookings: ";

                foreach (var booking in Bookings)
                {
                    str += $"{booking} ";
                }
            }

            return str;
        }
    }
}

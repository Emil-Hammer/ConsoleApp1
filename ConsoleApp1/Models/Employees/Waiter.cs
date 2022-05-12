namespace ConsoleApp1.models
{
    public class Waiter : IEmployee
    {
        public bool AllowedCustomerCallTaking { get; set; }

        // Interface properties
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime JoinedOn { get; set; }

        public Waiter(string name, string address, DateTime joinedOn, bool allowedCustomerCallTaking)
        {
            Name = name;
            Address = address;
            JoinedOn = joinedOn;
            AllowedCustomerCallTaking = allowedCustomerCallTaking;
        }
    }
}

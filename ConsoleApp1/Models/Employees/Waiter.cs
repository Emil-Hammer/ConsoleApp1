namespace ConsoleApp1.Models.Employees
{
    public class Waiter : Employee
    {
        public bool AllowedCustomerCallTaking { get; set; }

        // Inherited properties
        public override string Name { get; set; }
        public override string Address { get; set; }
        public override DateTime JoinedOn { get; set; }

        public Waiter(string name, string address, DateTime joinedOn, bool allowedCustomerCallTaking)
        {
            Name = name;
            Address = address;
            JoinedOn = joinedOn;
            AllowedCustomerCallTaking = allowedCustomerCallTaking;
        }

        public override string ToString()
        {
            return $"Navn: {Name}, Adresse: {Address}, Ansættelsesdato: {JoinedOn}, Må tage kundetelefonen: {(AllowedCustomerCallTaking ? "Ja" : "Nej")}";
        }
    }
}

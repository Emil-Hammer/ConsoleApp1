namespace ConsoleApp1.Models.Employees
{
    public abstract class Employee
    {
        public abstract string Name { get; set; }
        public abstract string Address { get; set; }
        public abstract DateTime JoinedOn { get; set; }
    }
}

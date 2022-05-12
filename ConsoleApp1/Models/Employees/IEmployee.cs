namespace ConsoleApp1.models
{
    public interface IEmployee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime JoinedOn { get; set; }
    }
}

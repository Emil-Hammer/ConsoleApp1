namespace ConsoleApp1.models
{
    public class KitchenEmployee : IEmployee
    {
        public DateTime DateOfBirth { get; set; }
        public string Specialization { get; set; }
        public string OtherExpertise { get; set; }

        // Interface properties
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime JoinedOn { get; set; }

        public KitchenEmployee(DateTime dateOfBirth, string specialization, string otherExpertise, string name, string address, DateTime joinedOn)
        {
            DateOfBirth = dateOfBirth;
            Specialization = specialization;
            OtherExpertise = otherExpertise;
            Name = name;
            Address = address;
            JoinedOn = joinedOn;
        }
    }
}

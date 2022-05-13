namespace ConsoleApp1.Models.Employees
{
    public class KitchenEmployee : Employee
    {
        public DateTime DateOfBirth { get; set; }
        public string Specialization { get; set; }
        public string OtherExpertise { get; set; }

        // Inherited properties
        public override string Name { get; set; }
        public override string Address { get; set; }
        public override DateTime JoinedOn { get; set; }

        public KitchenEmployee(DateTime dateOfBirth, string specialization, string otherExpertise, string name, string address, DateTime joinedOn)
        {
            DateOfBirth = dateOfBirth;
            Specialization = specialization;
            OtherExpertise = otherExpertise;
            Name = name;
            Address = address;
            JoinedOn = joinedOn;
        }

        public override string ToString()
        {
            return $"Navn: {Name}, Adresse: {Address}, Fødselsdag: {DateOfBirth}, Ansættelsesdato: {JoinedOn}, Specialitet: {Specialization}, Anden ekspertise: {OtherExpertise}";
        }
    }
}

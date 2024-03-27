namespace HalloEfCore.Model
{
    public class Customer : Person
    {
        public required string KdNummer { get; set; }
        public Employee? ContactPerson { get; set; }
    }

}

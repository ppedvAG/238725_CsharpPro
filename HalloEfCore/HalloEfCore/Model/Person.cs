namespace HalloEfCore.Model
{
    public abstract class Person : Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string City { get; set; }
    }

}

using System.Diagnostics.CodeAnalysis;

namespace HalloEfCore.Model
{
    public class Employee : Person
    {
        public string Job { get; set; } = string.Empty;

        [SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "<Pending>")]
        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        [SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "<Pending>")]
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }

}

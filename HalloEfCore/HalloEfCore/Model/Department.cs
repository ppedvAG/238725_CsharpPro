using System.Diagnostics.CodeAnalysis;

namespace HalloEfCore.Model
{
    public class Department : Entity
    {
        public required string Name { get; set; }

        [SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "<Pending>")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }

}

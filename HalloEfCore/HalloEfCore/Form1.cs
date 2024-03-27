using Bogus;
using HalloEfCore.Data;
using HalloEfCore.Model;
using Microsoft.EntityFrameworkCore;

namespace HalloEfCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is IEnumerable<Customer> customers)
            {
                e.Value = string.Join(", ", customers.Select(x => $"{x.FirstName} {x.LastName}"));
            }
            else if (e.Value is IEnumerable<Department> deps)
            {
                e.Value = string.Join(", ", deps.Select(x => $"{x.Name}"));
            }
        }

        EfContext con = new EfContext();

        private async void button1_Click(object sender, EventArgs e)
        {
            con = new EfContext();
            con.Database.EnsureDeleted();
            con.Database.EnsureCreated();

            await con.Employees.AddRangeAsync(BogusConfig.EmployeeFaker.Generate(100));

            int rows = await con.SaveChangesAsync();
            MessageBox.Show("Rows: " + rows);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await con.Employees.Include(x => x.Customers)
                                                          .Include(x => x.Departments)
                                                          .Where(x => x.Job.Length > 3)
                                                          .ToListAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.SaveChanges();
        }
    }

    public static class BogusConfig
    {
        public static Faker<Department> DepartmentFaker = new Faker<Department>()
            .RuleFor(o => o.Name, f => f.Commerce.Department());

        public static Faker<Employee> EmployeeFaker = new Faker<Employee>("de_AT")
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.Job, f => f.Name.JobTitle())
            .RuleFor(o => o.Customers, f => CustomerFaker.Generate(f.Random.Int(1, 5)))
            .RuleFor(o => o.Departments, f => DepartmentFaker.Generate(f.Random.Int(1, 3)));

        public static Faker<Customer> CustomerFaker = new Faker<Customer>()
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.KdNummer, f => f.Random.Replace("K###-####"));
    }
}

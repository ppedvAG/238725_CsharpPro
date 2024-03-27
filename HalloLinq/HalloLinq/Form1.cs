namespace HalloLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DemoDatenGen().GetDemoCars();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from c in new DemoDatenGen().GetDemoCars()
                        where c.KW > 100 && c.BuildDate.Year > 2000
                        orderby c.KW descending, c.BuildDate descending
                        select c;

#if !DEBUG
            query = query.Where(x => x.Manufacturer.StartsWith("M"));
#endif  

            dataGridView1.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DemoDatenGen().GetDemoCars(1000)
                                                         .Where(x => x.KW > 100 && x.BuildDate.Year > 2000)
                                                         .OrderByDescending(x => x.KW)
                                                         .ThenByDescending(x => x.BuildDate)
                                                         .ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var car = new DemoDatenGen().GetDemoCars(100).FirstOrDefault(x => x.KW > 150);

            if (car != null)
                MessageBox.Show($"{car.Manufacturer} {car.Model} {car.KW}");
            else
                MessageBox.Show("Nix");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Durchschnitt: {new DemoDatenGen().GetDemoCars().Average(x => x.KW)} KW");

            int maxKW = new DemoDatenGen().GetDemoCars().Max(x => x.KW);
            Car mostKW = new DemoDatenGen().GetDemoCars().MaxBy(x => x.KW);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var groups = new DemoDatenGen().GetDemoCars().GroupBy(x => x.Manufacturer);

            treeView1.Nodes.Clear();

            foreach (var group in groups)
            {
                var node = new TreeNode(group.Key);
                foreach (var car in group)
                {
                    node.Nodes.Add(new TreeNode($"{car.Manufacturer} {car.Model} {car.KW}"));
                }
                treeView1.Nodes.Add(node);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DemoDatenGen().GetDemoCars().Select(x => new { Hersteller = x.Manufacturer, PS = x.KW / 5 }).ToList();

            var msg = string.Join(" 🚗 ", new DemoDatenGen().GetDemoCars(10).Select(x => x.Manufacturer));
            MessageBox.Show(msg);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var c1 = new Car { Id = 8 };
            var c2 = new Car { Id = 8 };


            Car car3 = flowLayoutPanel1.Controls[4] as Button;

            MessageBox.Show($"{c1 == c2}");
        }
    }
}

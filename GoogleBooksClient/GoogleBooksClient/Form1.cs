using System.Text;
using System.Text.Json;

namespace GoogleBooksClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={textBox1.Text}&maxResults=40";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);

            BooksResult result = JsonSerializer.Deserialize<BooksResult>(json);

            dataGridView1.DataSource = result.items.Select(x => x.volumeInfo).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog()
            {
                Filter = "JSON-Datei|*.json;*.jsn|Irgendeine Datei|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true // Für besser lesbare Ausgabe
                };
                var json = JsonSerializer.Serialize(dataGridView1.DataSource, options);
                File.WriteAllText(dlg.FileName, json);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Filter = "JSON-Datei|*.json;*.jsn|Irgendeine Datei|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var json = await File.ReadAllTextAsync(dlg.FileName);
                dataGridView1.DataSource = JsonSerializer.Deserialize<IEnumerable<Volumeinfo>>(json);
            }
        }
    }
}

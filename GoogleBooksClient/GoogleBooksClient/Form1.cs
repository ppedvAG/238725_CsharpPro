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
    }
}

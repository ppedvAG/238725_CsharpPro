using Azure.Identity;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is IEnumerable<Volumeinfo> volumes)
            {
                var conString = "Server=(localdb)\\mssqllocaldb;Database=Books;Trusted_Connection=true";
                var con = new SqlConnection(conString);
                con.Open();

                foreach (var volume in volumes)
                {
                    var cmd = con.CreateCommand();
                    cmd.CommandText = @"INSERT INTO VolumeInfo (Title, Subtitle, Publisher, PublishedDate, Description, PageCount, PrintType, MaturityRating, AllowAnonLogging, ContentVersion, Language, PreviewLink, InfoLink, CanonicalVolumeLink)  
                                        VALUES (@Title, @Subtitle, @Publisher, @PublishedDate, @Description, @PageCount, @PrintType, @MaturityRating, @AllowAnonLogging, @ContentVersion, @Language, @PreviewLink, @InfoLink, @CanonicalVolumeLink)";

                    cmd.Parameters.AddWithValue("@Title", volume.title);
                    cmd.Parameters.AddWithValue("@Subtitle", volume.subtitle ?? "");
                    cmd.Parameters.AddWithValue("@Publisher", volume.publisher ?? "");
                    cmd.Parameters.AddWithValue("@PublishedDate", volume.publishedDate);
                    cmd.Parameters.AddWithValue("@Description", volume.description ?? "");
                    cmd.Parameters.AddWithValue("@PageCount", volume.pageCount);
                    cmd.Parameters.AddWithValue("@PrintType", volume.printType);
                    cmd.Parameters.AddWithValue("@MaturityRating", volume.maturityRating);
                    cmd.Parameters.AddWithValue("@AllowAnonLogging", false); // Für BIT Spalten, verwenden Sie true/false
                    cmd.Parameters.AddWithValue("@ContentVersion", volume.contentVersion);
                    cmd.Parameters.AddWithValue("@Language", volume.language);
                    cmd.Parameters.AddWithValue("@PreviewLink", volume.previewLink);
                    cmd.Parameters.AddWithValue("@InfoLink", volume.infoLink);
                    cmd.Parameters.AddWithValue("@CanonicalVolumeLink", volume.canonicalVolumeLink);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=Books;Trusted_Connection=true";
            var con = new SqlConnection(conString);
            con.Open();

            var cmd = con.CreateCommand();
            //cmd.CommandText = $"SELECT count(*) FROM VolumeInfo WHERE Title LIKE '{textBox1.Text}%'";
            cmd.CommandText = $"SELECT count(*) FROM VolumeInfo WHERE Title LIKE @search";
            cmd.Parameters.AddWithValue("@search", textBox1.Text + "%");

            var rows = cmd.ExecuteScalar();

            MessageBox.Show($"Rows: {rows}");
        }
    }
}

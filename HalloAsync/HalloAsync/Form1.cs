namespace HalloAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(1000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    progressBar1.Invoke(() => { progressBar1.Value = i; Console.Beep(); });
                    Thread.Sleep(100);
                }
            }).ContinueWith(t =>
            {
                button2.Invoke(() => button2.Enabled = true);
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            button2.Enabled = false;
            cts = new CancellationTokenSource();
            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Factory.StartNew(() => progressBar1.Value = i, CancellationToken.None, TaskCreationOptions.None, ts);
                    Thread.Sleep(100);

                    if (cts.IsCancellationRequested)
                    {
                        //clean
                        cts.Token.ThrowIfCancellationRequested();
                        break;
                    }
                }
            }, cts.Token);
            t1.ContinueWith(t => button2.Enabled = true, ts);
            t1.ContinueWith(t => MessageBox.Show("Abbruch erfolgreich"), TaskContinuationOptions.OnlyOnCanceled);
        }

        CancellationTokenSource cts;

        private void button4_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;

            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }

            button5.Enabled = true;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(AlteFunction(599).ToString());
                progressBar1.Style = ProgressBarStyle.Marquee;
                cts = new CancellationTokenSource();
                MessageBox.Show((await AlteFunctionAsync(599, cts.Token)).ToString());
                progressBar1.Style = ProgressBarStyle.Continuous;
            }
            catch (AggregateException tex) when (tex.InnerException is TaskCanceledException) 
            {
                MessageBox.Show("Abbruch erfolgreich");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
        }

        private long AlteFunction(int value)
        {
            Thread.Sleep(5000);
            return value * 3;
        }

        private long AlteFunctionCt(int value, CancellationToken token)
        {
            Task.Delay(5000, token).Wait();
            return value * 3;
        }

        private Task<long> AlteFunctionAsync(int value)
        {
            return Task.Run(() => AlteFunction(value));
        }

        private Task<long> AlteFunctionAsync(int value, CancellationToken token)
        {

            return Task.Run(() => AlteFunctionCt(value, token));

        }
    }
}

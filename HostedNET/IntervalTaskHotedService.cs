namespace HostedNET
{
    public class IntervalTaskHotedService : IHostedService, IDisposable
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SaveFile, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        public void SaveFile(object state)
        {
            string nameFIle = "a" + new Random().Next() + ".txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", nameFIle);
            File.Create(path);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

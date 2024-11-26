using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private EventLog eventLog;
        private Timer _timer;
        private Random _random;

        private string filePath = string.Empty;
        private string content = string.Empty;

        public Service1()
        {
            InitializeComponent();
            _random = new Random();


            // Initialize the EventLog instance
            eventLog = new System.Diagnostics.EventLog();

            // Check if the event source exists, if not create it
            if (!EventLog.SourceExists("MyServiceSource"))
            {
                EventLog.CreateEventSource("MyServiceSource", "Logmonitor test");
            }

            // Set the source and log name
            eventLog.Source = "MyServiceSource - Nov24";
            eventLog.Log = "MyServiceLog - Nov24";

        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("OnStart! Logmonitor test");
            eventLog.WriteEntry("OnStart!...- Logmonitor test");

            WriteCustomLogs();
        }

        protected override void OnStop()
        {
            Console.WriteLine("OnStop!....- Logmonitor test");
            eventLog.WriteEntry("OnStop!....- Logmonitor test");
        }

        protected void WriteCustomLogs()
        {
            try
            {
                filePath = @"C:\app\log.txt";
                content = "My super win service started....OnStart Logmonitor test";

                File.AppendAllText(filePath, content);

                Console.WriteLine(content);

                _timer = new Timer();
                _timer.Interval = 10000;
                _timer.Elapsed += OnTimerElapsed;
                _timer.AutoReset = true;
                _timer.Enabled = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in OnStart: {ex.Message}");
                File.AppendAllText(filePath, $"Exception in OnStart: {ex.Message}");
            }
            File.AppendAllText(filePath, "done");
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Console.WriteLine("Timer elapsed: " + DateTime.Now);
                File.AppendAllText(filePath, "Timer elapsed: " + DateTime.Now);

                ThrowRandomException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in OnTimerElapsed: {ex.Message}");
            }
        }

        private void ThrowRandomException()
        {
            int exceptionType = _random.Next(8);
            switch (exceptionType)
            {
                case 0:
                    throw new InvalidOperationException("Random InvalidOperationException");
                case 1:
                    throw new ArgumentNullException("Random ArgumentNullException");
                case 2:
                    throw new NotImplementedException("Random NotImplementedException");
                case 3:
                    throw new Exception("Random General exception");
                default:
                    Console.WriteLine($"You are lucky this time!");
                    File.AppendAllText(filePath, $"You are lucky this time!");
                    break;
            }
        }

    }
}

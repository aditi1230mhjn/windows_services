using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace HeartbeatService
{
    public class Heartbeat
    {
        private readonly Timer timer;
        public Heartbeat()
        {
            //repeat interval as 1 second (1000ms)
            timer = new Timer(1000) { AutoReset = true };
            timer.Elapsed += TimerElapsed;
            //An Event is called every one second and the method below is executed.

        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Users\maditi\source\repos\DemoApp\temp.txt", lines);
        }

        public void Start()
        {
            //Stats the Service
            timer.Start();
        }

        public void Stop()
        {
            //Stops the service
            timer.Stop();
        }
    }
}

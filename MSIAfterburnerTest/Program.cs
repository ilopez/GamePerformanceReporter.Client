using MSI.Afterburner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSIAfterburnerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                HardwareMonitor hm = new HardwareMonitor();
                HardwareMonitorEntry fps = hm.GetEntry(HardwareMonitor.GPU_GLOBAL_INDEX, MONITORING_SOURCE_ID.FRAMERATE);
                if (fps != null)
                {
                    float prevfps = 0;
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    uint count = 0;
                    ulong prevtime = 0;
                    ulong curtime = 0;
                    while (true)
                    {
                        curtime = Convert.ToUInt64((DateTime.UtcNow - new DateTime(1970,1,1,0,0,0)).TotalSeconds);
                        if (prevtime != curtime)
                        {                            
                            Console.WriteLine("S," + curtime + ",,");
                        }
                        if(prevfps != fps.Data){                            
                            sw.Stop();
                            Console.WriteLine("D,"+sw.ElapsedMilliseconds + "," + fps.Data + ",");
                            sw.Restart();                            
                        }
                        prevfps = fps.Data;
                        prevtime = curtime;
                        hm.ReloadEntry(fps);
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("FPS not available");
                }
            }
        }
    }
}

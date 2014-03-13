using MSI.Afterburner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePerfReporter
{
    public class RTSS
    {
        private static HardwareMonitor hm;
        private static HardwareMonitorEntry fps;
        public RTSS()
        {
            hm = new HardwareMonitor();
            fps = hm.GetEntry(HardwareMonitor.GPU_GLOBAL_INDEX, MONITORING_SOURCE_ID.FRAMERATE);
        }

        public float getFPS()
        {
            hm.ReloadEntry(fps);
            return fps.Data;
        }

    }
}

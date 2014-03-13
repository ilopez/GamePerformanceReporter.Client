using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePerfReporter;
using GamePerformanceReporter;
using System.Diagnostics;


namespace GamePerfReporter
{
    public class ApiTest
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WebApi k = new WebApi("cfe61296-71ee-462f-bafc-67956c4342f4", "http://10.9.9.1:8080/");
                int start = Environment.TickCount;
                

                Report nr = new Report();
                nr.SystemGUID = "ABC123123123";

                ReportAttribute ra1 = new ReportAttribute();
                ra1.Key = "Name";
                ra1.Value = "Israel";

                nr.ReportAttribute.Add(ra1);

                ReportFile rf1 = new ReportFile();
                rf1.FileType = "PAYLOAD";
                rf1.FileHash = "HASH";                
                rf1.FileName = "payload.zip";
                rf1.FileSizeBytes = 123123123;

                nr.ReportFile.Add(rf1);

                Report savedReport = k.newReport(nr);

                Debug.WriteLine("TEST");

            }
        }
    }
}

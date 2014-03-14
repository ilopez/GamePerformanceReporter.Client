
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePerfReporter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static String gameProcessPath;
        public static String gameProcessWindowTitle;
        public static int gameProcessID;
        public static String rtssLogFilePath;
        private static string epxFilename = "EVGAPrecision.exe";
        private static string epxConfig = "EVGAPrecision.cfg";
        private static string msiFilename = "MSIAfterburner.exe";
        private static string msiConfig = "MSIAfterburner.cfg";
        public static bool gameFound = false;

        [STAThread]
        static void Main()
        {
            initGUID();
            initDefaultSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        private static void initDefaultSettings()
        {
            S.Default.SuspectedIssueKeyCode = Keys.None;
        }

        internal static String getDxDiagData()
        {
            try
            {
                String temppath = System.IO.Path.GetTempPath();
                String filename = string.Format("dxdiag-{0:yyyy-MM-dd_hh-mm-ss-tt}.xml", DateTime.Now);
                String command = "dxdiag.exe";
                String args = "/x " + temppath + filename;
                Process p = null;
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = command;
                psi.Arguments = args;
                psi.Verb = "runas";
                psi.WindowStyle = ProcessWindowStyle.Normal;
                psi.UseShellExecute = true;

                p = Process.Start(psi);
                p.WaitForExit();

                byte[] b = System.IO.File.ReadAllBytes(temppath + filename);
                string ret = System.Text.Encoding.UTF8.GetString(b);
                File.Delete(temppath + filename);
                return ret;
            }
            catch
            {
                return String.Empty;
            }
        }

        internal static void initGUID()
        {
            if (S.Default.GUID.Length == 0 || S.Default.GUID == String.Empty)
            {
                S.Default.GUID = Guid.NewGuid().ToString();
                S.Default.Save();
            }
        }

        internal static Boolean findGame(Game g)
        {
            try
            {
                Process p = findProcess(g.ProcessName);
                if (p != null)
                {
                    gameProcessID = p.Id;
                    gameProcessPath = p.MainModule.FileName;
                    Debug.WriteLine(gameProcessPath);
                    gameProcessWindowTitle = p.MainWindowTitle;
                    Debug.WriteLine(gameProcessWindowTitle);
                    if (gameProcessWindowTitle != String.Empty && gameProcessPath != String.Empty)
                    {
                        gameFound = true;
                        return true;
                    }
                    else
                    {
                        gameFound = false;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                return false;
            }
            
        }

        internal static Boolean findMSIAfterburner()
        {
            Process p = findProcess(msiFilename);
            if (p != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static Process findProcess(String procname)
        {
            foreach (Process P in Process.GetProcesses())
            {                
                try
                {                                       
                    if (P.MainModule.FileName.Contains(procname))
                    {                                              
                        return P;
                    }
                }
                catch
                {
                    // Ignore
                }
            }
            return null; // Couldnt find a process
        }
        internal static String findRTSSLogFilePath()
        {
            String epxLog = findRTSSConfig(epxFilename, epxConfig);
            String msiLog = findRTSSConfig(msiFilename, msiConfig);
            if (epxLog != String.Empty)
            {
                return epxLog;
            }
            else if (msiLog != String.Empty)
            {
                return msiLog;
            }else{
                return String.Empty;
            }
        }

        private static string findRTSSConfig(String procname,String ConfigName)
        {
            String proc = findProcessPath(procname);
            if (proc != String.Empty)
            {
                String dir = Path.GetDirectoryName(proc);
                String config = dir + "/Profiles/"+ConfigName;
                IniParser p = new IniParser(config);
                String logfile = p.GetSetting("Settings", "LogPath");
                if (logfile.Length > 0)
                {
                    return logfile;
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                return String.Empty;
            }
        }

        internal static string findProcessPath(string procname)
        {
            try
            {
                return findProcess(procname).MainModule.FileName;
            }
            catch
            {
                return String.Empty;
            }
        }



        internal static Dictionary<string, byte[]> getGameFilesCleaned(Game curGame)
        {
            Dictionary<string, byte[]> ret = new Dictionary<string, byte[]>();

            foreach (String s in curGame.FilesToCollect)
            {
                try
                {
                    ret.Add(s, File.ReadAllBytes(Path.GetDirectoryName(gameProcessPath) + s));
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Could Not Get Game File: " + s);
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.StackTrace);
                }
            }

            return ret;
        }

        internal static byte[] getRTSSFileData(string RTSSLogFile)
        {
            return File.ReadAllBytes(RTSSLogFile);
        }

        //internal static byte[] packageUploadData(Dictionary<string, byte[]> gameFiles, byte[] RTSSData, string DXDiagData)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        using (ZipFile z = new ZipFile())
        //        {
        //            if (gameFiles.Count > 0)
        //            {
        //                foreach (KeyValuePair<string, byte[]> kvp in gameFiles)
        //                {
        //                    z.AddEntry(kvp.Key, kvp.Value);
        //                }
        //            }
        //            if (RTSSData != null && RTSSData.Length > 0)
        //            {
        //                z.AddEntry("RTSS.csv", RTSSData);
        //            }
        //            if (DXDiagData != null && DXDiagData.Length > 0)
        //            {
        //                z.AddEntry("dxdiag.xml", DXDiagData);
        //            }

        //            z.Save(ms);
        //        }
        //        return ms.ToArray();
        //    }

        //}



        internal static bool checkAPI()
        {
            return false;
        }



        internal static void takeScreenshot(int processID, string OutputFile)
        {
            var proc = Process.GetProcessById(processID);
            var rect = new User32.Rect();
            User32.GetWindowRect(proc.MainWindowHandle, ref rect);

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

            bmp.Save(OutputFile, ImageFormat.Png);            
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        }
    }

    
}

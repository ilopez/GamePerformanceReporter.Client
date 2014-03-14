using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePerfReporter
{
    public partial class Upload : Form
    {
        private static Game curGame;
        private static Boolean iGameFiles;
        private static Boolean iRTSS;
        private static String RTSSLogFile;
        private static Boolean iDXDiag;
        private static String usernotes;

        public Upload(Game g, Boolean IncludeGameFiles, Boolean IncludeRTSS, String RTSSFile, Boolean IncludeDXDiag, String notes )
        {
            curGame = g;
            iGameFiles = IncludeGameFiles;
            iRTSS = IncludeRTSS;
            RTSSLogFile = RTSSFile;
            iDXDiag = IncludeDXDiag;
            usernotes = notes;

            InitializeComponent();
                        
            bgWorker.RunWorkerAsync();
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            UploadLog("Starting Upload Log");
            UploadLog("Uploading Game: " + curGame.Name);
            UploadLog("Game Title: " + Program.gameProcessWindowTitle);
            UploadLog("Including Game Files? " + iGameFiles.ToString());
            UploadLog("Including RTSS Log? " + iRTSS.ToString());
            UploadLog("RTSS File: " + RTSSLogFile);
            UploadLog("Including Dx Diag? " + iDXDiag.ToString());
            UploadLog("Notes: " + usernotes);
            Dictionary<String, byte[]> gameFiles = new Dictionary<string,byte[]>();
            byte[] RTSSData = null;
            String DXDiagData = String.Empty;
            if (iGameFiles)
            {
                UploadLog("Preparing Game Files");
                gameFiles = Program.getGameFilesCleaned(curGame);
                UploadLog("Game Files Ready");
            }
            if (iRTSS)
            {
                UploadLog("Preparing RTSS Data");
                RTSSData = Program.getRTSSFileData(RTSSLogFile);
                UploadLog("RTSS Data Ready");
            }
            if (iDXDiag)
            {
                UploadLog("Preparing Dx Diag Data");
                DXDiagData = Program.getDxDiagData();
                UploadLog("Dx Diag Data Ready");
            }

            //byte[] package = Program.packageUploadData(gameFiles, RTSSData, DXDiagData);

            //UploadLog("File To Upload Size: " + package.LongLength.ToString());

            //UploadLog("Preparing to Submit Report");


            
        }

        private void UploadLog(String msg)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(delegate { tbUploadLog.AppendText(msg+"\n"); }));
            }
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbPrep.Value = e.ProgressPercentage;
        }
    }
}

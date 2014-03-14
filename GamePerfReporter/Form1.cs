
using MovablePython;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GamePerfReporter
{
    public partial class Form1 : Form
    {
        private Hotkey hkSuspectedIssue;

        private static Game currentGame;
        private static Series currentFPSData;
        private static Series movingaverage;
        private static Series directTrend;
        private static Series hitchTrend;
        private static Boolean MSIAfterburnerAvailable = false;
        private static Boolean logLiveFPS = true;
        private static Boolean updateFPSDisplays = true;
        private static Telemetry fpsdata = new Telemetry(1000,3000,.65,.85);
        private static RTSS rt = null;

        public Form1()
        {
            InitializeComponent();
            setupGameList();
            if (!bwCheckAPI.IsBusy)
            {
                //bwCheckAPI.RunWorkerAsync();
            }
            if (!bWFindGame.IsBusy)
            {
                bWFindGame.RunWorkerAsync();
            }
            if (!bwFindRTSSConfig.IsBusy)
            {
                //bwFindRTSSConfig.RunWorkerAsync();
            }            
            if (!bwUpdateGraph.IsBusy)
            {
                bwUpdateGraph.RunWorkerAsync();
            }
            if (!bwFindMSIAfterburner.IsBusy)
            {
                bwFindMSIAfterburner.RunWorkerAsync();
            }
            tbSystemID.Text = S.Default.GUID;

            setupGraph();

            ckLiveFPS.Checked = logLiveFPS;
            ckUpdateScreen.Checked = updateFPSDisplays;

            toolTip.SetToolTip(this.tbNotes, "DO NOT SUPPLY ANY IDENTIFYING INFORMATION. \nTHIS WILL BE POSTED PUBICLY.");

            setupHotKey();

            setupControlsLiveFPS(MSIAfterburnerAvailable);
            
        }

        private void setupControlsLiveFPS(bool MSIAfterburnerAvailable)
        {
            if (MSIAfterburnerAvailable)
            {
                ckLiveFPS.Visible = true;
                ckUpdateScreen.Visible = true;
                labelLogStatus.Text = "MSI Afterburner Ready";
            }
            else
            {
                ckLiveFPS.Visible = false;
                ckUpdateScreen.Visible = false;
                labelLogStatus.Text = "MSI Afterburner Not Found";
            }
        }

        private void setupHotKey()
        {
            hkSuspectedIssue = new Hotkey();

            if (S.Default.SuspectedIssueKeyCode != Keys.None)
            {
                tBSuspectedIssueHotKey.Text = S.Default.SuspectedIssueKeyCode.ToString();
                updateHotKeyHandler(S.Default.SuspectedIssueKeyCode);
            }
        }

        private void setupGraph()
        {
            chartFPS.Size = new Size(260, 322);

            chartFPS.DataSource = fpsdata.fpsData;
            currentFPSData = new Series("FPS")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "chartArea",
                Color = Color.White,
                XValueMember = "MS",
                YValueMembers = "FPSData"
            };
            movingaverage = new Series("MA")
            {
                ChartType = SeriesChartType.Spline,
                ChartArea = "chartArea",
                Color = Color.Yellow
            };
            directTrend = new Series("DT")
            {                
                ChartType = SeriesChartType.Spline,
                ChartArea = "chartArea",
                Color = Color.Red,
            };
            hitchTrend = new Series("HT")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "chartArea",    
                CustomProperties = "PixelPointWidth=2",
                Color = Color.LimeGreen

            };

            var chartArea = new ChartArea("chartArea")
            {
                AxisX =
                {
                    LineWidth = 0,
                    IntervalType = DateTimeIntervalType.NotSet,
                    LabelStyle = { Enabled = false },
                    MajorGrid = { LineWidth = 0 },
                    MajorTickMark = { LineWidth = 0 }
                }
                ,
                AxisY =
                {
                    LineWidth = 0,
                    LabelStyle = { Enabled = false },
                    MajorGrid = { LineWidth = 0 },
                    IsStartedFromZero = false

                }
                ,
                BackColor = Color.Black
            };

            chartFPS.ChartAreas.Add(chartArea);

            chartFPS.Series.Add(currentFPSData);
            chartFPS.Series.Add(movingaverage);
            chartFPS.Series.Add(directTrend);
            chartFPS.Series.Add(hitchTrend);

            chartFPS.DataBind();




        }

        private void setupGameList()
        {
            cbGameList.DataSource = Data.getGameList().GameList;
            cbGameList.DisplayMember = "Name";
            cbGameList.ValueMember = null;
        }

        private void bDxDiag_Click(object sender, EventArgs e)
        {
            
        }

        private void bRTSS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FilterIndex = 3;
            ofd.Multiselect = false;
            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                tbRTSSPath.Text = ofd.FileName;
            }else{
                
            }

        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            Upload uf = new Upload((Game)cbGameList.SelectedItem, ckIncludeGameFiles.Checked, ckIncludeRTSS.Checked, tbRTSSPath.Text, ckIncludeDxDiag.Checked, tbNotes.Text );
            uf.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("http://ilopez.com");
            Process.Start(psi);
        }

        private void bWFindGame_DoWork(object sender, DoWorkEventArgs e)
        {
            int cnt = 1;
            Thread.Sleep(1000);
            while (!Program.gameFound && currentGame != null && cnt <= 6)
            {

                Boolean gamefound = Program.findGame(currentGame);
                if (!gamefound)
                {
                    Thread.Sleep((2 * cnt) * 1000);
                }
                cnt++;
            }
        }

        private void bWFindGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            findGameLabel.Text = "Game Found!";
            if (!bwGetLiveFPSData.IsBusy)
            {
                bwGetLiveFPSData.RunWorkerAsync();
            }
        }

        private void cbGameList_SelectedValueChanged(object sender, EventArgs e)
        {
            currentGame = (Game)cbGameList.SelectedItem;
            if (!bWFindGame.IsBusy)
            {
                bWFindGame.RunWorkerAsync();
            }
        }

        private void bwFindRTSSConfig_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 1;
            while ((Program.rtssLogFilePath == null || Program.rtssLogFilePath == String.Empty) && count <= 3)
            {
                Program.rtssLogFilePath = Program.findRTSSLogFilePath();
                if (Program.rtssLogFilePath.Contains("MSIAfterburner"))
                {
                    MSIAfterburnerAvailable = true;
                }
                count++;
                Thread.Sleep((4^count) * 1000);
            }
        }

        private void bwFindRTSSConfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Program.rtssLogFilePath != null && (tbRTSSPath.Text.Length == 0 && Program.rtssLogFilePath.Length > 0))
            {
                tbRTSSPath.Text = Program.rtssLogFilePath;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"This application logs and monitors 3D Framerate performance.  There is no implied warranty, and the software is distributed AS-IS.

In no event shall Israel Lopez be liable to you or any party related to you for any indirect, incidental, consequential, special, exemplary, or punitive damages or lost profits, even if Israel Lopez has been advised of the possibility of such damages.
In any event, Israel Lopez total aggregate liability to you for all damages of every kind and type (regardless of whether based in contract or tort) shall not exceed the purchase price of the product.  Which is zero.
            ");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
@"This application is distributed with the Apache 2 license.

http://www.apache.org/licenses/LICENSE-2.0.html

The MSI Afterburner .NET library is included with the permission of the author, Nick Connors. ");
        }

        private void bwCheckAPI_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean checkSystem = true;
            int cnt = 1;
            while (checkSystem)
            {
                Boolean r = Program.checkAPI();
                checkSystem = !r;
                if (checkSystem)
                {
                    Thread.Sleep((2^cnt) * 100); // Exponential Backoff
                }
                cnt++;
            }
        }

        private void bwCheckAPI_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.systemCheck.Text = "Report Submission System Ready";
        }

        private void testApiButton_Click(object sender, EventArgs e)
        {

        }

        private void bwGetLiveFPSData_DoWork(object sender, DoWorkEventArgs e)
        {            
            double curfps = 0;
            int count = 0;
            while (true)
            {
                if (MSIAfterburnerAvailable && rt != null && Program.gameFound )
                {
                    if (logLiveFPS)
                    {

                        FPSDataGraph(true);
                        curfps = rt.getFPS();

                        Hitch h;


                        lock (fpsdata.lockQueue)
                        {
                            h = fpsdata.FPSUpdate(curfps);
                        }
                        if (updateFPSDisplays && count == 2 )
                        {
                            UpdateFPSLabel(curfps);
                            count = 0;
                        }
                        if (h != null && h.Type != HitchType.None) { UpdateFPSChart(); SystemDetectedIssue(h); }
                        count++;
                        Thread.Sleep(50);
                    }
                    else
                    {
                        FPSDataGraph(false);
                        curfps = 0;
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            
        }

        private void UpdateFPSLabel(double fps)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(delegate {                                   
                    labelFPS.Text = Math.Round(fps,2).ToString();
                    if (labelFPS.ForeColor == Color.DarkGray)
                    {
                        labelFPS.ForeColor = Color.Gray;
                    }
                    else
                    {
                        labelFPS.ForeColor = Color.DarkGray;
                    }
                }));
            }
        }
        private void UpdateMSIStatus(bool update)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    setupControlsLiveFPS(update);                    
                }));
            }
        }
        private void SystemDetectedIssue(Hitch i)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    tbNotes.AppendText(fpsdata.sw.Elapsed.ToString("mm\\:ss\\.ff") + " - Detected " + i.Type.ToString() + " Hitch S: " + i.Strength.ToString() + " P: " + i.RepeatSeconds.ToString() + " F: " + i.MeasuredFPS.ToString() + " A: " + i.CurrentAverage.ToString() + System.Environment.NewLine);
                }));
            }
        }
        private void UpdateFPSChart()
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(delegate {
                    lock(fpsdata.lockQueue)
                    {                        
                        if (fpsdata.fpsData.Count > 2)
                        {
                            chartFPS.Series["DT"].Points.DataBindXY(fpsdata.velocityTrend.Select(x => x.MS).ToList(), fpsdata.velocityTrend.Select(x => (x.Vel >= 10 ? 10 : x.Vel)).ToList());
                            chartFPS.Series["MA"].Points.DataBindXY(fpsdata.avgData.Select(x => x.MS).ToList(), fpsdata.avgData.Select(x => x.FPSData).ToList());
                            if (fpsdata.hitchTrend.Count > 0)
                            {
                                try
                                {
                                    
                                    chartFPS.Series["HT"].Points.DataBindXY(fpsdata.hitchTrend.Select(x => x.MS).ToList(), fpsdata.hitchTrend.Select(x => x.CurrentAverage * 1.5).ToList());
                                }
                                catch { }
                            }
                            chartFPS.DataBind();
                        }
                        
                        
                    }
                }));
            }
        }
        private void FPSDataGraph(Boolean show)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(delegate {
                    if (chartFPS.Visible != show)
                    {
                        chartFPS.Visible = show;
                    }
                }));
            }
        }

        private void ckLiveFPS_CheckedChanged(object sender, EventArgs e)
        {
            logLiveFPS = ckLiveFPS.Checked;
            currentFPSData.Points.Clear();
        }

        private void bwUpdateGraph_DoWork(object sender, DoWorkEventArgs e)
        {            
            while (true)
            {
                if (logLiveFPS && updateFPSDisplays && MSIAfterburnerAvailable)
                {
                    
                    UpdateFPSChart();
                    Thread.Sleep((fpsdata.fpsData.Count <= 100 ? 250 + (fpsdata.fpsData.Count * 2) : 0) + (fpsdata.fpsData.Count > 100 ? 450 : 0));
                 
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private void tBSuspectedIssueHotKey_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }

        private void tBSuspectedIssueHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            tBSuspectedIssueHotKey.Text = e.KeyCode.ToString();
            updateHotKeyHandler(e.KeyCode);
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void updateHotKeyHandler(Keys newkey)
        {
            if (hkSuspectedIssue.Registered)
            {
                hkSuspectedIssue.Unregister();
            }
            else
            {
                hkSuspectedIssue.KeyCode = newkey;
                hkSuspectedIssue.Pressed += handleSuspectedIssueHotKey;
                if (!hkSuspectedIssue.GetCanRegister(this))
                {
                    Debug.WriteLine("Cant Setup the Global Hotkey");
                }
                else
                {
                    hkSuspectedIssue.Register(this);
                }
                S.Default.SuspectedIssueKeyCode = newkey;
                S.Default.Save();
            }
        }

        private void handleSuspectedIssueHotKey(object sender, HandledEventArgs e)
        {
            
            if (fpsdata != null)
            {
                if (fpsdata.sw.IsRunning)
                {
                    fpsdata.SuspectedIssueLog();
                    tbNotes.AppendText(fpsdata.sw.Elapsed.ToString("mm\\:ss\\.ff") + " - Detected User Hitch S: " + fpsdata.Strength() + " F: " + fpsdata.FPS() + " A: " + fpsdata.roundRobinAverage() + System.Environment.NewLine);
                }
            }

            // Take a screenshot
            TakeScreenshots();


            e.Handled = true;
        }

        private void TakeScreenshots()
        {
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                String dte = string.Format("{0:yyyy-MM-dd_hh-mm-ss}", DateTime.Now);
                String file = currentGame.Name + "_" + dte + "_GRAPH_" + ".PNG";
                chartFPS.SaveImage(path + file, ChartImageFormat.Png);
                String ss = currentGame.Name + "_" + dte + "_GAME_" + ".PNG";
                Program.takeScreenshot(Program.gameProcessID, path + ss);
            }
            catch
            {
                // If there is an exception, ignore it for now.
            }
        } 

        private void ckUpdateScreen_CheckedChanged(object sender, EventArgs e)
        {
            updateFPSDisplays = ckUpdateScreen.Checked;

        }

        private void tBSuspectedIssueHotKey_Enter(object sender, EventArgs e)
        {
            if (hkSuspectedIssue.Registered)
            {
                hkSuspectedIssue.Unregister();
            }
        }

        private void bwFindMSIAfterburner_DoWork(object sender, DoWorkEventArgs e)
        {
            int cnt = 1;
            while( !MSIAfterburnerAvailable && cnt <= 20 ){
                MSIAfterburnerAvailable = Program.findMSIAfterburner();
                if (MSIAfterburnerAvailable)
                {
                    UpdateMSIStatus(true);
                    rt = new RTSS();
                }                
                Thread.Sleep((4^cnt)*1000);
            }
        }

        




    }
}

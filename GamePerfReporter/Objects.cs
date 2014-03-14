using MathNet.Numerics.Statistics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GamePerfReporter
{
    public class Games
    {
        public IList<Game> GameList { get; private set; }

        public Games(IList<Game> G)
        {
            this.GameList = G;
        }
    }
 
    public class Game
    {
        public string Name { get; private set; }
        public string ProcessName { get; private set; }
        public List<String> FilesToCollect { get; private set; }

        public Game(String Name, String ProcessName, List<String> FilesToCollect)
        {
            this.Name = Name;
            this.ProcessName = ProcessName;
            this.FilesToCollect = FilesToCollect;
        }

    }

    public class FPS
    {
        public float MS { get; set; }
        public double FPSData { get; set; }

        public FPS(float newMS, double newFPS)
        {
            this.MS = newMS;
            this.FPSData = newFPS;
        }
    }
    public class Velocity
    {
        public float MS { get; set; }
        public double Vel { get; set; }
        public Velocity(float newMS, double newVel)
        {
            this.MS = newMS;
            this.Vel = newVel;
        }
    }

    public enum HitchType {Minor, Major, Repeated, None};

    public class Hitch
    {
        public float MS { get; set; }
        public HitchType Type { get;  set; }
        public int RepeatSeconds { get;  set; }
        public long Strength { get;  set; }
        public double MeasuredFPS { get; set; }
        public double CurrentAverage { get; set; }
        public Hitch()
        {
            this.Type = HitchType.None;
        }
        public Hitch(HitchType t, int Repeat, long strength)
        {
            this.Type = t;
            this.RepeatSeconds = Repeat;
            this.Strength = strength;
        }
    } 

    public class Telemetry
    {        
        public FixedSizedQueue<FPS> fpsData { get; private set; }
        public FixedSizedQueue<Velocity> velocityTrend { get; private set; }
        public FixedSizedQueue<FPS> velocityData { get; private set; }
        public FixedSizedQueue<FPS> avgData { get; private set; }
        public FixedSizedQueue<Hitch> hitchTrend { get; private set; }
        public StringBuilder fpsLog { get; private set;  }
        public StringBuilder siLog { get; private set; }
        public Stopwatch sw { get; private set; }
        private double[] FPSAverageSUM;
        private double pctFPSDropHigh;
        private double pctFPSDropLow;
        private int FPSAverageSUMIndex;
        private long lastDetectedProblem = 0;
        private long lastDetectedProblemThreshold = 0;
        private long lastDetectedProblemPeriod = 0;
        private int numberOfProblems = 0;
        private double currentfps = 0;
        


        public Object lockQueue = new Object();

        public Telemetry(uint recentSize,long minimumFlagTime,double pctFPSDropHigh, double pctFPSDropLow)
        {
            this.hitchTrend = new FixedSizedQueue<Hitch>(1);
            this.pctFPSDropHigh = pctFPSDropHigh;
            this.pctFPSDropLow = pctFPSDropLow;
            this.lastDetectedProblemThreshold = minimumFlagTime;
            this.fpsData = new FixedSizedQueue<FPS>(recentSize);
            this.velocityTrend = new FixedSizedQueue<Velocity>(recentSize);
            this.avgData = new FixedSizedQueue<FPS>(recentSize);

            FPSAverageSUM = new double[recentSize/5];
            FPSAverageSUMIndex = 0;
            this.velocityData = new FixedSizedQueue<FPS>(5);

            this.sw = new Stopwatch();
            sw.Start();
            this.fpsLog = new StringBuilder();
            this.siLog = new StringBuilder();
        }

        public SortedDictionary<String, double> getRecentFPSHistogram(int totalbins)
        {
            return this.Histo(this.fpsData.Select(l => Convert.ToDouble(l.FPSData)).ToList(), totalbins);
        }

        public void SuspectedIssueLog()
        {
            if (sw.IsRunning)
            {
                this.siLog.AppendLine(sw.ElapsedMilliseconds.ToString() + ",Suspected Issue,");
            }
        }

        public double FPS()
        {
            return currentfps;
        }

        public Hitch FPSUpdate(double inputFPS)
        {
            Hitch ret = CalculateFPSUpdate(inputFPS);
            if (ret.Type != HitchType.None)
            {
                this.hitchTrend.Enqueue( ret );
            }
            return ret;
        }

        private Hitch CalculateFPSUpdate(double inputFPS) 
        {
            if(hitchTrend.Count>0){
                Hitch k = hitchTrend.Peek();
                if (k != null)
                {
                    if (k.MS >= 20000)
                    {
                        hitchTrend.Dequeue();
                    }
                }
            }
            inputFPS =  Math.Round(inputFPS,1) ; // Whole Number FPS
            currentfps = inputFPS;
            if (FPSAverageSUMIndex == FPSAverageSUM.Length)
            {
                FPSAverageSUMIndex = 0;
            }
            else
            {
                FPSAverageSUMIndex++;
                FPSAverageSUM[FPSAverageSUMIndex-1] = inputFPS;
            }


            var curavg = roundRobinAverage();
            
            long time = this.sw.ElapsedMilliseconds;
            FPS n = new FPS(time, inputFPS);
            this.avgData.Enqueue(new FPS(time,Math.Round(curavg,2)));
            this.fpsData.Enqueue(n);

            

            FPSLog(n);

            this.velocityData.Enqueue(n);

            long curvel = Convert.ToInt64(Strength() * 500);
            if (curvel > 0)
            {
                curvel = 0;
            }

            Velocity v = new Velocity(time, curvel);

            this.velocityTrend.Enqueue(v);
            
            // Minimum of 10 FPS needed for average
            if (curavg > 10)
            {
                // If out current velocity is negative, the Input FPS is less than our average, and we arent triggering too many messages
                if ((curvel <= 0 && inputFPS < curavg) && ((time - lastDetectedProblem) > lastDetectedProblemThreshold))
                {

                    Hitch ret = new Hitch();
                    // If we have more than three problems and this problem occurs within a margin of an expected time, then it is considered repeated 
                    ret.MS = time;
                    ret.Strength = curvel;
                    ret.MeasuredFPS = inputFPS;
                    ret.CurrentAverage = curavg;
                    ret.RepeatSeconds = Convert.ToInt32(Math.Abs(time - lastDetectedProblem) / 1000);

                    
                    // If we dropped more than our high point - It is a Major Drop
                    if ( inputFPS < (curavg * pctFPSDropLow) && inputFPS > (curavg * pctFPSDropHigh) )
                    {
                        ret.Type = HitchType.Minor;
                        // Otherwise if we dropped between our high and low point its a Minor Drop
                    }
                    else if (inputFPS < (curavg * pctFPSDropHigh))
                    {
                        ret.Type = HitchType.Major;
                    }
                    

                    lastDetectedProblem = time;
                    lastDetectedProblemPeriod = (time - lastDetectedProblem);
                    numberOfProblems++;
                    return ret;
                }
                else
                {
                    return new Hitch();
                }
            }
            else
            {
                return new Hitch();
            }

            
        }

        public double roundRobinAverage()
        {
            return Math.Round(FPSAverageSUM.Sum() / FPSAverageSUM.Length,2);
        }

        public double Strength()
        {
            if (velocityData.Count > 2)
            {
                double averageX = velocityData.Average(d => d.MS);
                double averageY = velocityData.Average(d => d.FPSData);
                return velocityData.Sum(d => (d.MS - averageX) * (d.FPSData - averageY)) / velocityData.Sum(d => Math.Pow(d.MS - averageX, 2));
            }
            else
            {
                Debug.WriteLine("Strength is Zero");
                return 0;
            }
        }

        private void FPSLog(FPS d)
        {
            this.fpsLog.AppendLine(d.MS.ToString() + "," + d.FPSData.ToString());
        }

        internal SortedDictionary<String, double> Histo(IEnumerable<double> source, int totalbins)
        {
            SortedDictionary<String, double> ret = new SortedDictionary<string, double>();
            var h = new Histogram(source, totalbins);
            for (int i = 0; i < h.BucketCount; i++ )
            {
                Bucket b = h[i];
                ret.Add(i.ToString() + ": " +Math.Round(b.LowerBound,2).ToString() + "-" + Math.Round(b.UpperBound,2).ToString(), b.Count );
            }
            
            return ret;
        }

    }

    public class ExpirableHitch
    {
        public Hitch h {get; private set;}
        private Timer t;
        private FixedSizedQueue<ExpirableHitch> refQueue;

        public ExpirableHitch(Hitch h, uint TimeMS, FixedSizedQueue<ExpirableHitch> refQ)
        {
            this.h = h;
            this.refQueue = refQ;
            t = new Timer(TimeMS);
            t.Elapsed += new ElapsedEventHandler( Elapsed_Event );
            t.Start();
        }
        private void Elapsed_Event(object sender, ElapsedEventArgs e)
        {
            t.Elapsed -= new ElapsedEventHandler(Elapsed_Event);
            lock (refQueue.lockThis)
            {
                refQueue.Dequeue();
            }
        }
    }

    public class FixedSizedQueue<T> : Queue<T>
    {        
        public uint size { get; set; }
        public Object lockThis = new Object();

        public FixedSizedQueue(uint size)
        {
            this.size = size;
        }

        new public void Enqueue(T obj)
        {
            base.Enqueue(obj);
            lock (this)
            {
                
                while (base.Count > size)
                {
                    base.Dequeue();
                }                    
            }
        }
        
    }
}

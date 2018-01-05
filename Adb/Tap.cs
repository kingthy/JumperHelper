using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumperHelper.Adb
{
    class Tap
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public bool AutoP1 { get; private set; }
        public bool AutoP2 { get; private set; }

        public void Clear()
        {
            this.P1 = Point.Empty;
            this.P2 = Point.Empty;
            this.AutoP1 = this.AutoP2 = false;
        }
        public void Reset()
        {
            if (!this.AutoP1) this.P1 = Point.Empty;
            if (!this.AutoP2) this.P2 = Point.Empty;
        }
        public bool CanDo
        {
            get
            {
                return (this.P1 != Point.Empty && this.P2 != Point.Empty);
            }
        }
        public double Distance
        {
            get
            {
                if (!this.CanDo) return -1;
                int w = Math.Abs(this.P2.X - this.P1.X);
                int h = Math.Abs(this.P2.Y - this.P1.Y);
                return Math.Sqrt((double)(w * w) + (h * h));
            }
        }

        public double Rate
        {
            get;set;

        }

        public int Time
        {
            get
            {
                return (int)(this.Distance * this.Rate);
            }
        }

        public void FindPoint(Bitmap bitmap, bool findComboPoint)
        {
            Point comboPoint;
            this.P1 = FindPointImpl(bitmap, out comboPoint);
            this.AutoP1 = this.P1 != Point.Empty;
            if (findComboPoint)
            {
                this.P2 = comboPoint;
                this.AutoP2 = this.P2 != Point.Empty;
            }
        }

        public bool Do()
        {
            if (!this.CanDo) return false;

            var startInfo = new ProcessStartInfo("adb", string.Format("shell input swipe {0} {1} {0} {1} {2}", this.P1.X, this.P2.X, this.Time));
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = true;
            startInfo.UseShellExecute = false;
            var process = Process.Start(startInfo);
            return process.Start();
        }


        private static Point FindPointImpl(Bitmap bitmap, out Point comboPoint)
        {
            var standPColor = Color.FromArgb(54, 60, 102);
            var comboPColor = Color.FromArgb(245, 245, 245);

            Point standPoint = Point.Empty;
            comboPoint = Point.Empty;

            int y1 = (int)(bitmap.Height * 0.2);
            int y2 = (int)(bitmap.Height * 0.63);

            PixelFormat pf = PixelFormat.Format24bppRgb;

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, y1, bitmap.Width, y2), ImageLockMode.ReadOnly, pf);
            try
            {
                unsafe
                {
                    int w = 0;
                    while (y2 > y1)
                    {
                        byte* p = (byte*)bitmapData.Scan0 + (y2 - y1 - 1) * bitmapData.Stride;
                        w = bitmap.Width;
                        int endColorCount = 0;
                        while (w > 40)
                        {
                            ICColor* pc = (ICColor*)(p + w * 3);
                            if (standPoint == Point.Empty &&
                                pc->R == standPColor.R && pc->G == standPColor.G && pc->B == standPColor.B)
                            {
                                standPoint = new Point(w - 3, y2);
                                if (comboPoint != Point.Empty) break;
                            }
                            else if (comboPoint == Point.Empty)
                            {
                                if (pc->R == comboPColor.R && pc->G == comboPColor.G && pc->B == comboPColor.B)
                                {
                                    endColorCount++;
                                }
                                else
                                {
                                    if (endColorCount > 0)
                                    {
                                        comboPoint = new Point(w + 5, y2 - 1);
                                        if (standPoint != Point.Empty) break;
                                    }
                                    endColorCount = 0;
                                }
                            }
                            w--;
                        }
                        if (comboPoint == Point.Empty)
                        {
                            if (endColorCount > 10)
                            {
                                comboPoint = new Point(w + 5, y2 - 1);
                            }
                        }
                        if (standPoint != Point.Empty && comboPoint != Point.Empty) break;
                        y2--;
                    }
                }
                return standPoint;
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}

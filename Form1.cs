using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumperHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Adb.Tap tab = new Adb.Tap();

        private Bitmap CapturePhoneScreen()
        {
            var bitmap = Adb.Screencap.Capture();
            if (bitmap == null)
            {
                MessageBox.Show("无法连接到手机屏幕，请检查手机是否开启USB调戏并已连接电脑！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.pictureBox1.Top = 0;
                this.pictureBox1.Left = 0;
                this.pictureBox1.Location = new Point(0, 0);
                this.pictureBox1.Width = bitmap.Width;
                this.pictureBox1.Height = bitmap.Height;
                this.pictureBox1.Image = bitmap;
            }
            return bitmap;
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            var bitmap = this.CapturePhoneScreen();
            if (bitmap == null) return;

            tab.Clear();
            if (!this.cbMRate.Checked)
            {
                this.nudRate.Value = (decimal)(1495.00 / bitmap.Width);
            }
            tab.FindPoint(bitmap, this.cbAutoFindMPoint.Checked);
            if (tab.P1 == Point.Empty)
            {
                MessageBox.Show("没有找到跳跃起始点，请手动用鼠标[右键]点击图像位置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (this.cbAutoFindMPoint.Checked)
            {
                if(tab.P2 == Point.Empty)
                {
                    MessageBox.Show("没有找到跳跃落脚点，请手动用鼠标[左键]点击图像位置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            this.ShowDebug();
            this.canDo = true;

            if (tab.CanDo && this.cbClick2Jump.Checked) btnJump_Click(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.canDo)
            {
                if (e.Button == MouseButtons.Left)
                {
                    tab.P2 = CalPoint(e.Location);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    tab.P1 = CalPoint(e.Location);
                }
                this.ShowDebug();
                if (tab.CanDo && this.cbClick2Jump.Checked) btnJump_Click(sender, e);
            }
        }
  
        private Point CalPoint(Point p)
        {
            if (this.cbZoom.Checked && this.pictureBox1.Image != null)
            {
                var zoom = (double)this.pictureBox1.Height / this.pictureBox1.Image.Height;
                var width = (int)(this.pictureBox1.Image.Width * zoom);
                var left = this.pictureBox1.Width / 2 - width / 2;
                return new Point((int)((p.X - left) / zoom), (int)(p.Y / zoom));
            }
            else
            {
                return p;
            }
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            if (tab.CanDo)
            {
                this.canDo = false;
                tab.Rate = (double)this.nudRate.Value;
                if (tab.Do())
                {
                    this.totalTime = tab.Time + 2000;
                    this.isBusy = false;
                    this.timer1.Interval = 300;
                    this.timer1.Start();
                    this.timeTick = Environment.TickCount;
                }
            }
        }

        private int timeTick = 0;
        private int totalTime = 0;
        private bool isBusy = false;
        private bool canDo
        {
            get
            {
                return this.btnJump.Enabled;
            }
            set
            {
                this.btnJump.Enabled = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((Environment.TickCount - timeTick) > totalTime)
            {
                this.timer1.Stop();
                this.btnCapture_Click(sender, e);
            }
            else
            {
                if (!isBusy)
                {
                    Console.WriteLine(timeTick);
                    isBusy = true;
                    this.CapturePhoneScreen();
                    isBusy = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Dock = this.cbZoom.Checked ? DockStyle.Fill : DockStyle.None;
            tab.Reset();
            this.ShowDebug();
        }

        private void ShowDebug()
        {
            if (this.pictureBox1.Image == null) return;
            this.textBox1.Clear();
            if (tab.P1 != Point.Empty) this.lbXY1.Text = string.Format("起点 = {0} * {1}", tab.P1.X, tab.P1.Y);
            if (tab.P2 != Point.Empty) this.lbXY2.Text = string.Format("落脚 = {0} * {1}", tab.P2.Y, tab.P2.Y);
            if (tab.CanDo)
            {
                this.lbDistance.Text = string.Format("距离 = {0}px", tab.Distance.ToString("0.00"));
            }

            this.textBox1.AppendText(string.Format("Box = {0} * {1}\r\n", this.pictureBox1.Width, this.pictureBox1.Height));
            this.textBox1.AppendText(string.Format("Img = {0} * {1}\r\n", this.pictureBox1.Image.Width, this.pictureBox1.Image.Height));
            this.textBox1.AppendText(string.Format("Wr = {0:0.000}\r\n", (double)this.pictureBox1.Width / this.pictureBox1.Image.Width));
            this.textBox1.AppendText(string.Format("Hr = {0:0.000}\r\n", (double)this.pictureBox1.Height / this.pictureBox1.Image.Height));
            if (this.cbZoom.Checked)
            {
                var zoom = (double)this.pictureBox1.Height / this.pictureBox1.Image.Height;
                var width = (int)(this.pictureBox1.Image.Width * zoom);
                var left = this.pictureBox1.Width / 2 - width / 2;
                this.textBox1.AppendText(string.Format("Left = {0}\r\n", left));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.ShowDebug();
            if (this.cbZoom.Checked)
            {
                tab.Reset();
            }
        }

        private void cbMRate_CheckedChanged(object sender, EventArgs e)
        {
            this.lbRate.Visible = this.nudRate.Visible = this.cbMRate.Checked;
        }
    }
}

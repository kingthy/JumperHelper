namespace JumperHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbAutoFindMPoint = new System.Windows.Forms.CheckBox();
            this.cbMRate = new System.Windows.Forms.CheckBox();
            this.nudRate = new System.Windows.Forms.NumericUpDown();
            this.lbRate = new System.Windows.Forms.Label();
            this.cbClick2Jump = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbZoom = new System.Windows.Forms.CheckBox();
            this.lbDistance = new System.Windows.Forms.Label();
            this.lbXY2 = new System.Windows.Forms.Label();
            this.lbXY1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 462);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(547, 462);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnJump);
            this.panel2.Controls.Add(this.btnCapture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 62);
            this.panel2.TabIndex = 1;
            // 
            // btnJump
            // 
            this.btnJump.Enabled = false;
            this.btnJump.Location = new System.Drawing.Point(141, 7);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(101, 46);
            this.btnJump.TabIndex = 1;
            this.btnJump.Text = "跳一跳";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(12, 7);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(101, 46);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "开始连接";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbAutoFindMPoint);
            this.panel3.Controls.Add(this.cbMRate);
            this.panel3.Controls.Add(this.nudRate);
            this.panel3.Controls.Add(this.lbRate);
            this.panel3.Controls.Add(this.cbClick2Jump);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.cbZoom);
            this.panel3.Controls.Add(this.lbDistance);
            this.panel3.Controls.Add(this.lbXY2);
            this.panel3.Controls.Add(this.lbXY1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(547, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 462);
            this.panel3.TabIndex = 2;
            // 
            // cbAutoFindMPoint
            // 
            this.cbAutoFindMPoint.AutoSize = true;
            this.cbAutoFindMPoint.Checked = true;
            this.cbAutoFindMPoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoFindMPoint.Location = new System.Drawing.Point(6, 388);
            this.cbAutoFindMPoint.Name = "cbAutoFindMPoint";
            this.cbAutoFindMPoint.Size = new System.Drawing.Size(149, 19);
            this.cbAutoFindMPoint.TabIndex = 9;
            this.cbAutoFindMPoint.Text = "自动找跳跃落脚点";
            this.cbAutoFindMPoint.UseVisualStyleBackColor = true;
            // 
            // cbMRate
            // 
            this.cbMRate.AutoSize = true;
            this.cbMRate.Location = new System.Drawing.Point(7, 363);
            this.cbMRate.Name = "cbMRate";
            this.cbMRate.Size = new System.Drawing.Size(149, 19);
            this.cbMRate.TabIndex = 8;
            this.cbMRate.Text = "手动输入力度系数";
            this.cbMRate.UseVisualStyleBackColor = true;
            this.cbMRate.CheckedChanged += new System.EventHandler(this.cbMRate_CheckedChanged);
            // 
            // nudRate
            // 
            this.nudRate.DecimalPlaces = 3;
            this.nudRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRate.Location = new System.Drawing.Point(79, 332);
            this.nudRate.Name = "nudRate";
            this.nudRate.Size = new System.Drawing.Size(86, 25);
            this.nudRate.TabIndex = 7;
            this.nudRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRate.Visible = false;
            // 
            // lbRate
            // 
            this.lbRate.AutoSize = true;
            this.lbRate.Location = new System.Drawing.Point(3, 339);
            this.lbRate.Name = "lbRate";
            this.lbRate.Size = new System.Drawing.Size(82, 15);
            this.lbRate.TabIndex = 6;
            this.lbRate.Text = "力度系数：";
            this.lbRate.Visible = false;
            // 
            // cbClick2Jump
            // 
            this.cbClick2Jump.AutoSize = true;
            this.cbClick2Jump.Checked = true;
            this.cbClick2Jump.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClick2Jump.Location = new System.Drawing.Point(7, 307);
            this.cbClick2Jump.Name = "cbClick2Jump";
            this.cbClick2Jump.Size = new System.Drawing.Size(149, 19);
            this.cbClick2Jump.TabIndex = 5;
            this.cbClick2Jump.Text = "有落脚点则自动跳";
            this.cbClick2Jump.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 151);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(154, 144);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            // 
            // cbZoom
            // 
            this.cbZoom.AutoSize = true;
            this.cbZoom.Checked = true;
            this.cbZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbZoom.Location = new System.Drawing.Point(9, 126);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(104, 19);
            this.cbZoom.TabIndex = 3;
            this.cbZoom.Text = "图像自适应";
            this.cbZoom.UseVisualStyleBackColor = true;
            this.cbZoom.Visible = false;
            this.cbZoom.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbDistance
            // 
            this.lbDistance.AutoSize = true;
            this.lbDistance.Location = new System.Drawing.Point(6, 85);
            this.lbDistance.Name = "lbDistance";
            this.lbDistance.Size = new System.Drawing.Size(52, 15);
            this.lbDistance.TabIndex = 2;
            this.lbDistance.Text = "距离：";
            // 
            // lbXY2
            // 
            this.lbXY2.AutoSize = true;
            this.lbXY2.Location = new System.Drawing.Point(6, 47);
            this.lbXY2.Name = "lbXY2";
            this.lbXY2.Size = new System.Drawing.Size(52, 15);
            this.lbXY2.TabIndex = 1;
            this.lbXY2.Text = "落脚：";
            // 
            // lbXY1
            // 
            this.lbXY1.AutoSize = true;
            this.lbXY1.Location = new System.Drawing.Point(6, 12);
            this.lbXY1.Name = "lbXY1";
            this.lbXY1.Size = new System.Drawing.Size(52, 15);
            this.lbXY1.TabIndex = 0;
            this.lbXY1.Text = "起点：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "跳一跳助手";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbXY2;
        private System.Windows.Forms.Label lbXY1;
        private System.Windows.Forms.Label lbDistance;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbZoom;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cbClick2Jump;
        private System.Windows.Forms.NumericUpDown nudRate;
        private System.Windows.Forms.Label lbRate;
        private System.Windows.Forms.CheckBox cbMRate;
        private System.Windows.Forms.CheckBox cbAutoFindMPoint;
    }
}


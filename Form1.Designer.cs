namespace mfs
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer_fft = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TCPAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupLink = new System.Windows.Forms.GroupBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.TCPPort = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.subgroupBox2 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.subgroupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer_pbt = new System.Windows.Forms.Timer(this.components);
            this.timer_cal = new System.Windows.Forms.Timer(this.components);
            this.timer_sec = new System.Windows.Forms.Timer(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupLink.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.subgroupBox2.SuspendLayout();
            this.subgroupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_fft
            // 
            this.timer_fft.Enabled = true;
            this.timer_fft.Interval = 25;
            this.timer_fft.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Tag = "0";
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "40MHz (分辨率25KHz)",
            "20MHz (分辨率12.5KHz)",
            "10MHz (分辨率6.25KHz)",
            "5MHz  (分辨率3.125KHz)",
            "2MHz  (分辨率1.25KHz)",
            "1MHz  (分辨率625Hz)",
            "500KHz(分辨率312.5Hz)",
            "300KHz(分辨率187.5Hz)",
            "200KHz(分辨率125Hz)",
            "100KHz(分辨率62.5Hz)",
            "50KHz (分辨率31.25Hz)"});
            this.comboBox1.Location = new System.Drawing.Point(83, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(204, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "40MHz(分辨率25KHz)";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TCPAddr
            // 
            this.TCPAddr.Location = new System.Drawing.Point(87, 21);
            this.TCPAddr.Name = "TCPAddr";
            this.TCPAddr.Size = new System.Drawing.Size(100, 21);
            this.TCPAddr.TabIndex = 3;
            this.TCPAddr.Text = "192.168.102.11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "终端IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "中心频率";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "开始频率";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(83, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "107.6";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(87, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "20";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "频谱扫宽";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1660, 400);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Enabled = false;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(309, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 133);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单频点测量(MHz)";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "FM"});
            this.comboBox5.Location = new System.Drawing.Point(83, 93);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(100, 20);
            this.comboBox5.TabIndex = 21;
            this.comboBox5.Text = "FM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "解调方式";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(614, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 133);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "频段扫描(MHz)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 21;
            this.label17.Text = "分辨率";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "40MHz",
            "20MHz",
            "10MHz"});
            this.comboBox2.Location = new System.Drawing.Point(87, 93);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 20);
            this.comboBox2.TabIndex = 19;
            this.comboBox2.Text = "40MHz";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "拼接带宽";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Tag = "0";
            this.button3.Text = "设置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(87, 55);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 15;
            this.textBox5.Text = "6000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "截止频率";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Tag = "0";
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // groupLink
            // 
            this.groupLink.Controls.Add(this.comboBox6);
            this.groupLink.Controls.Add(this.label27);
            this.groupLink.Controls.Add(this.TCPPort);
            this.groupLink.Controls.Add(this.label10);
            this.groupLink.Controls.Add(this.button1);
            this.groupLink.Controls.Add(this.TCPAddr);
            this.groupLink.Controls.Add(this.label1);
            this.groupLink.Location = new System.Drawing.Point(12, 12);
            this.groupLink.Name = "groupLink";
            this.groupLink.Size = new System.Drawing.Size(291, 133);
            this.groupLink.TabIndex = 20;
            this.groupLink.TabStop = false;
            this.groupLink.Text = "连接接收机";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "宽带接收机",
            "AD9364"});
            this.comboBox6.Location = new System.Drawing.Point(87, 93);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(100, 20);
            this.comboBox6.TabIndex = 21;
            this.comboBox6.Text = "宽带接收机";
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 96);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 20;
            this.label27.Text = "信号源选择";
            // 
            // TCPPort
            // 
            this.TCPPort.Location = new System.Drawing.Point(87, 55);
            this.TCPPort.Name = "TCPPort";
            this.TCPPort.Size = new System.Drawing.Size(100, 21);
            this.TCPPort.TabIndex = 17;
            this.TCPPort.Text = "5555";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "终端端口";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox13);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.textBox14);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.comboBox3);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(12, 150);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(572, 56);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "宽带接收机设置";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(255, 24);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(42, 21);
            this.textBox13.TabIndex = 26;
            this.textBox13.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(481, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 25;
            this.button4.Tag = "0";
            this.button4.Text = "设置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(417, 25);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(42, 21);
            this.textBox14.TabIndex = 24;
            this.textBox14.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(314, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "中频衰减(0~63dB)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "射频衰减(0~31dB)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "模式";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "常规模式",
            "低噪声模式",
            "低失真模式"});
            this.comboBox3.Location = new System.Drawing.Point(50, 25);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(80, 20);
            this.comboBox3.TabIndex = 20;
            this.comboBox3.Text = "常规模式";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(123, 135);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 27;
            this.label22.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(90, 135);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 12);
            this.label21.TabIndex = 26;
            this.label21.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.subgroupBox2);
            this.groupBox3.Controls.Add(this.subgroupBox1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(967, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 194);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收机调校";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.button12);
            this.groupBox6.Controls.Add(this.textBox12);
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Location = new System.Drawing.Point(260, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(235, 168);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "频谱多点修正";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(72, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 43;
            this.label25.Text = "0分0秒";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 60);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 42;
            this.label24.Text = "校准计时：";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(10, 89);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 41;
            this.checkBox2.Text = "写寄存器";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 39;
            this.label20.Text = "信号源地址";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(147, 90);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 30;
            this.button12.TabStop = false;
            this.button12.Tag = "0";
            this.button12.Text = "开始";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(93, 20);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(88, 21);
            this.textBox12.TabIndex = 40;
            this.textBox12.Text = "19";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(147, 129);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 21;
            this.button11.Tag = "0";
            this.button11.Text = "保存";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button_Click);
            // 
            // subgroupBox2
            // 
            this.subgroupBox2.Controls.Add(this.label23);
            this.subgroupBox2.Controls.Add(this.label22);
            this.subgroupBox2.Controls.Add(this.textBox8);
            this.subgroupBox2.Controls.Add(this.label21);
            this.subgroupBox2.Controls.Add(this.textBox9);
            this.subgroupBox2.Controls.Add(this.label16);
            this.subgroupBox2.Controls.Add(this.label14);
            this.subgroupBox2.Controls.Add(this.textBox7);
            this.subgroupBox2.Controls.Add(this.label15);
            this.subgroupBox2.Location = new System.Drawing.Point(501, 20);
            this.subgroupBox2.Name = "subgroupBox2";
            this.subgroupBox2.Size = new System.Drawing.Size(197, 168);
            this.subgroupBox2.TabIndex = 39;
            this.subgroupBox2.TabStop = false;
            this.subgroupBox2.Text = "频谱最大值";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 135);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 12);
            this.label23.TabIndex = 42;
            this.label23.Text = "当前校准点：";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(91, 56);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(75, 21);
            this.textBox8.TabIndex = 34;
            this.textBox8.Text = "0";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(91, 92);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(75, 21);
            this.textBox9.TabIndex = 36;
            this.textBox9.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 35;
            this.label16.Text = "修正值(dbuv)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "信号(dbuv)";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(91, 20);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(75, 21);
            this.textBox7.TabIndex = 32;
            this.textBox7.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "频率(Mhz)";
            // 
            // subgroupBox1
            // 
            this.subgroupBox1.Controls.Add(this.button7);
            this.subgroupBox1.Controls.Add(this.textBox11);
            this.subgroupBox1.Controls.Add(this.textBox6);
            this.subgroupBox1.Controls.Add(this.label19);
            this.subgroupBox1.Controls.Add(this.label12);
            this.subgroupBox1.Controls.Add(this.label13);
            this.subgroupBox1.Controls.Add(this.textBox1);
            this.subgroupBox1.Controls.Add(this.textBox10);
            this.subgroupBox1.Controls.Add(this.label18);
            this.subgroupBox1.Controls.Add(this.button8);
            this.subgroupBox1.Location = new System.Drawing.Point(17, 20);
            this.subgroupBox1.Name = "subgroupBox1";
            this.subgroupBox1.Size = new System.Drawing.Size(237, 168);
            this.subgroupBox1.TabIndex = 38;
            this.subgroupBox1.TabStop = false;
            this.subgroupBox1.Text = "修正参数";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(148, 129);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 28;
            this.button7.Tag = "0";
            this.button7.Text = "修正";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(97, 94);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(45, 21);
            this.textBox11.TabIndex = 32;
            this.textBox11.Text = "150";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(97, 131);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(45, 21);
            this.textBox6.TabIndex = 30;
            this.textBox6.Text = "40";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 31;
            this.label19.Text = "高切断(dbuv)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "低噪值(dbuv)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "校准源(dbuv)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 21);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "-30";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(97, 55);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(45, 21);
            this.textBox10.TabIndex = 30;
            this.textBox10.Text = "-30";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 29;
            this.label18.Text = "低切断(dbuv)";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(148, 92);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 20;
            this.button8.Tag = "0";
            this.button8.Text = "初始化";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label26.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label26.Location = new System.Drawing.Point(1521, 247);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 12);
            this.label26.TabIndex = 20;
            this.label26.Text = "扫描速度:0FPs";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(590, 150);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(247, 56);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "游标设置";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "最大保持";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(84, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 26;
            this.button5.Tag = "0";
            this.button5.Text = "上一个频点";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(165, 22);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 27;
            this.button6.Tag = "0";
            this.button6.Text = "下一个频点";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Location = new System.Drawing.Point(12, 619);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1660, 180);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // timer_pbt
            // 
            this.timer_pbt.Interval = 25;
            this.timer_pbt.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer_cal
            // 
            this.timer_cal.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer_sec
            // 
            this.timer_sec.Enabled = true;
            this.timer_sec.Interval = 1000;
            this.timer_sec.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox3);
            this.groupBox7.Location = new System.Drawing.Point(844, 150);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(117, 56);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "底噪";
            this.groupBox7.Enabled = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(19, 25);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "华日算法";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 811);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupLink);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dxd mfs_v1.0520";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupLink.ResumeLayout(false);
            this.groupLink.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.subgroupBox2.ResumeLayout(false);
            this.subgroupBox2.PerformLayout();
            this.subgroupBox1.ResumeLayout(false);
            this.subgroupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_fft;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox TCPAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupLink;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox TCPPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox subgroupBox2;
        private System.Windows.Forms.GroupBox subgroupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Timer timer_pbt;
        private System.Windows.Forms.Timer timer_cal;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer timer_sec;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}


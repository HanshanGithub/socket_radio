using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Management;
using System.Threading;

using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

//作者：yanlei_0@163.com
//编译环境vs2013
//编译日期20201112

//naudio安装,最好早上安装下载才顺利
//在菜单栏里找到：工具=>库程序包管理器=>程序包管理器控制台 "或者" 视图=>其他窗口=>程序包管理器控制台
//提示PM> 
//然后输入:Install-Package NAudio -Version 1.7.0-alpha03
using NAudio;
using NAudio.Wave;

//***************************************************************************************************
namespace mfs
{

    public partial class Form1 : Form
    {
        //------------------------------------------------------------------------------------全局变量
        private Socket udpServes = null;//dup句柄
        private Thread thrUDPRecv;

        private Socket tcpClient = null;//TCP句柄

        //频谱图坐标偏移// 2022-11-22 11:16 
        static int window_left_offset = 40; 
        static int window_top_offset = 60;

        //频谱实时值缓存
        //6000000000/1000000=600个缓存
        static public Int16[] fft_wave = new Int16[1601*600];
        static public Int16[] fft_temp = new Int16[1601];
        //频谱最大值缓存
        static public int[] max_wave = new int[1601];

        //瀑布图缓存
        Bitmap pbg_bmp;
        static public Int16[] pbg_wave = new Int16[1601];
        static public Int16 pbg_line = 0;
        //校准消耗计数
        static public Int16 adj_time = 0;

        //PCM播放器
        public struct pcm_stream
        {
            public WaveOut waveOut;
            public BufferedWaveProvider bufferedWaveProvider;//5s缓存区
        }
        pcm_stream pcm = new pcm_stream();

        //------------------------------------------------------------------------------------全局变量
        public struct app_define// 2022-11-22 15:26:10 guess:曲线信息
        {
            //记录绘图区域鼠标位置
            public int px;               //绘图区域点击的x坐标
            public int py;               //绘图区域点击的y坐标
            //
            public UInt64 center_freq;   //单频点分析中心频率
            public UInt64 ipan;          //单频点、频段扫描分析带宽
            public UInt64 start_freq;    //频段扫描开始频率
            public UInt64 stop_freq;     //频段扫描结束频率
            public UInt64 span;          //频段扫描每次上传的带宽数据
            //最大保持游标显示
            public double max_freq;      //最大保持频率
            public double max_dbuv;      //最大保持幅度
            public UInt64 max_index;     //最大保持在频谱的位置
            public double cursor_freq;   //鼠标选中点频率
            public double cursor_dbuv;   //鼠标点中点幅度
            //校准
            public UInt64 cal_index;     //校准频谱点的位置
            public double cal_freq;      //校准频谱点的频率
            public double cal_step;      //校准频谱点的递增
            //fft数据包统计&忙标记
            public int pack_count;       //用于计数频谱包个数
            public bool update;          //显示更新
        }
        app_define show = new app_define();// 2022-11-22 15:23:47

        //------------------------------------------------------------------------------------EM100接收机协议
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi, Pack=1)]  
        public struct common_header      //协议公共部分
        {
            public UInt32 header_magic_number;
            public UInt16 header_minor_version_numbe;
            public UInt16 header_major_version_number;
            public UInt16 header_sequence_number;
            public UInt16 header_reserved;
            public UInt32 data_size;
            public UInt16 attribute_tag;
            public UInt16 attribute_length;
            public Int16  trace_number_of_items;
            public byte   trace_reserved;
            public byte   trace_optional_header_length;
            public UInt32 trace_selector_flags;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct audio_option       //音频选项
        { 
            public Int16  audio_mode;
            public Int16  frame_len;
            public UInt32 frequency_low;
            public UInt32 bandwidth;
            public UInt16 demodulation_id;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] demodulation_mode;
            public UInt32 frequency_high;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] reserved;
            public UInt64 timestamp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ifpan_option       //单频点选项
        { 
            public UInt32 frequency_low;
            public UInt32 span_frequency;
            public Int16  reserved;
            public Int16  average_type;
            public UInt32 measure_time;
            public UInt32 frequency_high;
            public UInt32 selected_channel;
            public UInt32 demodulation_freq_low;
            public UInt32 demodulation_freq_high;
            public UInt64 timestamp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct pscan_option       //频段选项
        {
            public UInt32 StartFreq_low;
            public UInt32 StopFreq_low;
            public UInt32 StepFreq;
            public UInt32 StartFreq_high;
            public UInt32 StopFreq_high;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] reserved;
            public UInt64 timestamp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct audio_stream       //音频数据流
        {
            public common_header header;
            public audio_option  option;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12800)] 
            public byte[]       data;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ifpan_stream       //单频点数据流
        {
            public common_header header;
            public ifpan_option  option;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1601)]
            public Int16[]       data;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct pscan_stream       //频段扫描数据流
        {
            public common_header header;
            public pscan_option option;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1601)]
            public Int16[] data;
        }

        //------------------------------------------------------------------------------------
        //结构体与byte数组互相转换
        public static byte[] StructToBytes(object structure)
        {
            Int32 size = Marshal.SizeOf(structure);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structure, buffer, false);
                Byte[] bytes = new Byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        public static object BytesToStruct(byte[] bytes, Type strcutType)
        {
            Int32 size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return Marshal.PtrToStructure(buffer, strcutType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        //------------------------------------------------------------------------------------
        #region GPIB操作
        int gpib_dev = 0;
        public bool e4421b_write(string strWrite)
        {
            try
            {
                if (gpib_dev == 0)
                {
                    int addr = int.Parse(textBox12.Text);
                    //Open and intialize an GPIB instrument
                    gpib_dev = GPIB.ibdev(0, addr, 0, (Int32)GPIB.gpib_timeout.T1s, 1, 0);
                    //clear the specific GPIB instrument
                    GPIB.ibclr(gpib_dev);
                }
                //Write a string command to a GPIB instrument using the ibwrt() command
                GPIB.ibwrt(gpib_dev, strWrite, strWrite.Length);
                //Offline the GPIB interface card
                //GPIB.ibonl(dev, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        //------------------------------------------------------------------------------------加载入口
        public Form1()
        {
            InitializeComponent();

            //初始化默认值
            show.px = window_left_offset + 800;
            show.py = window_top_offset + 160;

            show.center_freq = 107600000;
            show.ipan = 40000000;
            show.start_freq = 20000000;// 2022-11-22 15:31:12 20Mhz
            show.stop_freq = 420000000;// 420Mhz
            show.span = 40000000;// 40Mhz

            //初始化播放器
            try
            {
                pcm.waveOut = new WaveOut();
                WaveFormat wf = new WaveFormat(32000, 2);
                pcm.bufferedWaveProvider = new BufferedWaveProvider(wf);
                pcm.waveOut.Init(pcm.bufferedWaveProvider);
                pcm.waveOut.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //禁用线程检查
            //Control.CheckForIllegalCrossThreadCalls = false;

            button1.BackColor = Color.Green;

            //用于绘制瀑布图
            pbg_bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);// 2022-11-22 15:32:10 

            timer_pbt.Interval = timer_fft.Interval;
        }

        //------------------------------------------------------------------------------------窗体关闭事件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpClient_Send("ABORT;\r\n*CLS;\r\n");
            //延时1秒
            Thread.Sleep(1);
            //关闭定时器
            timer_fft.Enabled = false;
            timer_pbt.Enabled = false;
            timer_cal.Enabled = false;
            timer_sec.Enabled = false;
            //断开连接
            delect_socket();
        }

        //------------------------------------------------------------------------------------tcp发送
        string tcpClient_Send(String cmd)
        {
            try
            {
                int index = 0;
                int size = 0;
                byte[] adujst = new Byte[1024*1024];

                //需要循环读取校准数据
                if (cmd == "save adjust\r")
                {
                    while (true)
                    {
                        byte[] Bytes = Encoding.ASCII.GetBytes("read adujst" + index + "\r");
                        index += 1;
                        tcpClient.Send(Bytes);
                        byte[] Rec = new byte[2048];
                        int len = tcpClient.Receive(Rec);
                        string p = Encoding.ASCII.GetString(Rec);
                        if (len == 2 )
                        {
                            SaveFileDialog file = new SaveFileDialog();//定义新的文件保存位置控件
                            file.Filter = "校准数据(*.cal)|*.cal";//设置文件后缀的过滤
                            if (file.ShowDialog() == DialogResult.OK)//如果有文件保存路径
                            {
                                //StreamWriter sw = File.CreateText(file.FileName);

                                FileStream fs = new FileStream(file.FileName, FileMode.Create);//以追加的形式打开文件
                                fs.Write(adujst, 0, size);//写入byte[]型数据
                                fs.Flush();
                                fs.Close();
                            }
                            file.Dispose();
                            return "ok";
                        }
                        //读取的校准参数先放到缓存
                        for (int i = 0; i < len; i++)
                        {
                            adujst[size + i] = Rec[i];
                        }
                        //读取的校准参数数据总大小
                        size += len;
                    }
                }
                //常规命令，不需要特殊处理；只需要发送一次
                else
                {

                    byte[] Bytes = Encoding.ASCII.GetBytes(cmd);
                    tcpClient.Send(Bytes);
                    byte[] Rec = new byte[2048];
                    int len = tcpClient.Receive(Rec);
                    return Encoding.ASCII.GetString(Rec);
                }
            }
            catch
            {
                return "";
            }
        }
        //------------------------------------------------------------------------------------创建socket
        private bool creat_socket(Int32 TCPPort, string ClientIP, Int32 RecPort)
        {
            try
            {
                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                tcpClient.Connect(new IPEndPoint(IPAddress.Parse(ClientIP), TCPPort));

                IPAddress lep = IPAddress.Parse(((IPEndPoint)tcpClient.LocalEndPoint).Address.ToString());
                string lep_addr = lep.ToString();

                udpServes = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                udpServes.Bind(new IPEndPoint(IPAddress.Parse(lep_addr), RecPort));
                thrUDPRecv = new Thread(UDPReceiveMessage);
                thrUDPRecv.Start();

                //通知终端建立udp并发送数据
                tcpClient_Send("TRAC:UDP:TAG:ON \"" + lep_addr + "\"," + RecPort.ToString() + ",FSCAN,MSCAN,IFPAN,PSCAN,CW,AUDIO\r");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //------------------------------------------------------------------------------------删除socket
        private void delect_socket()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient.Dispose();
            }
            if (udpServes != null)
            {
                udpServes.Close();
                //udpClient.Dispose();
            }
            if (thrUDPRecv != null)
            {
                thrUDPRecv.Abort();
            }
        }
        //------------------------------------------------------------------------------------UDP接收线程
        private void UDPReceiveMessage(object obj)
        {
            while (true)
            {
                audio_stream audio = new audio_stream();
                ifpan_stream ifpan = new ifpan_stream();
                pscan_stream pscan = new pscan_stream();
                byte[] data = new byte[16384];
                int length = 0;

                //阻塞接收udp数据包
                try
                {
                    length = udpServes.Receive(data);
                }
                catch
                {
                    continue;
                }
                
                //音频数据包解析
                if (length == Marshal.SizeOf(audio))
                {
                    //单频点测量才播放声音
                    if (show.ipan <= 40000000)
                    {
                        try
                        {
                            audio = (audio_stream)BytesToStruct(data, typeof(audio_stream));
                            pcm.bufferedWaveProvider.AddSamples(audio.data, 0, 12800);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                //单频点数据包解析 // 2022-11-22 11:37 
                if (length == Marshal.SizeOf(ifpan))
                {
                    //统计接收到的数据包
                    show.pack_count++;
                    //将收到的byte数据转换成结构体
                    ifpan = (ifpan_stream)BytesToStruct(data, typeof(ifpan_stream));
                    //得到中心频率
                    UInt64 frequency = ((UInt64)ifpan.option.frequency_high << 32) + ifpan.option.frequency_low;
                    //单频点数据复制到显示缓存 // 2022-11-22 12:05:57
                    if (show.ipan <= 40000000)// 2022-11-22 15:17:17 40Mhz (M:megahertz)
                    {
                        show.center_freq = frequency;

                        //检查数据包是否有错乱数据(120.0dbuv~-70.0dbuv)
                        short max = ifpan.data.Max();
                        short min = ifpan.data.Min();
                        if (max > 1000 || min < -500)
                        {
                            continue;
                        }
                        //避免漏频-频谱叠加处理
                        if (show.update)
                        {
                            show.update = false;
                            fft_temp.CopyTo(fft_wave, 0);
                            ifpan.data.CopyTo(fft_temp, 0);
                        }
                        else for (int i = 0; i < 1601; i++)
                        {
                            fft_temp[i] = (ifpan.data[i] > fft_temp[i]) ? ifpan.data[i] : fft_temp[i];
                        }

                        continue;
                    }
                }

                //频段扫描数据包解析 // 2022-11-22 11:40:26
                if (length == Marshal.SizeOf(pscan))
                {
                    //统计接收到的数据包
                    show.pack_count++;
                    //频段扫描中心频率
                    show.center_freq = show.start_freq + show.ipan / 2;
                    //将收到的byte数据转换成结构体
                    pscan = (pscan_stream)BytesToStruct(data, typeof(pscan_stream));
                    //得到开始频率
                    UInt64 start_freq = ((UInt64)pscan.option.StartFreq_high << 32) + pscan.option.StartFreq_low;
                    //得到结束频率
                    UInt64 stop_freq = ((UInt64)pscan.option.StopFreq_high << 32) + pscan.option.StopFreq_low;
                    //频率不在测量范围内
                    if (show.start_freq > start_freq || show.stop_freq < stop_freq)
                    {
                        continue;
                    }
                    //计算数据包偏移
                    int offset = (int)((start_freq - show.start_freq) / show.span);

                    //检查数据包是否有错乱数据(120.0dbuv~-70.0dbuv)
                    short max = pscan.data.Max();
                    short min = pscan.data.Min();
                    if (max > 1000 || min < -500)
                    {
                        continue;
                    }
                    //拷贝数据包
                    pscan.data.CopyTo(fft_wave, offset * 1601);
                }
            }
        }

        //------------------------------------------------------------------------------------单频点带宽返回值Hz
        private UInt32 ipan_freq(int index)
        {
            UInt32 freq;

            groupBox3.Enabled = false;
            switch (index)
            {
                case 1: freq = 20000000; break;
                case 2: freq = 10000000; break;
                case 3: freq = 5000000; break;
                case 4: freq = 2000000; groupBox3.Enabled = true; break;
                case 5: freq = 1000000; break;
                case 6: freq = 500000; break;
                case 7: freq = 300000; groupBox3.Enabled = true; break;
                case 8: freq = 200000; break;
                case 9: freq = 100000; break;
                case 10: freq = 50000; break;
                //case 11: freq = 30000; groupBox3.Enabled = true; break;
                //case 12: freq = 15000; break;
                //case 13: freq = 5000; break;
                default: freq = 40000000; groupBox3.Enabled = true; break;
            }
            return freq;
        }
        //------------------------------------------------------------------------------------绘制边框
        //返回当前中心频率
        private double draw_box(Graphics g, int width, int height, int x1, int y1)// 2022-11-22 15:41:47 
        {
            //背景颜色
            g.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width, pictureBox1.Height);

            //上下两条横线
            g.DrawLine(new Pen(Brushes.White, 1), x1, y1, x1 + width, y1);
            g.DrawLine(new Pen(Brushes.White, 1), x1, y1 + height, x1 + width, y1 + height);

            //左右两条竖线
            g.DrawLine(new Pen(Brushes.White, 1), x1, y1, x1, y1 + height);
            g.DrawLine(new Pen(Brushes.White, 1), x1 + width, y1, x1 + width, y1 + height);

            Pen fix_line = new Pen(Brushes.White, 1);
            Pen flg_line = new Pen(Brushes.Orange, 1);
            fix_line.DashPattern = new float[] { 2, 4 };
            flg_line.DashPattern = new float[] { 2, 4 };

            //横向虚线
            int wy = height / 10;
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine((i == 8) ? flg_line : fix_line, x1, y1 + i * wy, x1 + width, y1 + i * wy);
            }

            //竖向虚线
            int wx = width / 20;
            for (int i = 0; i < 20; i++)
            {
                g.DrawLine((i == 10) ? flg_line : fix_line, x1 + i * wx, y1, x1 + i * wx, y1 + height);
            }

            //竖向数标【120~-30dbuv】
            for (int i = 0; i < 11; i++)
            {
                int x_val = 120 - (i * wy) / 2;
                g.DrawString(x_val.ToString(), new Font("宋体", 12), new SolidBrush(Color.White), 5, y1 + i * wy - 10);
            }

            //横向数标【频率】
            double l_center_freq = (double)show.center_freq / 1000000.0 - show.ipan / 2000000.0;
            double m_center_freq = (double)show.center_freq / 1000000.0;
            double h_center_freq = (double)show.center_freq / 1000000.0 + show.ipan / 2000000.0;
            g.DrawString(l_center_freq.ToString(), new Font("宋体", 12), new SolidBrush(Color.White), x1, y1 + height + 5);
            g.DrawString(m_center_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), x1 + width / 2 - 20, y1 + height + 5);
            g.DrawString(h_center_freq.ToString(), new Font("宋体", 12), new SolidBrush(Color.White), x1 + width - 50, y1 + height + 5);

            return l_center_freq;
        }
        //------------------------------------------------------------------------------------绘制频谱 //2022-11-21 21:03
        private void timer1_Tick(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height); // 2022-11-21 21:07 bmp为图像，在上面绘制好了显示在picture1上面 
            Graphics g = Graphics.FromImage(bmp);

            int val3_py = 0;
            int val3_px = window_left_offset; // window_left[top]_offset:频谱坐标偏移 line48
            int val3_buf = 0;

            int max_py = 5000;
            int max_px = window_left_offset;

            double l_center_freq = draw_box(g, 1600, 300, window_left_offset, window_top_offset); //// 2022-11-22 11:19 中心频率数值 freq
            
            //将缓存数据压缩并绘制在画图板上       // 2022-11-21 21:12 猜测是绘制数据，数据来自哪里呢
            for (int i = 0; i < 1601; i++)
            {
                int divx = (int)(show.ipan / show.span);
                divx = (divx > 0) ? divx : 1;
                int val1 = -400;
                int val2 = -400;
                int val3 = 0;
                //如果显示带宽大于show.span那么压缩数据
                //针对频段扫描
                for (int j = 0; j < divx; j++)
                {
                    val1 = fft_wave[i * divx + j];
                    val2 = (val1 > val2) ? val1 : val2;
                    val3 = (Int16)(300 - (val2 / 5));
                }

                if (i > 0)
                {
                    //绘制实时频谱线条  // 2022-11-21 21:15 y=0的绿色直线(没有连接时),连接后为跳动的曲线
                    // 2022-11-21 21:19 选择华日算法模拟一下__
                    if (checkBox3.Checked) // 2022-11-21 21:23 明天解决绘制数据信息问题
                        g.DrawLine(new Pen(Brushes.MediumOrchid, 1), window_left_offset + i, val3_buf, window_left_offset + i + 1, val3);// 2022-11-22 11:01 寻找数据信息
                    //绘制最大值频谱线  // 2022-11-21 21:17 y=-30的红色直线
                    g.DrawLine(new Pen(Brushes.Red, 1), window_left_offset + i, max_wave[i - 1], window_left_offset + i + 1, max_wave[i]);
                }

                //保存最大值
                if (checkBox1.Checked == false){
                    max_wave[i] = 360;
                }
                else if (val3 < max_wave[i]){
                    max_wave[i] = val3;
                }

                //保存当前点数据以便下一个点画线
                val3_buf = val3;

                //写数据到瀑布图缓存
                pbg_wave[i] = (Int16)val2;

                //找出频谱实时值中的最大值及点位
                if (max_py > val3)
                {
                    max_px = window_left_offset + i;
                    max_py = val3;
                    show.max_dbuv = (float)val2 / 10;
                    show.max_index = (UInt64)i;
                }

                //将鼠标点击对应的值记录下来
                if (window_left_offset + i == show.px)
                {
                    val3_py = val3;
                    val3_px = show.px;
                    show.cursor_dbuv = (float)val2 / 10;
                }
            }
            //频谱最大值
            //show.max_freq = l_center_freq + (((double)show.ipan / 1000000.0) / 1600) * (max_px - window_left_offset);// 2022-11-22 11:05 未有明显变化

            //显示频谱中的最大点
            if (checkBox1.Checked)
            {
                //标注频谱中的最大值
                g.DrawString("▼", new Font("宋体", 12), new SolidBrush(Color.White), max_px - 9, max_py - 16);// 2022-11-22 11:04 未有明显变化
                //显示文字
                //g.DrawString("dbuv：" + show.max_dbuv.ToString() + "dbuv", new Font("宋体", 12), new SolidBrush(Color.White), 1150, 10);
                //show.max_freq = l_center_freq + (((double)show.ipan / 1000000.0) / 1600) * (max_px - window_left_offset);
                //g.DrawString("freq：" + show.max_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), 1150, 30);
            }

            //显示鼠标点的横坐符号
            g.DrawString("▼", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), val3_px - 9, val3_py - 16);
            //显示鼠标点对应的文字
            g.DrawString("dbuv：" + show.cursor_dbuv.ToString() + "dbuv", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), 1300, 10);
            show.cursor_freq = l_center_freq + (((double)show.ipan / 1000000.0) / 1600) * (show.px - window_left_offset);// 2022-11-22 11:02 频率字体显示
            g.DrawString("freq：" + show.cursor_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), 1300, 30);


            //显示绘制的bmp图片 
            // 2022-11-21 21:07 先画一个bmp图，然后把bmp图放在pictrue1上面显示
            pictureBox1.CreateGraphics().DrawImage(bmp, 0, 0);  // 2022-11-21 21:09 注释后 picutre1,2 全黑
            //pictureBox1.Dispose();
            //释放避免内存溢出
            g.Dispose();
            bmp.Dispose();

            //在界面上显示校准参数
            textBox7.Text = show.max_dbuv.ToString();
            textBox8.Text = show.max_freq.ToString();
            textBox9.Text = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox7.Text)).ToString("f1");

            show.update = true;
        }

        //------------------------------------------------------------------------------------用颜色代表信号强度
        //http://tools.jb51.net/static/colorpicker/
        private Color val_to_color(double val)
        {
            if (val < -30) val = -30;
            if (val > 90) val = 90;

            //768种颜色
            double step = 768 / 120;
            double rgb = step * (val + 30);

            //返回颜色值
            if (rgb < 256) return Color.FromArgb(0, (Byte)(255-rgb), 255);
            if (rgb < 512) return Color.FromArgb((Byte)(rgb-256), 0, 255);
            if (rgb < 768) return Color.FromArgb(255, 0, (Byte)(768 - rgb));

            //默认颜色
            return Color.FromArgb(0, 0, 255);
        }

        //------------------------------------------------------------------------------------瀑布图
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer_fft.Enabled)
            {
                Graphics g = Graphics.FromImage(pbg_bmp); // 2022-11-22 15:39:14 瀑布图

                //采用了全局pbg_bmp
                /////////////////////////////////////////////////////////////
                pbg_line += 1;
                //瀑布图高度180
                if (pbg_line > 179)
                {
                    pbg_line = 179;
                    //复制图片的下半部分并覆盖上半部分实现频谱流动效果
                    Rectangle srcRect = new Rectangle(0, 1, pbg_bmp.Width, pbg_bmp.Height);
                    Rectangle destRect = new Rectangle(0, 0, pbg_bmp.Width, pbg_bmp.Height);
                    g.DrawImage(pbg_bmp, destRect, srcRect, GraphicsUnit.Pixel);// 2022-11-22 15:49:47 
                }
                for (int i = 0; i < 1601; i++)
                {
                    //始终只绘制一行
                    Color color = val_to_color(pbg_wave[i] / 10);
                    Brush brush = new SolidBrush(color);
                    //public void DrawLine (System.Drawing.Pen pen, int x1, int y1, int x2, int y2);
                    //g.DrawLine(new Pen(brush, 1), window_left_offset + i, pbg_line, window_left_offset + i + 1, pbg_line);// 2022-11-22 15:40:16 一行
                    g.DrawLine(new Pen(brush, 1), window_left_offset + i, pbg_line, window_left_offset +i + 1, pbg_line);// 2022-11-22 15:41:00 
                }

                //显示绘制的bmp图片
                pictureBox2.CreateGraphics().DrawImage(pbg_bmp, 0, 0); // 似乎连接到picture2，注释掉后picture2无内容 
                //pictureBox1.Dispose();
                //释放避免内存溢出
                g.Dispose();
                //bmp.Dispose(;)
            }
        }

        //------------------------------------------------------------------------------------自动校准
        double cal_val_buff = 0;
         private void timer3_Tick(object sender, EventArgs e)
        {
            UInt32 val = ((UInt32)show.cal_index << 16) + (UInt16)(Convert.ToDouble(textBox9.Text) * 10);

            label21.Text = show.cal_index.ToString();
            label22.Text = show.max_index.ToString();

            double freq = Convert.ToDouble(textBox8.Text) * 1000000.0;

            //频率不是待校准频率跳出处理流程
            if (freq != show.cal_freq)
            {
                return;
            }

            if (checkBox2.Checked)
            {
                //两次值相同才校准
                if (cal_val_buff != val)
                {
                    cal_val_buff = val;
                    return;
                }
                //写校准值
                tcpClient_Send("writ adjust" + val.ToString() + "\r");
            }

            //校准完成
            if (show.cal_index >= 1600)
            {
                timer_cal.Enabled = false;
                button12.BackColor = SystemColors.Control;
                MessageBox.Show("校准完成！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //设置下一个频点
            show.cal_freq = show.cal_freq + show.cal_step;
            show.cal_index++;
            timer_cal.Enabled = e4421b_write("FREQuency " + show.cal_freq.ToString("f1") + " Hz\n");

            cal_val_buff = 0;
        }

        //------------------------------------------------------------------------------------自动校准用时
         private void timer4_Tick(object sender, EventArgs e)
         {
             //显示fft数据包率 2022-11-22 11:27 FPS速度:平均500
             if (show.ipan <= 40000000) {
                 label26.Text = "扫描速度:" + show.pack_count.ToString() + "FPs"; 
             }
             else {
                 label26.Text = "扫描速度:" + ((float)((ulong)show.pack_count * show.span) / show.ipan).ToString("0.0") + "FPs";
             }
             
             //label26.Text = "扫描速度:" + show.pack_count.ToString() + "FPs";
             show.pack_count = 0;

             //显示校准用时
             if (timer_cal.Enabled)
             {
                 adj_time++;
                 label25.Text = (adj_time / 60).ToString() + "分" + (adj_time % 60).ToString() + "秒";
             }
         }

         //------------------------------------------------------------------------------------单频点带宽选择
         private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
         {
             button_Click(button2, null);
         }

         //------------------------------------------------------------------------------------频段测量拼接带宽
         private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
         {
             button_Click(button3, null);
         }

         //------------------------------------------------------------------------------------信号源选择
         private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (button1.Text == "连接")
             {
                 comboBox6.SelectedIndex = 0;
                 return;
             }
             groupBox4.Enabled = (comboBox6.SelectedIndex > 0) ? false : true;
             tcpClient_Send("mfs_path " + comboBox6.SelectedIndex.ToString() + "\r");// 2022-11-22 15:34:12 
         }
        //------------------------------------------------------------------------------------鼠标点击事件
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1)//鼠标单击
                {
                    show.px = e.Location.X;
                    show.py = e.Location.Y;
                }
                if (e.Clicks == 2)//鼠标双击跳到相应单频点测量
                {
                    double l_center_freq = (double)show.center_freq / 1000000.0 - show.ipan / 2000000.0;
                    double p_center_freq = l_center_freq + (((double)show.ipan / 1000000.0) / 1600) * (show.px - window_left_offset);
                    textBox2.Text = p_center_freq.ToString();
                    //show.px = window_left_offset + 800;
                    button_Click(button2, null);
                }
            }
        }

        //------------------------------------------------------------------------------------通用按键处理
        private void button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            switch (bt.Name)
            { 
                case "button1"://建立接收机连接
                    if (bt.Text == "连接")
                    {
                        if (creat_socket(Convert.ToInt32(TCPPort.Text), TCPAddr.Text, 4321))
                        {
                            bt.Text = "断开";
                            bt.BackColor = Color.Red;
                            groupBox1.Enabled = true;
                            groupBox2.Enabled = true;
                            //groupBox4.Enabled = true;
                            groupBox4.Enabled = (comboBox6.SelectedIndex > 0) ? false : true;
                            tcpClient_Send("mfs_path " + comboBox6.SelectedIndex.ToString() + "\r");
                            groupBox5.Enabled = true;
                            groupBox7.Enabled = true;
                            timer_pbt.Enabled = true;
                            button_Click(button2, null);
                        }
                    }
                    else
                    {
                        tcpClient_Send("ABORT;\r\n*CLS;\r\n");
                        //延时1秒
                        Thread.Sleep(1);
                        bt.Text = "连接";
                        bt.BackColor = Color.Green;
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = false;
                        groupBox3.Enabled = false;
                        groupBox4.Enabled = false;
                        groupBox5.Enabled = false;
                        groupBox7.Enabled = false;
                        timer_pbt.Enabled = false;
                        delect_socket();
                    }
                    break;
                                    
                case "button2"://单频点设置

                    for (int i = 0; i < 1601; i++) {
                        max_wave[i] = 350;
                    }

                    button2.BackColor = Color.Green;
                    button3.BackColor = SystemColors.Control;

                    UInt64 freq = (UInt64)(Convert.ToDouble(textBox2.Text) * 1000000);
                    //频率合理判断
                    if (freq > 5980000000) textBox2.Text = "5980";
                    if (freq < 20000000) textBox2.Text = "20";
                    freq = (UInt64)(Convert.ToDouble(textBox2.Text) * 1000000);

                    show.px = window_left_offset + 800;

                    tcpClient_Send("FREQ " + freq.ToString() + "\r");
                    show.start_freq = 0;
                    show.stop_freq = 0;
                    show.span = 40000000;
                    show.ipan = ipan_freq(comboBox1.SelectedIndex);
                    tcpClient_Send("FREQ:SPAN " + show.ipan.ToString() + "\r");

                    break;

                case "button3"://频段扫描

                    for (int i = 0; i < 1601; i++){
                        max_wave[i] = 350;
                    }

                    button3.BackColor = Color.Green;
                    button2.BackColor = SystemColors.Control;

                    groupBox3.Enabled = false;

                    UInt64 strart_freq = (UInt64)(Convert.ToDouble(textBox3.Text) * 1000000);
                    UInt64 stop_freq = (UInt64)(Convert.ToDouble(textBox5.Text) * 1000000);
                    UInt64 span_freq = 40000000;
                    if (comboBox2.SelectedIndex == 0) span_freq = 40000000;
                    if (comboBox2.SelectedIndex == 1) span_freq = 20000000;
                    if (comboBox2.SelectedIndex == 2) span_freq = 10000000;
                    //UInt64 span_freq = (UInt64)((comboBox2.SelectedIndex == 0) ? 40000000 : 20000000);
                    UInt64 mod_freq = (stop_freq - strart_freq) % span_freq;
                    //扫描带宽判断
                    if (strart_freq > stop_freq - span_freq)
                    {
                        MessageBox.Show("开始频率不能小于结束频率,请用单频点测量功能！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //修改设置的停止频率
                    if (mod_freq > 0)
                    {
                        textBox5.Text = ((stop_freq + (span_freq - mod_freq)) / 1000000).ToString();
                        stop_freq = (UInt64)(Convert.ToDouble(textBox5.Text) * 1000000);
                    }
                    show.start_freq = strart_freq;
                    show.stop_freq = stop_freq;
                    show.span = span_freq;
                    show.ipan = (show.stop_freq - show.start_freq);
                    label17.Text = "分辨率:" + (((float)show.ipan / 1600) / 1000000).ToString() + "MHz";
                    tcpClient_Send("FREQ:SPAN " + show.span.ToString() + "\r");
                    tcpClient_Send("FREQ:PSCan:STARt " + show.start_freq.ToString() + "\r");
                    tcpClient_Send("STOP " + show.stop_freq.ToString() + "\r");
                    break;

                case "button4"://宽带接收机设置
                    if (Convert.ToInt16(textBox13.Text) > 31) textBox13.Text = "31";
                    if (Convert.ToInt16(textBox14.Text) > 63) textBox14.Text = "63";
                    if (Convert.ToInt16(textBox13.Text) < 0) textBox13.Text = "0";
                    if (Convert.ToInt16(textBox14.Text) < 0) textBox14.Text = "0";
                    tcpClient_Send("wbr_mode_attn " + comboBox3.SelectedIndex + " " + Convert.ToInt16(textBox13.Text).ToString("00") + " " + Convert.ToInt16(textBox14.Text).ToString("00") + "\r");
                    break;

                case "button5"://上一个频点，最大值
                    show.px = show.px - 1;
                    break;

                case "button6"://下一个频点，最大值
                    show.px = show.px + 1;
                    break;

                case "button7"://偏移电平设置
                    tcpClient_Send("dbm_level " + (Int16.Parse(textBox1.Text) * 10).ToString() + "\r");
                    tcpClient_Send("dbm_cut_low " + (Int16.Parse(textBox10.Text)* 10).ToString() + "\r");
                    tcpClient_Send("dbm_cut_high " + (Int16.Parse(textBox11.Text)* 10).ToString() + "\r");
                    break;

                case "button8"://初始化校准值
                    tcpClient_Send("init adjust\r");
                    timer_cal.Enabled = false;
                    button12.BackColor = SystemColors.Control;
                    break;

                case "button11"://自动校准保存
                    tcpClient_Send("save adjust\r");
                    break;

                case "button12"://GPIB自动校准
                    adj_time = 0;
                    if (timer_cal.Enabled)
                    {
                        timer_cal.Enabled = false;
                        bt.BackColor = SystemColors.Control;
                        break;
                    }
                    show.cal_step = (double)ipan_freq(comboBox1.SelectedIndex) / 1600.0;
                    show.cal_freq = (double)show.center_freq  - show.ipan / 2.0;
                    show.cal_index = 0;
                    //校准参考值检查
                    int DBUV = Convert.ToInt16(textBox6.Text);
                    if (DBUV > 60 || DBUV < 20)
                    {
                        MessageBox.Show("参考值建议在20~60dbuv之间！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    e4421b_write("POWer " + DBUV.ToString() + " DBUV\n");
                    e4421b_write("FREQuency " + show.cal_freq.ToString("f1") + " Hz\n");

                    timer_cal.Enabled = true;
                    button12.BackColor = timer_cal.Enabled ? Color.Green : SystemColors.Control;
                    break;
            }
        }
        //------------------------------------------------------------------------------------
    }
}

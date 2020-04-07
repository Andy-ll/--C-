using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Security.Permissions;
using System.Collections;

using System.Runtime.InteropServices;//定义联体需要的引用
//c#中没有联体，只有用结构体来代替

namespace station
{
    //固定格式
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]




    public partial class Form2 : Form
    {
        //控制发送数据的button变化
        //int b_6 = 0;
        //int b_4 = 0;
        //int b_2 = 0;
        //int b_8 = 0;
        //int b_1 = 0;
        //int b_3 = 0;
        //int b_5 = 0;
        //int b_7 = 0;
        //坐标转换用到的常数
        const double pi = 3.14159265358979324;

        const double a = 6378245.0;

        const double ee = 0.00669342162296594323;

        const double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
        struct Loc

        {

           public double Lon;         //坐标的经度,这里一定要加public,否则具有一定的保护级别，下面访问会出错

           public double Lat;         //坐标的纬度

        };
        //double transformLat(double x, double y);        //将GPS坐标转换为google纬度坐标辅助函数

        //double transformLon(double x, double y);        //将GPS坐标转换为google经度坐标辅助函数

        ////Loc bd_encrypt(Loc gg);//将谷歌坐标转换为百度坐标

        //Loc transform(Loc gps);//将GPS坐标转换为google地图

        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public struct Union
        {
            [FieldOffset(0)]
            public Byte b0;
            [FieldOffset(1)]
            public Byte b1;
            [FieldOffset(2)]
            public Byte b2;
            [FieldOffset(3)]
            public Byte b3;
            [FieldOffset(0)]
            public UInt32 i;
            [FieldOffset(0)]
            public UInt16 f;
        }    //定义一个联体需要的信息，b3表示高字节，b0表示低字节

        public Form2()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        public class VerticalProgressBar : ProgressBar  //自定义一个垂直的progressBar
        {
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.Style |= 0x04;
                    return cp;
                }
            }
        }
        double transformLat(double x, double y)//纬度转换

        {
           
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));

            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;

            ret += (20.0 * Math.Sin(y * pi) + 40.0 * Math.Sin(y / 3.0 * pi)) * 2.0 / 3.0;

            ret += (160.0 * Math.Sin(y / 12.0 * pi) + 320 * Math.Sin(y * pi / 30.0)) * 2.0 / 3.0;

            return ret;

        }
        double transformLon(double x, double y)//经度转换

        {

            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));

            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;

            ret += (20.0 * Math.Sin(x * pi) + 40.0 * Math.Sin(x / 3.0 * pi)) * 2.0 / 3.0;

            ret += (150.0 * Math.Sin(x / 12.0 * pi) + 300.0 * Math.Sin(x / 30.0 * pi)) * 2.0 / 3.0;

            return ret;

        }
        Loc transform(Loc gps)

        {

            Loc gg;

            double dLat = transformLat(gps.Lon - 105.0, gps.Lat - 35.0);

            double dLon = transformLon(gps.Lon - 105.0, gps.Lat - 35.0);

            double radLat = gps.Lat / 180.0 * pi;

            double magic = Math.Sin(radLat);

            magic = 1 - ee * magic * magic;

            double sqrtMagic = Math.Sqrt(magic);

            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);

            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);

            gg.Lat = gps.Lat + dLat;

            gg.Lon = gps.Lon + dLon;

            return gg;

        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打印PToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //界面初始化
        private void Form2_Load(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(serialPort1, comboBox1);
            /*****************非常重要************************/
            serialPort1.ReceivedBytesThreshold = 1;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);//必须手动添加事件处理

            //string str_url = Application.StartupPath + "\\HTMLmap.html";
            ////Uri url = new Uri(str_url);
            ////webBrowser1.Url = url;
            //屏蔽webBrowser浏览器右键菜单
            //webBrowser1.IsWebBrowserContextMenuEnabled = false;
            //修改webbrowser的属性使c#可以调用js方法：
            /**********************地图操作初始化**********************/
            webBrowser1.Navigate(@"E:\2018项目材料\精准农业\station-20191121\HTMLmap.html");//调用地图编辑的语句，这里使用的是绝对地址，其实可以换非绝对地址
            webBrowser1.ObjectForScripting = this;
            timer1.Enabled = true;
        }

        //定义串口函数
        private void SearchAndAddSerialToComboBox(SerialPort MyPort, ComboBox MyBox)//MyPort相当于引用serialPort1,ComboBox MyBox 代表从comBox1 得到的COM口  
        {
            //将可用端口号添加到ComboBox              
            string Buffer;                                              //缓存              
            MyBox.Items.Clear();                                        //清空ComboBox内容              
            for (int i = 1; i < 20; i++)                                //循环这里只扫描1-19              
            {
                try                                                     //核心原理是依靠try和catch完成遍历                  
                {
                    Buffer = "COM" + i.ToString();
                    MyPort.PortName = Buffer;
                    MyPort.Open();                                      //如果失败，后面的代码不会执行                                                                         
                                                                        // MyString[count] = Buffer;                      
                    MyBox.Items.Add(Buffer);                            //打开成功，添加至下俩列表                      
                    MyPort.Close();                                     //关闭                  
                }
                catch//出错了什么也不做继续循环                  
                {
                }
            }
        }

        //串口打开与关闭
        private void button14_Click(object sender, EventArgs e)
        {
            

        }
    
        //数据接收
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口数据接收事件        
        {
            try
            {

                Union Jidu = new Union();
                Union Weidu = new Union();
                Union Gaodu = new Union();
                Union yacha = new Union();
                Union wendu = new Union();

                byte telerx_checksum = 0;
                //int count = serialPort1.BytesToRead;//接收字符的个数
                int count = 0;//接收字符的个数
                byte[] readBuffer = new byte[64];//创建接收字节数组
                byte temp;
                while (serialPort1.BytesToRead != 0)
                {
                    //serialPort1.Read(temp, 0, 1);//读取数据到readBuffer里面去
                    temp = (byte)serialPort1.ReadByte();
                    try
                    {
                        if ((count == 0) && (temp != 0xEB))
                        {
                            count += 1;
                            telerx_checksum = 0;
                            return;
                        }
                        if ((count == 1) && (temp != 0x90))
                        {
                            count += 1;
                            telerx_checksum = 0;
                            return;
                        }
                        if (count >= 63)
                        {
                            //if (telerx_checksum == temp)
                            //{
                            switch (readBuffer[2])
                            {
                                case 0x01:
                                    textBox9.Text = Convert.ToString(readBuffer[3]);//前电机转速

                                    textBox8.Text = Convert.ToString(readBuffer[4]);//后电机转速

                                    textBox7.Text = Convert.ToString(readBuffer[5]);//左电机转速

                                    textBox6.Text = Convert.ToString(readBuffer[6]);//右电机转速

                                    textBox5.Text = Convert.ToString(readBuffer[7]);//前矢量倾转角度

                                    textBox4.Text = Convert.ToString(readBuffer[8]);//后矢量倾转角度
                                    Jidu.b0 = readBuffer[3];
                                    Jidu.b1 = readBuffer[4];
                                    Jidu.b2 = readBuffer[5];
                                    Jidu.b3 = readBuffer[6];
                                    Weidu.b0 = readBuffer[7];
                                    Weidu.b1 = readBuffer[8];
                                    Weidu.b2 = readBuffer[9];
                                    Weidu.b3 = readBuffer[10];
                                    Gaodu.b0 = readBuffer[11];
                                    Gaodu.b1 = readBuffer[12];
                                    yacha.b0 = readBuffer[61];
                                    yacha.b1 = readBuffer[62];
                                    wendu.b0 = readBuffer[59];
                                    wendu.b1 = readBuffer[60];
                                    textBox1.Text = Convert.ToString(Convert.ToDouble(Gaodu.f));//飞艇当前飞行高度

                                    textBox2.Text = Convert.ToString(Convert.ToDouble(Weidu.i) / 1000000.0);//飞艇当前飞行纬度

                                    textBox3.Text = Convert.ToString(Convert.ToDouble(Jidu.i) / 1000000.0);//飞艇当前飞行经度
                                    textBox10.Text = Convert.ToString(Convert.ToDouble(yacha.f));//压差传感器的数据
                                    textBox11.Text = Convert.ToString(Convert.ToDouble(wendu.f));//温度传感器的数据

                                    break;
                                case 0x02:
                                    //textBox11.Text = Convert.ToString(readBuffer[3]);//氦气囊内温度

                                    //textBox12.Text = Convert.ToString(readBuffer[4]);//空气囊内温度

                                    //textBox10.Text = Convert.ToString(readBuffer[5]);//空气囊内压力

                                    //textBox13.Text = Convert.ToString(readBuffer[6]);//氦气囊内压力
                                    //yacha.b0 = readBuffer[61];
                                    //yacha.b1 = readBuffer[62];
                                    //wendu.b0 = readBuffer[59];
                                    //wendu.b1 = readBuffer[60];
                                    //textBox10.Text = Convert.ToString(Convert.ToDouble(yacha.f));//压差传感器的数据
                                    //textBox11.Text = Convert.ToString(Convert.ToDouble(wendu.f));//温度传感器的数据

                                    progressBar1.Value = Convert.ToInt32(readBuffer[3]);//农药液位量
                                    label1.Text = Convert.ToDouble(readBuffer[3]) + "%";//显示具体数值
                                    break;
                                default:
                                    MessageBox.Show("数据接收错误", "错误");
                                    break;

                            }
                            count = 0;
                            telerx_checksum = 0;
                            return;
                            //}
                        }

                        readBuffer[count] = temp;
                        telerx_checksum += temp;
                        count++;
                    }
                    catch
                    {

                    }
                }
                //serialPort1.DiscardInBuffer();//清空serialport控件的Buffer
                //}
                //serialPort1.DiscardInBuffer();//清空serialport控件的Buffer
                //}
                //catch
                //{
                //    MessageBox.Show("数据接收错误", "错误");
                //}
                //if (!checkBox1.Checked)//如果没有勾选，字符模式            
                //{
                //    string str = serialPort1.ReadExisting();//字符串方式读                
                //    textBox1.AppendText(str);//添加内容
                //    //textBox4.AppendText(str);
                //}
                //else//接收模式为数值接收            
                //{
                //int count = serialPort1.BytesToRead;
                //int count = 10;
                //byte[] readBuffer = new byte[count];
                //byte data;
                //data = (byte)serialPort1.ReadByte();//此处需要强制类型转换，将(int)类型数据转换为(byte类型数据，不必考虑是否会丢失数据                
                //string str = Convert.ToString(data, 16).ToUpper();//转换为大写十六进制字符串
                ////byte[] readBuffer = new byte[count];
                //textBox1.AppendText("0x" + (str.Length == 1 ? "0" + str : str) + " ");//空位补“0”   
                //string str = "";
                //do
                //{
                //    //int count = serialPort1.BytesToRead;
                //    if (count <= 0)
                //        break;
                //    //byte[] readBuffer = new byte[count];

                //    Application.DoEvents();
                //    serialPort1.Read(readBuffer, 0, count);
                //    //textBox1.Text=Convert.ToString(readBuffer[0]);
                //    //textBox4.Text = Convert.ToString(readBuffer[1]);

                //    //str += System.Text.Encoding.Default.GetString(readBuffer);
                //} while (serialPort1.BytesToRead > 0);
                //    //textBox1.Text = Convert.ToString(readBuffer[0]);
                //    string str = Convert.ToString(readBuffer[0], 16).ToUpper();//转换为大写十六进制字符串
                //textBox1.AppendText("0x" + (str.Length == 1 ? "0" + str : str) + " ");
                ////textBox4.Text = Convert.ToString(readBuffer[1]);
                //string str2 = Convert.ToString(readBuffer[1], 16).ToUpper();//转换为大写十六进制字符串
                //textBox4.AppendText("0x" + (str2.Length == 1 ? "0" + str2 : str2) + " ");
                /*listBox1.Items.Add(str)*/
                //;
                //textBox1.AppendText(str);
            }
            catch { }
        }

        public string setWhichCar(int num)
        {
            return num.ToString();
        }
        class jwd
        {
            string Lng { get; set; }
            string Lat { get; set; }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
           
                    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //获得当前鼠标所在的经纬度，然后显示在框体左下角
                string tag_lng = webBrowser1.Document.GetElementById("mouselng").InnerText;
                string tag_lat = webBrowser1.Document.GetElementById("mouselat").InnerText;
                double dou_lng, dou_lat;
                if (double.TryParse(tag_lng, out dou_lng) && double.TryParse(tag_lat, out dou_lat))
                {
                    this.toolStripStatusLabel1.Text = "当前坐标：" + dou_lng.ToString("F5") + "," + dou_lat.ToString("F5");
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ee.Message); 
            }
        }

        private void 测距ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("openGetDistance");
        }

        private void 标记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("PutInMarker");
            MessageBox.Show("请按右键添加标注！");
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("ClearAllMarkers");
        }

        private void 默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("CloseListener");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {         
        }

        private void 自主飞行设定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)                                     //串口打开就关闭            
            {
                try
                {
                    serialPort1.Close();
                }
                catch
                {
                }
                //确保万无一失                
                button5.ForeColor = Color.Black;
                //button1.BackColor = Color.Black;                
                button5.Text = "打开串口";
            }
            else
            {
                try
                {
                    serialPort1.PortName = comboBox1.Text;              //端口号                    
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text, 10);//十进制数据转换                    
                    serialPort1.Open();                                 //打开端口                    
                    button5.ForeColor = Color.Red;
                    //button1.BackColor = Color.Red;                    
                    button5.Text = "关闭串口";
                }
                catch
                {
                    MessageBox.Show("串口打开失败", "错误");
                }
            }
        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
           // textBox14.Text = "";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Loc demo, gg;
                if (textBox3.Text != "" && textBox3.Text != "")
                {
                    double lon = Convert.ToDouble(textBox3.Text);//经度，由GPS采集得到
                    double lat = Convert.ToDouble(textBox2.Text);//纬度，由GPS采集得到
                    demo.Lat = lat;
                    demo.Lon = lon;
                    gg = transform(demo);
                    //116.380967,39.913285
                    object[] objects = new object[2];
                    //当前经度
                    objects[0] = gg.Lon;
                    //当前纬度
                    objects[1] = gg.Lat;
                    //传值给html中的FindPosition函数
                    object bb = webBrowser1.Document.InvokeScript("FindPosition", objects);
                }
            }
            catch
            {

            }

        }

        private void groupBox4_Enter_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //byte[] Data = new byte[16];//定义一个变量            
            //                          //判断串口是否打开，如果打开执行下一步操作            
            //                          //如果发送的数据不是空的  
            //try
            //{
            //    byte first = 0xAA;
            //    byte second = 0x55;
            //    Data[0] = first;
            //    Data[1] = second;
            //    if (b_6 == 1 || b_4 == 1 || b_2 == 1)
            //    {
            //        Data[2] = 0x1A;
            //        if (button4.Text == "开")//button4控制氦气阀
            //        {
            //            Data[3] = 0x01;
            //        }
            //        if (button4.Text == "关")//button4控制氦气阀
            //        {
            //            Data[3] = 0x00;
            //        }
            //        if (button6.Text == "开")//button6控制空气阀
            //        {
            //            Data[4] = 0x01;
            //        }
            //        if (button6.Text == "关")//button6控制空气阀
            //        {
            //            Data[4] = 0x00;
            //        }
            //        if (button2.Text == "开")//button2控制空气风机开关
            //        {

            //            Data[5] = 0x01;
            //        }
            //        if (button2.Text == "关")//button2控制空气风机开关
            //        {
            //            Data[5] = 0x00;
            //        }
            //    }
            //    if (b_8 == 1)
            //    {
            //        Data[2] = 0x1B;
            //        if (button8.Text == "开")//button8控制喷洒农药开关
            //        {
            //            Data[3] = 0x01;
            //        }
            //        if (button8.Text == "关")//button8控制喷洒农药开关
            //        {
            //            Data[3] = 0x00;
            //        }
            //    }
            //    Data[15] = (byte)(Data[0]+Data[1]+Data[2] + Data[3] + Data[4] + Data[5]);//这里是将前面所有的数据相加得到的最后一个数据，我们只有6个有用数据，所以没有吧全部都加起来
            //    for (int i = 0; i <= 2; i++)
            //    { serialPort1.Write(Data, 0, Data.Length); }
                
            //    b_2 = 0;
            //    b_4 = 0;
            //    b_6 = 0;
            //    b_8 = 0;
            //    b_1 = 0;
            //    b_3 = 0;
            //    b_5 = 0;
            //    b_7 = 0;
            //}
            //catch
            //{
            //    MessageBox.Show("串口数据写入错误", "错误");//出错提示                        
            //    serialPort1.Close();
            //}
        }

        private void button6_Click(object sender, EventArgs e)//空气阀开关
        {
            byte[] Data = new byte[16];//定义一个变量            
                                       //判断串口是否打开，如果打开执行下一步操作            
                                       //如果发送的数据不是空的
            //b_6 = 1;
            try
            {
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1A;
                if (button4.ForeColor == Color.Red)
                { Data[3] = 0x01; }
                else if (button10.ForeColor == Color.Red)
                { Data[3] = 0x00; }
                Data[4] = 0x01;
                if (button2.ForeColor == Color.Red)
                { Data[5] = 0x01; }
                else if (button11.ForeColor == Color.Red)
                { Data[5] = 0x00; }
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button6.ForeColor = Color.Red;
                button9.ForeColor = Color.Black;
                MessageBox.Show("打开空气阀", "操作成功");

                // button6.Text = "关";
                //if (button6.Text == "开")
                //{
                //    button6.ForeColor = Color.Red;
                //    Data[4] = 0x01;
                //    Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                //    serialPort1.Write(Data, 0, Data.Length);
                //    button6.Text = "关";
                //    //b_1 = 1;
                //}
                //else if(button6.Text == "关")
                //{
                //    button6.ForeColor = Color.Black;
                //    Data[4] = 0x00;
                //    Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                //    serialPort1.Write(Data, 0, Data.Length);
                //    button6.Text = "开";
                //    //b_1 = 0;
                //}
            }
            catch
            {
                MessageBox.Show("串口数据写入错误", "错误");
                serialPort1.Close();
            }
            


        }

        private void button4_Click(object sender, EventArgs e)//氦气阀开关
        {
            byte[] Data = new byte[16];//定义一个变量            
                                       //判断串口是否打开，如果打开执行下一步操作            
                                       //如果发送的数据不是空的
            //b_4 = 1;
            try
            {
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1A;
                //if (button4.Text == "开")
                //{
                
                Data[3] = 0x01;
                if (button6.ForeColor == Color.Red)
                { Data[4] = 0x01; }
                else if (button9.ForeColor == Color.Red)
                { Data[4] = 0x00; }
                if (button2.ForeColor == Color.Red)
                { Data[5] = 0x01; }
                else if (button11.ForeColor == Color.Red)
                { Data[5] = 0x00; }
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button4.ForeColor = Color.Red;
                button10.ForeColor = Color.Black;
                MessageBox.Show("打开氦气阀", "操作成功");
                //    button4.Text = "关";
                //    //b_3 = 1;//能够让button打开和关闭互换
                //}
                //else if(button4.Text == "关")
                //{
                //    button4.ForeColor = Color.Black;
                //    Data[3] = 0x00;
                //    Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                //    serialPort1.Write(Data, 0, Data.Length);
                //    button4.Text = "开";
                //    //b_3 = 0;
                //}
            }
            catch
            {
                MessageBox.Show("串口数据写入错误", "错误");
                serialPort1.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)//风机开关
        {
            byte[] Data = new byte[16];
            //b_2 = 1;
            try
            {
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1A;
                if (button4.ForeColor == Color.Red)
                { Data[3] = 0x01; }
                else if (button10.ForeColor == Color.Red)
                { Data[3] = 0x00; }
                if (button6.ForeColor == Color.Red)
                { Data[4] = 0x01; }
                else if (button9.ForeColor == Color.Red)
                { Data[4] = 0x00; }
                //if (button2.Text == "开")
                //{
                Data[5] = 0x01;
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button2.ForeColor = Color.Red;
                button11.ForeColor = Color.Black;
                MessageBox.Show("打开鼓风机", "操作成功");
                //    button2.Text = "关";

                //    //b_5 = 1;
                //}
                //else if (button2.Text == "关")
                //{
                //    button2.ForeColor = Color.Black;
                //    Data[5] = 0x00;
                //    Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                //    serialPort1.Write(Data, 0, Data.Length);
                //    button2.Text = "开";
                //    //b_5 = 0;
                //}
            }
            catch
            {
                MessageBox.Show("串口数据写入错误", "错误");
                serialPort1.Close();
            }


        }

        private void button8_Click(object sender, EventArgs e)//喷洒农药开关
        {
            byte[] Data = new byte[16];
            //b_8 = 1;
            try
            {
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1B;

                //if (button8.Text == "开")
                //{
                button8.ForeColor = Color.Red;
                Data[3] = 0x01;
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button8.ForeColor = Color.Red;
                button12.ForeColor = Color.Black;
                MessageBox.Show("打开喷洒农药设备", "操作成功");
                //    button8.Text = "关";
                //    //b_7 = 1;
                //}
                //else if(button8.Text == "关")
                //{
                //    button8.ForeColor = Color.Red;
                //    Data[3] = 0x01;
                //    Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                //    serialPort1.Write(Data, 0, Data.Length);
                //    button8.Text = "开";
                //    //b_7 = 0;
                //}
            }
            catch
            {
                MessageBox.Show("串口数据写入错误", "错误");
                serialPort1.Close();
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Data = new byte[16];
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1A;
                if (button4.ForeColor == Color.Red)
                { Data[3] = 0x01; }
                else if (button10.ForeColor == Color.Red)
                { Data[3] = 0x00; }
                Data[4] = 0x00;
                if (button2.ForeColor == Color.Red)
                { Data[5] = 0x01; }
                else if (button11.ForeColor == Color.Red)
                { Data[5] = 0x00; }
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button9.ForeColor = Color.Red;
                button6.ForeColor = Color.Black;

                MessageBox.Show("关闭空气阀", "操作成功");
            }
            catch { MessageBox.Show("关闭空气阀不成功", "操作失败"); }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            byte[] Data = new byte[16];
            try
            {
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1A;
                Data[3] = 0x00;
                if (button6.ForeColor == Color.Red)
                { Data[4] = 0x01; }
                else if (button9.ForeColor == Color.Red)
                { Data[4] = 0x00; }
                if (button2.ForeColor == Color.Red)
                { Data[5] = 0x01; }
                else if (button11.ForeColor == Color.Red)
                { Data[5] = 0x00; }
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button10.ForeColor = Color.Red;
                button4.ForeColor = Color.Black;
                MessageBox.Show("关闭氦气阀", "操作成功");
            } catch { MessageBox.Show("关闭氦气阀不成功", "操作失败"); }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            byte[] Data = new byte[16];
            try {
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1A;
                if (button4.ForeColor == Color.Red)
                { Data[3] = 0x01; }
                else if (button10.ForeColor == Color.Red)
                { Data[3] = 0x00; }
                if (button6.ForeColor == Color.Red)
                { Data[4] = 0x01; }
                else if (button9.ForeColor == Color.Red)
                { Data[4] = 0x00; }
                Data[5] = 0x00;
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button11.ForeColor = Color.Red;
                button2.ForeColor = Color.Black;
                MessageBox.Show("关闭鼓风机", "操作成功");
            } catch { MessageBox.Show("关闭鼓风机不成功", "操作失败"); }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            byte[] Data = new byte[16];
            try
            {
                byte first = 0xAA;
                byte second = 0x55;
                Data[0] = first;
                Data[1] = second;
                Data[2] = 0x1B;
                Data[3] = 0x00;
                Data[15] = (byte)(Data[0] + Data[1] + Data[2] + Data[3] + Data[4] + Data[5]);
                serialPort1.Write(Data, 0, Data.Length);
                button12.ForeColor = Color.Red;
                button8.ForeColor = Color.Black;
                MessageBox.Show("关闭喷洒农药设备", "操作成功");
            } catch { MessageBox.Show("关闭喷洒农药不成功", "操作失败"); }
            
        }
    }
}

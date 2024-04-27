using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPClient
{
    public partial class Form1 : Form
    {
        private UdpClient _UdpClient;
        private UdpClient sendUdpClientMulti;
        private UdpClient receiveUpdClientMulti;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> ips = GetLocalIpAddress(AddressFamily.InterNetwork.ToString());
            comboBox_local_ip.DataSource = ips;
            comboBox_remote_ip.DataSource = ips;
        }





        /// <summary>
        /// 获取本机所有ip地址
        /// </summary>
        /// <param name="netType">"InterNetwork":ipv4地址，"InterNetworkV6":ipv6地址</param>
        /// <returns>ip地址集合</returns>
        public static List<string> GetLocalIpAddress(string netType)
        {
            string hostName = Dns.GetHostName();                    //获取主机名称
            IPAddress[] addresses = Dns.GetHostAddresses(hostName); //解析主机IP地址

            List<string> IPList = new List<string>();
            if (netType == string.Empty)
            {
                for (int i = 0; i < addresses.Length; i++)
                {
                    IPList.Add(addresses[i].ToString());
                }
            }
            else
            {
                //AddressFamily.InterNetwork表示此IP为IPv4,
                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                for (int i = 0; i < addresses.Length; i++)
                {
                    if (addresses[i].AddressFamily.ToString() == netType)
                    {
                        IPList.Add(addresses[i].ToString());
                    }
                }
            }
            return IPList;
        }

        //打开连接
        private void button_connect_Click(object sender, EventArgs e)
        {
            if (button_connect.Text.Equals("打开连接"))
            {
                if (checkBox_multi.Checked == false)
                {
                    if (_UdpClient != null)
                    {
                        return;
                    }
                    // 创建接收套接字
                    IPAddress localIp = IPAddress.Parse(comboBox_local_ip.Text);
                    IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(textBox_local_port.Text));
                    _UdpClient = new UdpClient(localIpEndPoint);


                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.Start();
                    button_connect.Text = "关闭连接";
                }
                else //组播
                {
                    if (receiveUpdClientMulti != null)
                    {
                        return;
                    }
                    // 创建接收套接字
                    IPAddress localIp = IPAddress.Parse(comboBox_local_ip.Text);
                    IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(textBox_local_port.Text));
                    //关键代码
                    //receiveUpdClientMulti = new UdpClient(int.Parse(textBox_multi_port.Text));
                    receiveUpdClientMulti = new UdpClient();
                    receiveUpdClientMulti.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    receiveUpdClientMulti.Client.Bind(new IPEndPoint(IPAddress.Any, int.Parse(textBox_multi_port.Text)));
                    receiveUpdClientMulti.JoinMulticastGroup(IPAddress.Parse(textBox_multi_ip.Text));

                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.Start();
                    button_connect.Text = "关闭连接";
                }
            }
            else
            {
                if (checkBox_multi.Checked == false)
                {
                    if (_UdpClient != null)
                    {
                        _UdpClient.Close();
                        _UdpClient = null;
                    }
                    button_connect.Text = "打开连接";
                }
                else //组播
                {
                    if (receiveUpdClientMulti != null)
                    {
                        receiveUpdClientMulti.Close();
                        receiveUpdClientMulti = null;
                    }
                    button_connect.Text = "打开连接";
                }
            }
        }

        // 接收消息方法
        private void ReceiveMessage()
        {
            if (checkBox_multi.Checked == false)
            {
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    try
                    {
                        // 关闭receiveUdpClient时此时会产生异常
                        byte[] receiveBytes = _UdpClient.Receive(ref remoteIpEndPoint);

                        string message = Encoding.Unicode.GetString(receiveBytes);

                        // 显示消息内容
                        ShowMessageforView(textBox_receive, string.Format("{0}[{1}]", remoteIpEndPoint, message));
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            else  //组播
            {
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    try
                    {
                        if (receiveUpdClientMulti.Available > 0)
                            continue;
                        byte[] receiveBytes = receiveUpdClientMulti.Receive(ref remoteIpEndPoint);

                        string message = Encoding.Unicode.GetString(receiveBytes);

                        // 显示消息内容
                        ShowMessageforView(textBox_receive, string.Format("{0}[{1}]", remoteIpEndPoint, message));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                }
            }
        }

        // 利用委托回调机制实现界面上消息内容显示
        delegate void ShowMessageforViewCallBack(TextBox textbox, string text);
        private void ShowMessageforView(TextBox textbox, string text)
        {
            if (textbox.InvokeRequired)
            {
                ShowMessageforViewCallBack showMessageforViewCallback = ShowMessageforView;
                textbox.Invoke(showMessageforViewCallback, new object[] { textbox, text });
            }
            else
            {
                textbox.AppendText(text);
                textbox.AppendText("\r\n");
            }
        }

        //发送
        private void button_send_Click(object sender, EventArgs e)
        {
            if (checkBox_multi.Checked == false)
            {
                if (textBox_send.Text == string.Empty)
                {
                    MessageBox.Show("发送内容不能为空", "提示");
                    return;
                }
                if (_UdpClient == null)
                {
                    MessageBox.Show("请打开连接", "提示");
                    return;
                }
                IPAddress localIp = IPAddress.Parse(comboBox_local_ip.Text);
                IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(textBox_local_port.Text));
                string remote_ip = comboBox_remote_ip.Text.Trim();
                Thread sendThread = new Thread(SendMessage);
                sendThread.Start(remote_ip);
            }
            else //组播
            {
                if (textBox_send.Text == string.Empty)
                {
                    MessageBox.Show("发送内容不能为空", "提示");
                    return;
                }
                if (sendUdpClientMulti != null)
                {
                    IPAddress multiIP = IPAddress.Parse(textBox_multi_ip.Text);
                    IPEndPoint multiIPEndPoint = new IPEndPoint(multiIP, int.Parse(textBox_multi_port.Text));
                    Thread sendThread = new Thread(SendMessage);
                    sendThread.Start(multiIPEndPoint);
                }
                else
                {
                    IPAddress multiIP = IPAddress.Parse(textBox_multi_ip.Text);
                    IPEndPoint multiIPEndPoint = new IPEndPoint(multiIP, int.Parse(textBox_multi_port.Text));
                    string remote_ip = comboBox_remote_ip.Text.Trim();
                    sendUdpClientMulti = new UdpClient();
                    sendUdpClientMulti.EnableBroadcast = true;
                    Thread sendThread = new Thread(SendMessage);
                    sendThread.Start(multiIPEndPoint);
                }

            }
        }

        // 发送消息方法
        private void SendMessage(object obj)
        {
            try
            {
                if (checkBox_multi.Checked == false)
                {
                    string message = textBox_send.Text.Trim();
                    byte[] sendbytes = Encoding.Unicode.GetBytes(message);
                    IPAddress remoteIp = IPAddress.Parse((string)obj);
                    IPEndPoint remoteIpEndPoint = new IPEndPoint(remoteIp, int.Parse(textBox_remote_port.Text));
                    _UdpClient.Send(sendbytes, sendbytes.Length, remoteIpEndPoint);
                    // 清空发送消息框
                    //ResetMessageText(textBox_send);
                }
                else //组播
                {
                    string message = textBox_send.Text.Trim();
                    byte[] sendbytes = Encoding.Unicode.GetBytes(message);
                    IPEndPoint remoteIpEndPoint = (IPEndPoint)obj;
                    sendUdpClientMulti.Send(sendbytes, sendbytes.Length, remoteIpEndPoint);
                    //sendUdpClientMulti.Close();
                    // 清空发送消息框
                    //ResetMessageText(textBox_send);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // 采用了回调机制
        // 使用委托实现跨线程界面的操作方式
        delegate void ResetMessageCallback(TextBox textbox);
        private void ResetMessageText(TextBox textbox)
        {
            // Control.InvokeRequired属性代表
            // 如果控件的处理与调用线程在不同线程上创建的，则为true,否则为false
            if (textbox.InvokeRequired)
            {
                ResetMessageCallback resetMessagecallback = ResetMessageText;
                textbox.Invoke(resetMessagecallback, new object[] { textbox });
            }
            else
            {
                textbox.Clear();
                textbox.Focus();
            }
        }

        // 采用了回调机制
        // 使用委托实现跨线程界面的操作方式
        private delegate void GetComboboxCallback(ComboBox combobox);
        private void GetComboboxText(ComboBox combobox)
        {
            // Control.InvokeRequired属性代表
            // 如果控件的处理与调用线程在不同线程上创建的，则为true,否则为false
            if (combobox.InvokeRequired)
            {
                GetComboboxCallback getcomboboxcallback = GetComboboxText;
                combobox.Invoke(getcomboboxcallback, new object[] { combobox });
            }
            else
            {
                //combobox.Text =  combobox.Text.Trim();
            }
        }
    }
}

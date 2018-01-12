using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSystem
{
    public partial class MainForm : Form
    {
        ws.LoginTag lt = null;
        string id = "";
        static callback cb = null;
        public ws.GPFserviceClient con = null;
        const int WM_COPYDATA = 0x004A;
        int rnum = 0;//创建房间数
        string PATH="";     //用来保存应用程序路径
        public MainForm(ws.GPFserviceClient c,callback cb0)
        {
            InitializeComponent();
            //初始化回调对象
            con = c;
            cb = cb0;
            cb.getmf(this);            
        }
        public void getguid(ws.LoginTag lt, string id)
        {
            this.lt = lt;
            this.id = id;            
        }//个人信息加载
        private async void refreshroomlist()
        {
            //获取房间列表
            ws.roomer[] rms = await con.getroomAsync();
            lvRoom.Items.Clear();
            foreach (ws.roomer temp in rms)
            {
                lvRoom.Items.Add(temp.roomid.ToString());
            }
        }

        public void refreshroom(string rid)
        {
            ws.roomer a = con.TheRoomInformation(rid);
            label11.Text = a.roomid.ToString();
            label12.Text = a.number.ToString();
            label13.Text = a.houseowner;
            label15.Text = a.type;
        }
        public void load()
        {
            //获取好友列表
            string[] frs = con.getfriend(lt.userid);
            foreach (string temp in frs)
            {
                lvFriend.Items.Add(temp);
            }
            ws.info a = con.PersonalInformation(id);
            label8.Text = a.name;
            label9.Text = a.sex;
            label10.Text = a.zh.ToString();
           // this.refreshroom();
            //获取个人信息
        }//信息加载               
        private void 切换账号ToolStripMenuItem_Click(object sender, EventArgs e)  //切换账号
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        } 
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)  //退出程序
        {
            Application.Exit();
        }

        #region 按钮美化
        private void btnSend_MouseMove(object sender, MouseEventArgs e)
        {
            btnSend.Image = imageList1.Images[0];
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            btnSend.Image = imageList1.Images[1];
        }

        private void btnQK_MouseMove(object sender, MouseEventArgs e)
        {
            btnQK.Image = imageList1.Images[2];
        }

        private void btnQK_MouseLeave(object sender, EventArgs e)
        {
            btnQK.Image = imageList1.Images[3];
        } 
        #endregion

        private void btnQK_Click(object sender, EventArgs e)   //清空
        {
            txtInfo.Text = "";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)  //添加好友
        {
            AddFriend frm = new AddFriend(con);
            frm.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e) //创建房间
        {
            AddRoom frm = new AddRoom();
            DialogResult dr=frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ws.roomer rm = frm.rm;
                rm.roomid = int.Parse(id)*10+rnum;
                con.createroom(rm);
                refreshroomlist();
                refreshroom(rm.roomid.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //选择程序
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            PATH = ofd.FileName;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //开始程序
        {
            if (PATH.Equals("")&&path.Equals(""))
            {
                MessageBox.Show("请选择要打开的程序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //**************************************************************************************************************
                //     应用程序路径：PATH                                         外部框架控件名：panel4
                //**************************************************************************************************************
                //实现程序的打开
                preload(inputPath);
                preplay(inputPath, inpath);
                Thread t1 = new Thread(new ParameterizedThreadStart(sendvideo));
                t1.Start(inpath);
                myClient.vlenup(duration);
                this.progressBar1.Visible = true;
                timer2.Enabled = true;
            }
        }

        private void 发送消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chat frm = new Chat();
            DialogResult dr = frm.ShowDialog();
            string msg = frm.textBox1.Text;
            if (dr == DialogResult.OK)
            {
                string user = lvFriend.SelectedItems[0].Text;
                con.sendmessage(user, msg);
            }
            frm.Dispose();
        }

        private void btnSend_Click(object sender, EventArgs e)   //发生公屏消息
        {

        }

        #region 发送消息
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        int hWnd, // handle to destination window
        int Msg, // message
        int wParam, // first message parameter
        ref COPYDATASTRUCT lParam // second message parameter
        );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string
        lpWindowName);

        private void sdm(string guid)
        {
            int WINDOW_HANDLER = FindWindow(null, this.FindForm().Name);
            if (WINDOW_HANDLER == 0)
            {
            }
            else
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(guid);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = guid;
                cds.cbData = len + 1;
                SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref cds);

            }
        }

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        #endregion    

        private void MainForm_Load(object sender, EventArgs e)
        {
            //load();
            refreshroomlist();
        }

        private void 同意添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lisv.SelectedItems.Count!=0){
            id = lisv.SelectedItems[0].Tag.ToString();
            con.faccess(id);   
            }
        }

        private void 删除信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lisv.SelectedItems.Count != 0)
            {
                lisv.SelectedItems.Clear();
                
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvRoom.SelectedItems.Count != 0)
            {
                Dl dl0 = new Dl(myClient,myFileMessage);
                dl0.Parent = this.panel5;
                dl0.Show();
            }
        }
        #region 加载播放影片
        fs.UploadFileClient myClient = new fs.UploadFileClient();
        fs.FileUploadMessage myFileMessage = new fs.FileUploadMessage();
        string outputPath = @"D:\FFOutput\out";
        string path = @"D:\资料\ffmpeg-20160626-074fdf4-win64-static\bin\ffmpeg.exe";
        int duration;
        int timerticknum=0;
        int proi = 0;
        string inputPath = @"D:\sj\三体赋.mp4";
        string inpath = @"D:\FFOutput\三体赋p.avi";
        private void preload(string inputPath)
        {
            string args = " -i " + inputPath;
            Process p = np(args);
            p.Start();
            System.IO.StreamReader errorreader = p.StandardError;
            string result = errorreader.ReadToEnd();
            p.Close();
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);
                string re1 = result.Substring(0, 2);
                string re2 = result.Substring(3, 2);
                string re3 = result.Substring(6, 2);
                duration = ((int.Parse(re1) * 60) + int.Parse(re2)) * 60 + int.Parse(re3);
            }
        }
        private void preplay(string inputPath,string inpath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("-i {0} -q:a 1 -intra {1}", inputPath, inpath);
            string args = sb.ToString();
            Process p = np(args);
            p.Start();
            System.IO.StreamReader errorreader = p.StandardError;
            string result = errorreader.ReadToEnd();
            string re = result.Substring(result.LastIndexOf("time") + 5, 11);
        }
        private Process np(string args)
        {
            ProcessStartInfo psi = new ProcessStartInfo(path, args);
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;//不创建进程窗口                
            p.ErrorDataReceived += new DataReceivedEventHandler(Output);//外部程序(这里是FFMPEG)输出流时候产生的事件,这里是把流的处理过程转移到下面的方法中,详细请查阅MSDN
            return p;
        }
        private void Output(object sendProcess, DataReceivedEventArgs output)
        {
            if (!String.IsNullOrEmpty(output.Data))
            {
                //处理方法...
                Console.WriteLine(output.Data);
            }
        }
        private void sendvideo(Object inpath)
        {
            for (proi = 1; proi < duration; proi++)
            {
                StringBuilder a = new StringBuilder();
                a.AppendFormat("-ss {2} -i {0} -vcodec copy -acodec copy -t 00:05:00 {1}",(string)inpath, outputPath + proi + ".mp4", gt(proi));
                string arguments = a.ToString();                
                Process p = np(arguments);
                //if (proi < duration - 5)
                //{
                //    p.Exited += new EventHandler(proc_Exited);
                //}
                    p.Start();//启动线程
                    p.BeginErrorReadLine();//开始异步读取
                    p.Close();
            }
        }
            
        private string gt(int a)
        {
            string time = "";
            if (a < 60)
            {
                time = "00:00:" + gta(a);
            }
            else if (a < 3600)
            {
                time = "00:" + gta(a / 60) + ":" + gta(a % 60);
            }
            else
            {
                int b = a % 3600;
                time = gta(a / 3600) + ":" + gta(b / 60) + ":" + gta(b % 60);
            }
            return time;
        }
        private string gta(int a)
        {
            string ti = "";
            if (a < 10)
            {
                ti = "0" + a;
            }
            else
            {
                ti = a.ToString();
            }
            return ti;
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bplay.Visible = false;
            Dl dl0 = new Dl(inputPath);
            dl0.Parent = this.panel5;
            dl0.Show();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerticknum++;
            if (timerticknum > duration)
            {
                timerticknum = 0;
                timer1.Enabled = false;
            }
            string pathtemp = outputPath + timerticknum + ".mp4";
            string fsname = "out" + timerticknum + ".mp4";
            using (Stream fs = new FileStream(pathtemp, FileMode.Open))
            {
                myClient.uploadvideo(fsname,fs.Length,fs);
                fs.Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timerticknum++;
            if (timerticknum > 50)
            {
                this.progressBar1.Visible = false;
                bplay.Visible = true;
                timerticknum = 0;
                timer2.Enabled = false;
            }
            this.progressBar1.Increment(2);
        }
    }
}

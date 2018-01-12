using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace GameSystem
{
    public partial class Dl : Form
    {
        fs.UploadFileClient myClient;
        fs.FileUploadMessage myFileMessage;
        int j = 1;
        int vlong = 0;
        string path = @"D:\temp";
        public Dl(fs.UploadFileClient myClient, fs.FileUploadMessage myFileMessage)
        {
            InitializeComponent();
            this.label1.Visible = false;
            this.label2.Visible=false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.myClient = myClient;
            this.myFileMessage = myFileMessage;
            int[] num = myClient.getvnum();
            j = num[0];
            vlong = num[1];
            if (j == vlong)
            {

            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            for (int i = j; i < j + Math.Max(j + 30, vlong); i++)
            {
                Download("out" + i + ".mp4", path + @"\out" + i + ".mp4");
            }
                timer1.Enabled = true;
        }
        public Dl(string fpath) {
            InitializeComponent();
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            button1.Visible = false;
            path = fpath;
            timer2.Enabled = true;
        }

        public void UploadFileMethod(string fileName, string fileFullPath)
        {            
            myFileMessage.FileName = fileName;//文件名
            using (FileStream fs = File.OpenRead(fileFullPath))
            {
                myFileMessage.FileData = fs;
                fs.IUploadFile myService = myClient.ChannelFactory.CreateChannel();
                try
                {
                    myService.UploadFileMethod(myFileMessage);
                }
                catch { }
                //关闭流
                fs.Close();
            }
        }

        public void Download(string f,string p)
        {
            //从服务器中获取文件流
            Stream filestream = new MemoryStream();
            bool iss=true;
            string msg="";
            long filesize = myClient.DownLoadFile(f,out iss,out msg,out filestream);

            if (iss)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                byte[] buffer = new byte[filesize];
                FileStream fs = new FileStream(path + @"\"+f, FileMode.Create, FileAccess.Write);
                int count = 0;
                while ((count = filestream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, count);
                }

                //清空缓冲区
                fs.Flush();
                //关闭流
                fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public const int WS_BORDER = 0x00800000;
        public const int WS_CAPTION = 0x00C00000;
        public const int WS_CHILD = 0x40000000;
        //
        QuartzTypeLib.FilgraphManager m_FilterManager;//管理器
        QuartzTypeLib.IVideoWindow m_VideoWindow;//视频窗体
        QuartzTypeLib.IMediaEvent m_MediaEvent;//媒体事件
        QuartzTypeLib.IMediaEventEx m_MediaEventEx;//媒体事件扩展
        QuartzTypeLib.IMediaPosition m_MediaPos;//媒体当前位置
        QuartzTypeLib.IMediaControl m_MediaCtrl;//媒体控制器
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            m_MediaCtrl.Stop();
            j = 1;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"D:\temp");
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo fi in fileinfo)
                {
                    if (fi is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(fi.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(fi.FullName);      //删除指定文件
                    }
                }
                Directory.Delete(@"D:\temp");
            }
            catch {}
            finally
            {
                this.Dispose();
            }
        }

        private void play(string args)
        {
            m_FilterManager = new QuartzTypeLib.FilgraphManager();//
            m_FilterManager.RenderFile(args);//设置待播放文件
            m_VideoWindow = m_FilterManager as QuartzTypeLib.IVideoWindow;//设置播放窗体            
            m_VideoWindow.Owner = (int)(this.panel1.Handle);
            m_VideoWindow.WindowStyle &= ~WS_BORDER;
            m_VideoWindow.SetWindowPosition(0, 0, this.panel1.Width, this.panel1.Height);
            m_MediaEvent = m_FilterManager as QuartzTypeLib.IMediaEvent;//设置媒体事件
            m_MediaEventEx = m_FilterManager as QuartzTypeLib.IMediaEventEx;//设置媒体事件扩展
            m_MediaPos = m_FilterManager as QuartzTypeLib.IMediaPosition;//设置媒体位置
            m_MediaCtrl = m_FilterManager as QuartzTypeLib.IMediaControl;//设置媒体控制器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (j >= vlong)
            {
                timer1.Enabled=false;
            }if(j+30<=vlong){
            Download("out" + (j+30) + ".mp4", path + @"\out" + (j+30) + ".mp4");
            }
            GC.Collect();
            j++;
            play(@"D:\temp\out" + j + ".mp4");
            m_MediaCtrl.Run();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (retime == 0)
            {
                play(path);
                m_MediaCtrl.Run();
                label1.Visible = false;
                label2.Visible=false;
                timer2.Enabled = false;
            }
            if (retime == 5)
            {
                label2.Text = "准备好，影片即将开始";
            }
            label1.Text=retime.ToString();
            retime--;
        }
        int retime = 30;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSystem
{
    public partial class Login : Form
    {
        static callback cb = new callback();
        static InstanceContext context = new InstanceContext(cb);
        ws.GPFserviceClient con = new GameSystem.ws.GPFserviceClient(context, "WSDualHttpBinding_IGPFservice");
        public Login()
        {
            InitializeComponent();
        }

        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = imageList1.Images[1];
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = imageList1.Images[0];
            }
            catch
            {
                
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = imageList2.Images[1];
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = imageList2.Images[0];
            }
            catch
            {
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)  //登录
        {
            if (txtUserId.Text.Trim().Equals(string.Empty) || txtPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入完整的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    //*********************************************************************************************************************************
                    //          用户名控件名：txtUserId                                                  密码控件名：txtPwd
                    //*********************************************************************************************************************************

                    string id = txtUserId.Text;
                    string pwd = txtPwd.Text;
                    ws.LoginTag lt = con.login(id, pwd);
                    if (lt==null) 
                    {
                        MessageBox.Show("登录失败！");
                        return;
                    }
                    MainForm frm = new MainForm(con,cb);
                    frm.getguid(lt, id);
                    //frm.load();
                    frm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  //注册
        {
            SignUp frm = new SignUp();
            frm.Show();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //这个1000 是特效结束的时间，单位毫秒  -   -
            AnimateWindow(this.Handle, 1000, AW_CENTER | AW_HIDE);
        }

    }
}

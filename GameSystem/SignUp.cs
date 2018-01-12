using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSystem
{
    public partial class SignUp : Form
    {
        ws.GPFserviceClient con = null;
        public SignUp()
        {
            InitializeComponent();
        }

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

        private void pictureBox1_Click(object sender, EventArgs e)  //关闭
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)  //注册
        {
            if (txtUserId.Text.Trim().Equals(string.Empty) || txtPwd1.Text.Trim().Equals(string.Empty) || txtPwd2.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入完整的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!txtPwd1.Text.Trim().Equals(txtPwd2.Text.Trim()))
            {
                MessageBox.Show("两次密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    //*********************************************************************************************************************************
                    //          用户名控件名：txtUserId                    密码控件名：txtPwd
                    //*********************************************************************************************************************************

                    if (txtPwd1.Text.Trim().Equals(txtPwd2.Text.Trim()))
                    {
                        ws.info info = new GameSystem.ws.info();
                        info.zh = Int32.Parse(txtUserId.Text);
                        info.pwd = txtPwd1.Text;
                        bool su = con.register(info);
                        if (su)//注册成功执行
                        {
                            MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("两次密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

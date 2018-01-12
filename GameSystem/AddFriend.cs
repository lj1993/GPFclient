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
    public partial class AddFriend : Form
    {
        ws.GPFserviceClient con = null;
        public AddFriend(ws.GPFserviceClient c)
        {
            InitializeComponent();
            con = c;
        }

        private void button1_Click(object sender, EventArgs e)  //查找
        {
            if (txtUserId.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入要查找用户的昵称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //******************************************************************************************************************
                //                      listview控件名称：listView1
                //******************************************************************************************************************
                ws.xianshi[] xs = con.getuser();
                foreach (ws.xianshi temp in xs)
                {
                    if (txtUserId.Text.Equals(temp.zh.ToString()))
                    {
                        ListViewItem li = new ListViewItem(temp.zh.ToString());
                        listView1.Items.Add(li);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)  //添加
        {
            if (this.listView1.SelectedItems != null && this.listView1.SelectedItems.Count > 0)
            {
                //**************************************************************************************
                //实现添加功能
                //**************************************************************************************
                con.fapply(listView1.SelectedItems[0].Text);
            }
            else
            {
                MessageBox.Show("请选择要添加的好友！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}

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
    public partial class AddRoom : Form
    {
        public ws.roomer rm;
        public AddRoom()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)  //创建房间
        {
            if (txtRoomName.Text.Trim().Equals(string.Empty) || txtRoomPeople.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入完整的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //*************************************************************************************************************
                //              房间信息控件名：txtRoomName             房间人数控件名：txtRoomPeople
                //*************************************************************************************************************
                rm = new ws.roomer();
                rm.type = txtRoomName.SelectedText;
                rm.number = Int32.Parse(txtRoomPeople.Text.Trim()); 
                //实现添加功能                
            }
        }
    }
}

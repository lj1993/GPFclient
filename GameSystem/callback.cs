using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSystem
{
     public class callback:ws.IGPFserviceCallback
    {
      MainForm f1;
      public callback()
      {

      }
      public void getmf(MainForm f)
      {
          this.f1 = f;
      }
      void ws.IGPFserviceCallback.Receive(string p1, string p2)
      {
          string msg = p1 + ":" + p2 + "\r\n";
          f1.richTextBox1.AppendText(msg);
      }
      void ws.IGPFserviceCallback.ReceiveWhisper(string p1, string p2)
      {
          string msg = p1 + ":" + p2 + "\r\n";
          Chat a = new Chat();
          a.richTextBox1.AppendText(msg);
          a.ShowDialog();
      }
      void ws.IGPFserviceCallback.UserEnter(string p)
      {
          f1.lvFriend.Items.Add(p);
      }
      void ws.IGPFserviceCallback.UserLeave(string p)
      {
          foreach (ListViewItem temp in f1.lvFriend.Items)
          {
              if (temp.Text.Equals(p))
              {
                  f1.lvFriend.Items.Remove(temp);
                  break;
              }
          }
      }

      void ws.IGPFserviceCallback.Announce(string a)
      {
          //f1.textBox2.Text = a;
      }

      void ws.IGPFserviceCallback.cfapply(string id)
      {
         // DialogResult dr = MessageBox.Show("收到来自" + id + "的好友申请，是否同意？", "好友申请", System.Windows.Forms.MessageBoxButtons.YesNo);
          string msg=  "来自" + id + "的好友申请 ";         
          ListViewItem a = new ListViewItem(msg);
          a.Tag = id;
          f1.lisv.Items.Add(a);
      }
      
      void ws.IGPFserviceCallback.cfacc(string id)
      {
          f1.lvFriend.Items.Add(id);

      }
    }
}

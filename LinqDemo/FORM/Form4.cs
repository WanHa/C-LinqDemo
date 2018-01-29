using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqDemo.FORM
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strUserName = this.txtUserName.Text;
            string strOldPwd = this.txtOldPwd.Text;
            string strNewPwd = this.txtNewPwd.Text;
            string strConfirm = this.txtConfirm.Text;
            CheckInputInfo cii = new LinqDemo.CheckInputInfo();
            string strBackInfo=cii.CheckUpdatePasswordInfo(strUserName, strOldPwd, strNewPwd, strConfirm);
            if(strBackInfo=="OK")
            {

                P_USER_INFO pui = new LinqDemo.P_USER_INFO();
                bool bolUpdateStatus=pui.Update_User_Password(strUserName, strNewPwd);
                if(bolUpdateStatus==true)
                {
                    MessageBox.Show("更新成功");
                    this.Close();
                    //Form1 f1 = new Form1();
                    //f1.Show();
                }
                else
                {
                    MessageBox.Show("更新失败，请重新尝试");
                }
                
            }
            else
            {
                MessageBox.Show(strBackInfo);
            }
            
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}

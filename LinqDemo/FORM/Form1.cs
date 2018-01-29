using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserName = this.txtUserName.Text;
            string strPassword = this.txtPassword.Text;

            if(strUserName.Equals("") || strUserName.Equals(String.Empty))
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (strPassword.Equals("") || strPassword.Equals(String.Empty))
            {
                MessageBox.Show("请输入密码");
                return;
            }

            P_USER_LOGIN pul = new P_USER_LOGIN();
            Tuple<Guid,bool,bool,bool> tpui= pul.Check_Login_Info(strUserName, strPassword);
            if(tpui.Item3==false)
            {
                MessageBox.Show("用户名不存在");
                return;
            }
            if (tpui.Item4 == false)
            {
                MessageBox.Show("密码错误");
                return;
            }
            if (tpui.Item2 == true)
            {
                MessageBox.Show("用户名已登录");
                return;
            }
            
            //显示主窗体
            //MessageBox.Show("登陆成功");
            Form2 f2 = new Form2();
            f2.User_ID = tpui.Item1;
            f2.Show();
            this.Hide();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            FORM.Form3 f3 = new FORM.Form3();
            this.Visible = false;
            f3.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FORM.Form4 f4 = new FORM.Form4();
            this.Visible = false;
            f4.Show();
            
        }
    }
}

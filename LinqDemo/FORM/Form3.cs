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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            CheckInputInfo cii = new CheckInputInfo();
            P_USER_INFO pui = new P_USER_INFO();
            T_USER_INFO tui = new T_USER_INFO();
            //check input info
            string strUserName = this.txtUserName.Text;
            string strPassword = this.txtPassword.Text;
            string strConfirm = this.txtConfirm.Text;
            string strMobile = this.txtMobile.Text;
            string strEmail = this.txtEmail.Text;
            
            string backinfo = cii.CheckRegistInfomation(strUserName, strPassword, strConfirm, strMobile, strEmail);
            if (backinfo=="OK")
            {
                tui.F_USER_ID = Guid.NewGuid();
                tui.F_USER_NAME = strUserName;
                tui.F_USER_PASSWORD = strPassword;
                tui.F_USER_EMAIL = strEmail;
                tui.F_USER_MOBILE = strMobile;
                tui.F_USER_PERMISSION  = 10;
                tui.F_USER_CREATEDATE = DateTime.Now;
                tui.F_USER_UPDATEDATE = DateTime.Now;
                tui.F_USER_LOGIN_STATUS = 0;

                bool bolAddStatus = pui.Add_User_Info(tui);
                if(bolAddStatus)
                {
                    MessageBox.Show("注册成功");
                    this.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("注册失败，请重新尝试");
                }
                
            }
            else
            {
                MessageBox.Show(backinfo);
            }

            
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}

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
    public partial class Form2 : Form
    {
        public Guid User_ID { get; set; }
        private Guid _User_ID;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _User_ID = User_ID;
            //DragComponent a = new DragComponent();
            //a.initProperty(this);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //更新登录状态为未登录
            P_USER_LOGIN pui = new LinqDemo.P_USER_LOGIN();
            pui.Update_Login_Status(_User_ID);
            Application.Exit();
        }

        private void Form2_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            string strUserName = this.txtUserName.Text;
            P_USER_INFO pui = new P_USER_INFO();
            DataTable uidt=pui.Get_User_Info(strUserName);
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = uidt;
            XMLHelper xh = new XMLHelper();
            xh.configDGVColumn(this.dataGridView1);
            
            SetDataGridView sdgv = new SetDataGridView(this.dataGridView1);
            


        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            //SetDataGridView sdgv = new SetDataGridView(this.dataGridView1);
        }

        private void Form2_AutoSizeChanged(object sender, EventArgs e)
        {
            SetDataGridView sdgv = new SetDataGridView(this.dataGridView1);
        }
    }
}

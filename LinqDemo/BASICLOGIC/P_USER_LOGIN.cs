using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqDemo
{
    public class P_USER_LOGIN
    {

        MyDBContext db = new MyDBContext();


        /// <summary>
        /// 登陆信息校验
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public Tuple<Guid,bool,bool, bool>  Check_Login_Info(string strUserName, string strPassword)
        {
            // Tuple<用户ID，是否已经登陆，用户是否存在，用户名密码是否正确>
            bool isLoginAlready=false;
            bool idExits = false;
            bool isOKInfo = false;
            Guid backID = new Guid();
            
            var gettui= from tui in db.t_user_info
                            where tui.F_USER_NAME == strUserName
                            select tui;

            List<T_USER_INFO> ui = gettui.ToList();
            
            //username 是否存在
            if(ui.Count !=0)
            {
                idExits = true;
            }
            else
            {
                return new Tuple<Guid, bool, bool,bool>(backID, false, false, false);
            }
            
            //密码是否正确
            if(ui[0].F_USER_PASSWORD ==strPassword)
            {
                isOKInfo = true;
            }
            else
            {
                return new Tuple<Guid, bool, bool, bool>(ui[0].F_USER_ID, false, true, false);
            }
            
            //0：未登录，1：已登录
            if(ui[0].F_USER_LOGIN_STATUS!=0)
            {
                isLoginAlready = true;
                return new Tuple<Guid, bool, bool, bool>(ui[0].F_USER_ID, isLoginAlready, true, true);
            }

            //更新登陆状态为已登陆
            ui[0].F_USER_LOGIN_STATUS = 1;
            db.SaveChanges();

            var TupLogin = new Tuple<Guid, bool,bool, bool>(ui[0].F_USER_ID, isLoginAlready, idExits, isOKInfo);
            return TupLogin;

        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="UserID"></param>
        public void Update_Login_Status(Guid UserID)
        {
            try
            {
                var gettui = from tui in db.t_user_info
                             where tui.F_USER_ID == UserID
                             select tui;

                List<T_USER_INFO> ui = gettui.ToList();
                ui[0].F_USER_LOGIN_STATUS = 0;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqDemo
{
    public class CheckInputInfo
    {
        public string CheckRegistInfomation(string strUserName, string strPassword, string strConfirm, string strMobile, string strEmail)
        {
            if(strUserName=="")
            {
                return "请输入用户名";
            }
            if (strPassword == "")
            {
                return "请输入密码";
            }
            if (strConfirm == "")
            {
                return "请输入确认密码";
            }
            if (strMobile == "")
            {
                return "请输入电话";
            }
            if (strEmail == "")
            {
                return "请输入邮箱";
            }
            if (strPassword != strConfirm)
            {
                return "两次输入的密码不相同，请确认";
            }
            P_USER_INFO pui = new P_USER_INFO();
            if(pui.Check_Usr_Exist(strUserName) ==true )
            {
                return "用户已存在";
            }
            
            return "OK";
        }


        public string CheckUpdatePasswordInfo(string strUserName,string strOldPwd,string strNewPwd,string Confirm)
        {
            if(strUserName=="")
            {
                return "用户名不能为空";
            }
            if (strOldPwd == "")
            {
                return "旧密码不能为空";
            }
            if (strNewPwd == "")
            {
                return "新密码不能为空";
            }
            if(Confirm=="")
            {
                return "确认新密码不能为空";
            }
            if (Confirm != strNewPwd)
            {
                return "两次输入的新密码不相同，请确认";
            }
            P_USER_INFO pui = new P_USER_INFO();
            if (pui.Check_Usr_Exist(strUserName, strOldPwd) == false)
            {
                return "输入的用户名或旧密码错误";
            }
            return "OK";
        }


    }
}

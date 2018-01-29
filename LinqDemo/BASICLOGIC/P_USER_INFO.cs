using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class P_USER_INFO
    {
        MyDBContext db = new MyDBContext();

        public DataTable Get_User_Info(string strUserName)
        {
            DataTable dt = new DataTable();
            var gettui = from tui in db.t_user_info
                         where (string.IsNullOrEmpty(strUserName) || tui.F_USER_NAME == strUserName)
                         select tui;
            List<T_USER_INFO> ui = gettui.ToList();
            foreach (PropertyInfo propertyInfo in typeof(T_USER_INFO).GetProperties())
            {
                dt.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType); //添加列明及对应类型  
            }
            if (ui.Count > 0)
            {
                foreach (T_USER_INFO model in ui)
                {
                    DataRow dataRow = dt.NewRow();
                    foreach (PropertyInfo propertyInfo in typeof(T_USER_INFO).GetProperties())
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
                        
                    }
                    dt.Rows.Add(dataRow);
                }
            }
            
            return dt;
        }

        public bool Add_User_Info(T_USER_INFO tui)
        {
            db.t_user_info.Add(tui);
            // Submit the change to the database.
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                // Make some adjustments.
                // ...
                // Try again.
                //db.SaveChanges();
            }
            return false;
        }


        public bool Check_Usr_Exist(string strUserName)
        {
            var gettui = from tui in db.t_user_info
                         where tui.F_USER_NAME == strUserName
                         select tui;

            List<T_USER_INFO> ui = gettui.ToList();
            if (ui.Count == 0)
            {
                return false;
            }
            return true;
        }

        public bool Check_Usr_Exist(string strUserName,string strPassword)
        {
            var gettui = from tui in db.t_user_info
                         where tui.F_USER_NAME == strUserName && tui.F_USER_PASSWORD ==strPassword 
                         select tui;

            List<T_USER_INFO> ui = gettui.ToList();
            if (ui.Count == 0)
            {
                return false;
            }
            return true;
        }


        public bool Update_User_Password(string strUserName,string strPassword)
        {
            try
            {
                var gettui = from tui in db.t_user_info
                         where tui.F_USER_NAME == strUserName
                         select tui;

                List<T_USER_INFO> ui = gettui.ToList();
                if(ui.Count>0)
                {
                    T_USER_INFO updatingUi = ui[0];
                    updatingUi.F_USER_PASSWORD = strPassword;
                    updatingUi.F_USER_UPDATEDATE = DateTime.Now;
                }
            
                // Submit the changes to the database.
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                // Provide for exceptions.
            }



            
        }
    }
}

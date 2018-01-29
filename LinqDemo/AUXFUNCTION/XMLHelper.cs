using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqDemo
{
    public class XMLHelper
    {
        public void configDGVColumn(DataGridView dgv)
        {
            string str3 = AppDomain.CurrentDomain.BaseDirectory;
            string str4=str3.Replace("bin\\Debug\\", "CONFIGDOC\\DataColumnMappingList.xml");
            XDocument xml = XDocument.Load(str4);
            var book = from b in xml.Root.Elements("Table")
                       where b.Attribute("ID").Value == "T_USER_INFO"
                       select b;
            var column = from c in book.Elements("Column")
                         select c;
            var ldb = column.ToList();
            
            foreach(var exml in ldb)
            {
                var isVisible = from f in exml.Elements("IsVisible")
                                select f;
                var ivdb = isVisible.SingleOrDefault();
                string iv = ivdb.ToString();
                iv = iv.Split('>')[1];
                iv = iv.Split('<')[0];

                var columnHeader = from d in exml.Elements("ColumnHeader")
                                   select d;
                var chdb = columnHeader.SingleOrDefault();
                string ch = chdb.ToString();
                ch = ch.Split('>')[1];
                ch = ch.Split('<')[0];

                if (iv == "0")
                {
                    var displayValue = from e in exml.Elements("DisplayValue")
                                       select e;
                    var dvdb = displayValue.SingleOrDefault();
                    string dv = dvdb.ToString();
                    dv = dv.Split('>')[1];
                    dv = dv.Split('<')[0];

                    dgv.Columns[ch].HeaderText = dv;
                }
                else
                {
                    dgv.Columns[ch].Visible = false;
                }
                
            }
            
        }
        
    }
}

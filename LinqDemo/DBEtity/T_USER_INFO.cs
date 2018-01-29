using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public partial class T_USER_INFO
    {
        [Key]
        public Guid F_USER_ID { get; set; }
        public string F_USER_NAME { get; set; }
        public string F_USER_PASSWORD { get; set; }
        public string F_USER_EMAIL { get; set; }
        public string F_USER_MOBILE { get; set; }
        public int F_USER_PERMISSION { get; set; }
        public DateTime F_USER_CREATEDATE{ get; set; }
        public DateTime F_USER_UPDATEDATE { get; set; }
        public int F_USER_LOGIN_STATUS { get; set; }
    }
}

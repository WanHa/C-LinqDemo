using LinqDemo;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class MyDBContext:DbContext
    {
        public MyDBContext()
            : base("name=LinqDemo")
        { }
        public IDbSet<T_USER_INFO> t_user_info { get; set; }


    }

    
}

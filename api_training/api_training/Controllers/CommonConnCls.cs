using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace api_training.Controllers
{
    public class CommonConnCls
    {
        public static string connection()
        {
            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();
            return conn;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Security;

namespace WebApplication1
{
    public class Ketnoi
    {
        public SqlConnection con = new SqlConnection("Data source=.; Initial Catalog=DEMO; Integrated Security=True");

        [Obsolete]
        public string Mahoa(string str) 
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "SHA1");
        }
    }
}
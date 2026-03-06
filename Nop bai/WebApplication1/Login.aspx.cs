using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Web.Caching;
using System.Security;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["user"] != null;
                Response.Redirect("Default.aspx");
            }
        }
        [Obsolete]
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = kn.Mahoa(txtPassword.Text);
            string sql = "select * from tblUser where Username='" + username + "' and Password='" + password + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["user"] = username;
                Session["allow"] = true;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('Username / Password sai')</script>");
            }
        }
    }
}

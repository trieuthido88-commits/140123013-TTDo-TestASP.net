using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                Response.Redirect("default.aspx"); 
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = kn.Mahoa(txtPassword.Text);
            string sql = " select * from [User] where Username='" + username + "' and Password= '" + password + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["user"] = username;
                Response.Redirect("default.aspx");
            }


            else
            {
                Response.Write("<script>alert('Username / Password sai');</script>");
            }
        }
    }
}
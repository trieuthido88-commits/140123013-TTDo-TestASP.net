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
    public partial class Signup : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
                Response.Redirect("default.aspx");
            if (!IsPostBack)
            {

            }
        }
        [Obsolete]
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //lay du lieu tren form
            string username = txtUsername.Text;
            string password = kn.Mahoa(txtPassword.Text);
            string fullname = txtFullname.Text;

            // neu User ton tai
            string checkus = "select * from [User] where Username='" + username + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con );
            DataTable dt = new DataTable();
            da.Fill( dt );
            if (dt.Rows.Count > 0)
            
                Response.Write("<script>alert('Username đã tồn tại');</script>");
            
            else
            {
                if (FileUpload.HasFile && checkfile(FileUpload.FileName))
                {
                    string filename = "Avatar/" + FileUpload.FileName;
                    string filepath = MapPath(filename);
                    FileUpload.SaveAs(filepath);
                    string sql = "insert into [User] (Username, Password, Fullname, Avatar) values ('" + username + "','" + password + "',N'" + fullname + "','"+ filename +"')";
                    SqlCommand cmd = new SqlCommand(sql, kn.con);
                    kn.con.Open();
                    cmd.ExecuteNonQuery();
                    kn.con.Close();
                    Response.Redirect("Login.aspx");
                }

                else
                {
                    string sql = "insert into [User] (Username, Password, Fullname, Avatar) values ('" + username + "','" + password + "',N'" + fullname + "','')";
                    SqlCommand cmd = new SqlCommand(sql, kn.con);
                    kn.con.Open();
                    cmd.ExecuteNonQuery();
                    kn.con.Close();
                    Response.Redirect("Login.aspx");
                }
            }
        }
        bool checkfile(string filename)
        {
            string ext = Path.GetExtension(filename);
            switch (ext)
            {
                case ".jpg":
                    return true;
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".bmp":
                    return true;
                case ".jpeg":
                    return true;
                default: return false;

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class QLhocvien : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                hienthi();

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string mahv = txtmahv.Text;
            string ho = txtHohv.Text;
            string ten = txtTenhv.Text;
            string diachi = txtDiachi.Text;

            string checkus = "select * from [HocVien] where MaHV='" + mahv + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)

                Response.Write("<script>alert('MaHV đã tồn tại');</script>");

            else
            {
                string sql = "insert into HocVien (MaHV,HoHV,TenHV,DiaChi) values ('" + mahv + "',N'" + ho + "',N'" + ten + "',N'" + diachi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
            }

        }
        void hienthi()
        {
            string sql = "select MaHV,HoHV,TenHV, DiaChi from HocVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlhv.DataSource = ds;
            qlhv.DataBind();
        }
    }
    
}
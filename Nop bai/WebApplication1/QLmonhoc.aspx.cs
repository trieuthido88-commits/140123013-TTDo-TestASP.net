using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class QLmonhoc : System.Web.UI.Page
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
            string mamh = txtmamh.Text;
            string tenmh = txttenmh.Text;
            string sotiet = txtsotiet.Text;
            string hocphi = txthocphi.Text;

            string checkus = "select * from [MonHoc] where MaMH='" + mamh + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)

                Response.Write("<script>alert('MaMH đã tồn tại');</script>");

            else
            {
                string sql = "insert into MonHoc (MaMH,TenMH,SoTiet,HocPhi) values ('" + mamh + "',N'" + tenmh + "','" + sotiet + "','" + hocphi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
            }
        }
        void hienthi()
        {
            string sql = "select * from MonHoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlmh.DataSource = ds;
            qlmh.DataBind();
        }
    }
}
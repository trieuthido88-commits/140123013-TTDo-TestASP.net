using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
            btnsua.Enabled = false;
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

        protected void qlmh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmamh.Text = qlmh.SelectedRow.Cells[2].Text;
            txttenmh.Text = HttpUtility.HtmlDecode(qlmh.SelectedRow.Cells[3].Text);
            txtsotiet.Text = HttpUtility.HtmlDecode(qlmh.SelectedRow.Cells[4].Text);
            txthocphi.Text = HttpUtility.HtmlDecode(qlmh.SelectedRow.Cells[5].Text);
            txtmamh.Enabled = false;
            btnThemMH.Enabled = false;
            btnSuaMH.Enabled = true;
        }

        protected void qlmh_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string mamh = qlmh.DataKeys[e.RowIndex].Values["MaMH"].ToString();
            string sql = "delete from MonHoc where MaMH='" + mamh + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);

            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();

            hienthi();
        }

        protected void btnSuaMH_Click(object sender, EventArgs e)
        {
            string mamh = txtmamh.Text;
            string tenmh = txttenmh.Text;
            string sotiet = txtsotiet.Text;
            string hocphi = txthocphi.Text;
            string sql = "update MonHoc set TenMH=N'" + tenmh + "',SoTiet=N'" + sotiet + "',HocPhi=N'" + hocphi + "' where MaMH='" + mamh + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();

            btnThemMH.Enabled = true;
            txtmamh.Enabled = true;
            txtmamh.Text = "";
            txttenmh.Text = "";
            txtsotiet.Text = "";
            txthocphi.Text = "";

        }


        void timkiem(string keywords)
        {
            string sql = "select MaMH,TenMH,SoTiet,HocPhi from MonHocn where TenMH like '%" + keywords + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlmh.DataSource = ds;
            qlmh.DataBind();
        }

        protected void bttim_Click(object sender, EventArgs e)
        {
            string tenmh = txttim.Text;
            timkiem(tenmh);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Microsoft.SqlServer.Server;

namespace WebApplication1.Admin
{

    public partial class PhancongGV : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (Session["user"] == null)
            // {
            //    Response.Redirect("Login.aspx");
            // }
            if (!IsPostBack)
            {
                hienthi();
                loadGV();
                loadMH();

            }
            btnsua.Enabled = false;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string magv = ddlGV.SelectedValue;
            string mamh = ddlMH.SelectedValue;
            string ghichu = txtghichu.Text;

            string username = "";
            if (Session["user"] != null)
            {
                username = Session["user"].ToString();
            }// load từ đăng nhập


            string checkus = "select * from PhanCong where MaGV='" + magv +
                 "' and MaMH='" + mamh +
                 "' and Username='" + username + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //if (dt.Rows.Count > 0)

            // Response.Write("<script>alert('MaGV đã tồn tại');</script>");

            //else
            //{
            string sql = "insert into PhanCong (MaGV,MaMH,Ghichu,Username) values ('" + magv + "','" + mamh + "',N'" + ghichu + "','" + username + "')";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();
            //}

        }
        void hienthi()
        {
            if (Session["user"] != null)
            {
                txtusername.Text = Session["user"].ToString();
            }
            string sql = "select * from PhanCong";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlpcgv.DataSource = ds;
            qlpcgv.DataBind();

        }

        protected void qlpcgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGV.Text = qlpcgv.SelectedRow.Cells[2].Text;
            ddlMH.Text = HttpUtility.HtmlDecode(qlpcgv.SelectedRow.Cells[3].Text);
            txtghichu.Text = HttpUtility.HtmlDecode(qlpcgv.SelectedRow.Cells[4].Text);
            txtusername.Text = HttpUtility.HtmlDecode(qlpcgv.SelectedRow.Cells[5].Text);
            //đ.Enabled = false;
            btnThem.Enabled = false;
            btnsua.Enabled = true;
        }
        protected void qlpcgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string magv = qlpcgv.DataKeys[e.RowIndex].Values["MaGV"].ToString();
            string mamh = qlpcgv.DataKeys[e.RowIndex].Values["MaMH"].ToString();
            string username = qlpcgv.DataKeys[e.RowIndex].Values["Username"].ToString();

            string sql = "delete from PhanCong where MaGV='" + magv + "' and MaMH='" + mamh + "' and Username='" + username + "' ";
            SqlCommand cmd = new SqlCommand(sql, kn.con);

            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();

            hienthi();
        }

        protected void Btnsua_Click(object sender, EventArgs e)
        {
            string magv = ddlGV.Text;
            string mamh = ddlMH.Text;
            string ghichu = txtghichu.Text;
            string username = txtusername.Text;
            string sql = "update PhanCong set Ghichu=N'" + ghichu + "' where MaGV='" + magv + "' and MaMH='" + mamh + "' and Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();

            btnThem.Enabled = true;
            //txtmagv.Enabled = true;
            //txtmagv.Text = "";
            //txtmamh.Text = "";
            txtghichu.Text = "";
            txtusername.Text = "";

        }
        void timkiem(string keywords)
        {
            string sql = "SELECT pc.MaGV, gv.TenGV, pc.MaMH, mh.TenMH, pc.GhiChu, pc.Username " +
                 "FROM PhanCong pc " +
                 "LEFT JOIN GiaoVien gv ON pc.MaGV = gv.MaGV " +
                 "LEFT JOIN MonHoc mh ON pc.MaMH = mh.MaMH " +
                 "WHERE pc.MaGV LIKE '%" + keywords + "%'";

            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlpcgv.DataSource = ds;
            qlpcgv.DataBind();
        }


        protected void btntim_Click(object sender, EventArgs e)
        {
            string magv = txttim.Text;
            timkiem(magv);
        }

        void loadGV()
        {
            string sql = "select MaGV from GiaoVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlGV.DataSource = dt;
            ddlGV.DataTextField = "MaGV";   // hiển thị tên
            ddlGV.DataValueField = "MaGV";   // giá trị là mã
            ddlGV.DataBind();
        }

        void loadMH()
        {
            string sql = "select MaMH from MonHoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlMH.DataSource = dt;
            ddlMH.DataTextField = "MaMH";   // hiển thị tên
            ddlMH.DataValueField = "MaMH";   // giá trị là mã
            ddlMH.DataBind();
        }
    }
}
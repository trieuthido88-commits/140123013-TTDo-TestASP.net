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


namespace WebApplication1
{
    public partial class QLgiaovien : System.Web.UI.Page
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
            string magv = txtmagv.Text;
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string diachi = txtDiachi.Text;

            string checkus = "select * from [GiaoVien] where MaGV='" + magv + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)

                Response.Write("<script>alert('MaGV đã tồn tại');</script>");

            else
            {
                string sql = "insert into GiaoVien (MaGV,HoGV,TenGV,DiaChi) values ('" + magv + "',N'" + ho + "',N'" + ten + "',N'" + diachi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
            }

        }
        void hienthi()
        {
            string sql = "select MaGV,HoGV,TenGV, DiaChi from GiaoVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlgv.DataSource = ds;
            qlgv.DataBind();
        }

        protected void qlgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmagv.Text = qlgv.SelectedRow.Cells[2].Text;
            txtHo.Text = HttpUtility.HtmlDecode(qlgv.SelectedRow.Cells[3].Text);
            txtTen.Text = HttpUtility.HtmlDecode(qlgv.SelectedRow.Cells[4].Text);
            txtDiachi.Text = HttpUtility.HtmlDecode(qlgv.SelectedRow.Cells[5].Text);
            txtmagv.Enabled = false;
            btnThem.Enabled = false;
            btnsua.Enabled = true;
        }

        protected void qlgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string magv = qlgv.DataKeys[e.RowIndex].Values["MaGV"].ToString();
            string sql = "delete from GiaoVien where MaGV='" + magv + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);

            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();

            hienthi();
        }

        protected void Btnsua_Click(object sender, EventArgs e)
        {
            string magv = txtmagv.Text;
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string diachi = txtDiachi.Text;
            string sql = "update GiaoVien set HoGV=N'" + ho + "',TenGV=N'" + ten + "',DiaChi=N'" + diachi + "' where MaGV='" + magv + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();

            btnThem.Enabled = true;
            txtmagv.Enabled = true;
            txtmagv.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtDiachi.Text = "";

        }

        void timkiem(string keywords)
        {
            string sql = "select MaGV,HoGV,TenGV,Diachi from GiaoVien where TenGV like '%" + keywords + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlgv.DataSource = ds;
            qlgv.DataBind();
        }

        protected void bttim_Click(object sender, EventArgs e)
        {
            string tengv = txttim.Text;
            timkiem(tengv);
        }
    }
}
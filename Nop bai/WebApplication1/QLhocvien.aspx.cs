using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class QLHocvien : System.Web.UI.Page
    {
        // Khởi tạo đối tượng kết nối từ class Ketnoi
        Ketnoi kn = new Ketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                hienthi();
                btnsua.Enabled = false;

                // Kiểm tra nếu có mã học viên truyền qua QueryString để thực hiện Sửa/Xóa
                if (!string.IsNullOrEmpty(Request.QueryString["mahv"]))
                {
                    string mahv = Request.QueryString["mahv"];
                    string sql = "select * from [HocVien] where MaHV='" + mahv + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtmahv.Text = dt.Rows[0][0].ToString();
                        txtHohv.Text = dt.Rows[0][1].ToString();
                        txtTenhv.Text = dt.Rows[0][2].ToString();
                        txtDiachi.Text = dt.Rows[0][6].ToString();
                    }

                    txtmahv.Enabled = false;
                    btnThem.Enabled = false;
                    btnsua.Enabled = true;
                }

                // Xử lý xóa học viên nếu có tham số mahvx (mã học viên xóa)
                if (!string.IsNullOrEmpty(Request.QueryString["mahvx"]))
                {
                    string mahv = Request.QueryString["mahvx"];
                    string sql = "delete from [HocVien] where MaHV='" + mahv + "'";
                    SqlCommand cmd = new SqlCommand(sql, kn.con);
                    kn.con.Open();
                    cmd.ExecuteNonQuery();
                    kn.con.Close();
                    hienthi();
                    Response.Redirect("QLHocvien.aspx");
                }
            }
        }

        // Hàm hiển thị dữ liệu lên Repeater
        void hienthi()
        {
            string sql = "select MaHV, HoHV, TenHV, Diachi from HocVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rpHV.DataSource = dt;
            rpHV.DataBind();
        }

        // Sự kiện Click nút Thêm
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string mahv = txtmahv.Text;
            string ho = txtHohv.Text;
            string ten = txtTenhv.Text;
            string diachi = txtDiachi.Text;

            // Kiểm tra mã học viên đã tồn tại chưa
            string checkus = "select * from [HocVien] where MaHV='" + mahv + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã học viên đã tồn tại');</script>");
            }
            else
            {
                string sql = "insert into HocVien(MaHV, HoHV, TenHV, Diachi) values('" + mahv + "', N'" + ho + "', N'" + ten + "', N'" + diachi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
                Response.Redirect("QLHocvien.aspx");
            }
        }

        // Sự kiện Click nút Sửa
        protected void btnsua_Click(object sender, EventArgs e)
        {
            string mahv = txtmahv.Text;
            string ho = txtHohv.Text;
            string ten = txtTenhv.Text;
            string diachi = txtDiachi.Text;

            string sql = "update [HocVien] set HoHV=N'" + ho + "', TenHV=N'" + ten + "', Diachi=N'" + diachi + "' where MaHV='" + mahv + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();
            Response.Redirect("QLHocvien.aspx");
        }
    }
}
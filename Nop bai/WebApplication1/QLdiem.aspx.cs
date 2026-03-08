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
    public partial class QLdiem : System.Web.UI.Page
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
                if (!string.IsNullOrEmpty(Request.QueryString["mahvs"]))
                {
                    string mahv = Request.QueryString["mahvs"];
                    string sql = "select * from [KetQua] where MaHV='" + mahv + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtmahv.Text = dt.Rows[0][0].ToString();
                        //txtHohv.Text = dt.Rows[0][1].ToString();
                        //txtTenhv.Text = dt.Rows[0][2].ToString();
                        txtMamh.Text = dt.Rows[0][6].ToString();
                        txtDiem.Text = dt.Rows[0][7].ToString();
                        txtUsername.Text = dt.Rows[0][8].ToString();
                    }

                    txtmahv.Enabled = false;
                    btnThem.Enabled = false;
                    btnsua.Enabled = true;
                }

                // Xử lý xóa học viên nếu có tham số mahvx (mã học viên xóa)
                if (!string.IsNullOrEmpty(Request.QueryString["mahvx"]))
                {
                    string mahv = Request.QueryString["mahvx"];
                    string sql = "delete from [KetQua] where MaHV='" + mahv + "'";
                    SqlCommand cmd = new SqlCommand(sql, kn.con);
                    kn.con.Open();
                    cmd.ExecuteNonQuery();
                    kn.con.Close();
                    hienthi();
                    Response.Redirect("QLdiem.aspx");
                }
            }
        }

        // Hàm hiển thị dữ liệu lên Repeater
        void hienthi()
        {
            string sql = "select MaHV, MaMH, Diem, Username from KetQua";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rpKQ.DataSource = dt;
            rpKQ.DataBind();
        }

        // Sự kiện Click nút Thêm
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string mahv = txtmahv.Text;
            //string ho = txtHohv.Text;
            //string ten = txtTenhv.Text;
            string mamh = txtMamh.Text;
            string diem = txtDiem.Text;
            string user = txtUsername.Text;

            // Kiểm tra mã học viên đã tồn tại chưa
            string checkus = "select * from [KetQua] where MaHV='" + mahv + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã học viên đã tồn tại');</script>");
            }
            else
            {
                string sql = "insert into KetQua(MaHV, MaMH, Diem, Username) values('" + mahv + "', N'" + mamh + "', N'" + diem + "', N'" + user + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
                Response.Redirect("QLdiem.aspx");
            }
        }

        // Sự kiện Click nút Sửa
        protected void btnsua_Click(object sender, EventArgs e)
        {
            string mahv = txtmahv.Text;
            //string ho = txtHohv.Text;
            //string ten = txtTenhv.Text;
            string mamh = txtMamh.Text;
            string diem = txtDiem.Text;
            string user = txtUsername.Text;

            string sql = "update [KetQua] set Diem=N'" + diem + "' where MaHV='" + mahv + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();
            Response.Redirect("QLdiem.aspx");
        }
    }
}
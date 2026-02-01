using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using WebApplication2;
using System.EnterpriseServices;



namespace WebApplication2
{
        public partial class Signup : System.Web.UI.Page
        {
            // Khởi tạo đối tượng kết nối (Giả sử lớp kết nối của bạn tên là Ketnoi)
            Ketnoi kn = new Ketnoi();

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    // Các xử lý khi trang load lần đầu
                }
            }

            [Obsolete]
            protected void btnLogin_Click(object sender, EventArgs e)
            {
                // Lấy dữ liệu từ form
                string username =txtusername.Text;
                string password = kn.Mahoa(txtPassword.Text); // Có sử dụng hàm mã hóa của lớp Ketnoi
                string fullname = txtfullname.Text;

                // Trước khi thêm, cần phải kiểm tra xem username có tồn tại hay không
                // Nếu username đã tồn tại thì không cho lưu vào
                string checkus = "select * from tblUser where Username='" + username + "'";
                SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0) // Username đã tồn tại
                {
                    Response.Write("<script>alert('Username đã tồn tại');</script>");
                }
                else
                {
                    // Kiểm tra xem có upload avatar hay không 
                    if (FileUpload1.HasFile && checkfile(FileUpload1.FileName))
                    {
                        string filename = "Avatar/" + FileUpload1.FileName;
                        string filepath = MapPath(filename);
                        FileUpload1.SaveAs(filepath);
                        string sql = "insert into tblUser(Username, Password, Fullname, Avatar) values('" + username + "','" + password + "',N'" + fullname + "','" + filename + "')";
                        SqlCommand cmd = new SqlCommand(sql, kn.con);
                        kn.con.Open();
                        cmd.ExecuteNonQuery();
                        kn.con.Close();
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        string sql = "insert into tblUser(Username, Password, Fullname) values('" + username + "','" + password + "',N'" + fullname + "')";
                        SqlCommand cmd = new SqlCommand(sql, kn.con);
                        kn.con.Open(); // Mở kết nối
                        cmd.ExecuteNonQuery();
                        kn.con.Close();
                        Response.Redirect("Login.aspx");
                    }
                }
            }

            // Hàm kiểm tra định dạng file ảnh
            bool checkfile(string filename)
            {
                string ext = Path.GetExtension(filename).ToLower();
                switch (ext)
                {
                    case ".jpg":
                        return true;
                    case ".gif":
                        return true;
                    case ".png":
                        return true;
                    case ".jpeg":
                        return true;
                    default:
                        return false;
                }
            }
        }
}



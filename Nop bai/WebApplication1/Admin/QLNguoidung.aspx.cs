using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class QLNguoidung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    if (Session["role"].ToString() != "1")
                    {
                        Response.Redirect("../Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../default.aspx");
                }
            }
        }
    }
}
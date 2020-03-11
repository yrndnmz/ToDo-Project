using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullaniciid"] != null)
            {
                Response.Redirect("todo.aspx");
            }
        }
        protected void Girisbutonu_Click(object sender, EventArgs e)
        {
            bool isAdmin = false;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from register where username=@UNAME and password=@UPASS", con);
            cmd.Parameters.AddWithValue("UNAME", Kullaniciadi.Text);
            cmd.Parameters.AddWithValue("UPASS", Sifre.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Hatalı giriş yaptınız lütfen tekrar deneyin...');" + "</script>");
            }
            else
            {
                Session["kullaniciid"] = dr["id"];
                Session["kullaniciadi"] = dr["name"] + " " + dr["surname"];
                Session["username"] = dr["username"];
                isAdmin = Convert.ToBoolean(dr["isadmin"]);
                con.Close();
                if (isAdmin)
                {
                    Response.Redirect("yoneticitodo.aspx");
                }
                else
                {
                    Response.Redirect("todo.aspx");
                }
            }
        }
    }
}

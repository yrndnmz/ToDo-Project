using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace WebApplication4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullaniciid"] == null)
            {
                Response.Redirect("giris.aspx");
            }
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True"))
                {
                    SqlCommand cmd = new SqlCommand("Select id,name,surname, name + ' ' + surname AS fullname from register where isAdmin=0", con);
                    con.Open();
                    DropDownList1.DataSource = cmd.ExecuteReader();
                    DropDownList1.DataTextField = "fullname";
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataBind();
                    con.Close();
                }
                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("Select  name + ' ' + surname AS fullname from register where id=@REGISTERID", con2);
                cmd2.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
                cmd2.ExecuteNonQuery();
                SqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                ToDo.Text = dr["fullname"].ToString();
                dr.Close();
                con2.Close();
            }
        }
        protected void ToDo_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            Response.Redirect("yoneticitodo.aspx");
            con.Close();
        }
        protected void Calisan_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            Response.Redirect("calisanarama.aspx");
            con.Close();
        }
        protected void Kayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            Response.Redirect("kayitekrani.aspx");
            con.Close();
        }
        protected void Cikis_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("giris.aspx");
        }
        protected void Bul_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            if (DropDownList1.SelectedItem.Text == "-Çalışan Seçiniz-")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Bir Çalışan Seçiniz...');" + "</script>");
            }
            else
            {
                Session["adsoyad"] = DropDownList1.SelectedItem.Text;
                Session["calisanid"] = DropDownList1.SelectedValue;
                Response.Redirect("calisantodo.aspx");
                con.Close();
            }
        }

    }
}
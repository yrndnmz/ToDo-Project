using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class güncelleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullaniciid"] == null)
            {
                Response.Redirect("giris.aspx");
            }
            if (!IsPostBack)
            {
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
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select name,surname,username from register where id=@ID ", con);
            cmd.Parameters.AddWithValue("ID", Session["kullaniciid"]);
            SqlDataReader dr2 = cmd.ExecuteReader();
            dr2.Read();
            GuncelAdi.Text = dr2["name"].ToString();
            GuncelSoyadi.Text = dr2["surname"].ToString();
            GuncelKullaniciAdi.Text = dr2["username"].ToString();
            dr2.Close();
            con.Close();
        }
        protected void Cikis_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("giris.aspx");
        }
        protected void BilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            if (GuncelAdi.Text == null || GuncelAdi.Text == "" && GuncelSoyadi.Text == null || GuncelSoyadi.Text == "" && GuncelKullaniciAdi.Text == null || GuncelKullaniciAdi.Text == "" && GuncelSifre.Text == null || GuncelSifre.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Güncelleme Formunda Hiçbir Alan Boş Geçilemez...');" + "</script>");
            }
            else
            {
                bool user = true;
                SqlCommand cmd3 = new SqlCommand("Select id from register where username=@USERNAME", con);
                cmd3.Parameters.AddWithValue("USERNAME", GuncelKullaniciAdi.Text);
                user = Convert.ToBoolean(cmd3.ExecuteScalar());
                if (user)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Bu Kullanıcı Adı Zaten Kullanılmaktadır...');</script>");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update register set name='" + GuncelAdi.Text + "',surname='" + GuncelSoyadi.Text + "',username='" + GuncelKullaniciAdi.Text + "',password='" + GuncelSifre.Text + "'where id=@ID", con);
                    cmd.Parameters.AddWithValue("ID", Session["kullaniciid"]);
                    cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kayıt Güncellendi...');" + "</script>");
                    GuncelAdi.Text = null;
                    GuncelSoyadi.Text = null;
                    GuncelKullaniciAdi.Text = null;
                    GuncelSifre.Text = null;
                    SqlCommand cmd2 = new SqlCommand("Select  name + ' ' + surname AS fullname from register where id=@REGISTERID", con);
                    cmd2.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
                    cmd2.ExecuteNonQuery();
                    SqlDataReader dr = cmd2.ExecuteReader();
                    dr.Read();
                    ToDo.Text = dr["fullname"].ToString();
                    dr.Close();
                    con.Close();
                }
            }
        }
        protected void Guncelleme_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            Response.Redirect("guncelleme.aspx");
            con.Close();
        }
        protected void ToDo_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            Response.Redirect("todo.aspx");
            con.Close();
        }
    }
}
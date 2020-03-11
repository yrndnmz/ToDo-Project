using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class kayitekrani : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullaniciid"] == null)
            {
                Response.Redirect("giris.aspx");
            }
            if (!IsPostBack)
            {
                DropDown();
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select  name + ' ' + surname AS fullname from register where id=@REGISTERID", con);
                cmd.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                ToDo.Text = dr["fullname"].ToString();
                dr.Close();
                con.Close();
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
        protected void Kayitbutonu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            if ((adi.Text == null || adi.Text == "") || (soyadi.Text == null || soyadi.Text == "") || (kullaniciadi.Text == null || kullaniciadi.Text == "") || (sifre.Text == null || sifre.Text == ""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kayıt Formunda Hiçbir Alan Boş Geçilemez...');</script>");
            }
            else
            {
                bool user = true;
                SqlCommand cmd2 = new SqlCommand("Select id from register where username=@USERNAME", con);
                cmd2.Parameters.AddWithValue("USERNAME", kullaniciadi.Text);
                user = Convert.ToBoolean(cmd2.ExecuteScalar());
                if (user)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Bu Kullanıcı Adı Zaten Kullanılmaktadır...');</script>");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into register(isadmin,name,surname,username,password) values (0, '" + adi.Text + "','" + soyadi.Text + "','" + kullaniciadi.Text + "','" + sifre.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kayıt Alındı...');</script>");
                    adi.Text = null;
                    soyadi.Text = null;
                    kullaniciadi.Text = null;
                    sifre.Text = null;
                    DropDown();
                    con.Close();
                }
               
            }
        }
        protected void BilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            if ((GuncelAdi.Text == null || GuncelAdi.Text == "") || (GuncelSoyadi.Text == null || GuncelSoyadi.Text == "") || (GuncelKullaniciAdi.Text == null || GuncelKullaniciAdi.Text == "") || (GuncelSifre.Text == null || GuncelSifre.Text == ""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Güncelleme Formunda Hiçbir Alan Boş Geçilemez...');</script>");
            }
            else
            {
                bool user = true;
                SqlCommand cmd2 = new SqlCommand("Select id from register where username=@USERNAME", con);
                cmd2.Parameters.AddWithValue("USERNAME", GuncelKullaniciAdi.Text);
                user = Convert.ToBoolean(cmd2.ExecuteScalar());
                if (user)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Bu Kullanıcı Adı Zaten Kullanılmaktadır...');</script>");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update register set name ='" + GuncelAdi.Text + "' , surname ='" + GuncelSoyadi.Text + "' , username = '" + GuncelKullaniciAdi.Text + "' , password = '" + GuncelSifre.Text + "' where id=@ID ", con);
                    cmd.Parameters.AddWithValue("ID", DropDownList1.SelectedValue);
                    cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kayıt Güncellendi...');</script>");
                    GuncelAdi.Text = null;
                    GuncelSoyadi.Text = null;
                    GuncelKullaniciAdi.Text = null;
                    GuncelSifre.Text = null;
                    DropDown();
                    con.Close();
                }
            }
        }
        protected void Sil_Click(object sender, EventArgs e)
        {
            bool isAdmin = false;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select isAdmin from register where id=@ID ", con);
            cmd2.Parameters.AddWithValue("ID", DropDownList1.SelectedValue);
            isAdmin = Convert.ToBoolean(cmd2.ExecuteScalar());
            if (isAdmin)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Yönetici Kaydı Silinemez...');</script>");
            }
            else
            {
                if (DropDownList1.SelectedItem.Text == "-Çalışan Listesi-")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Çalışan Seçiniz...');</script>");
                }
                else
                {
                   
                    SqlCommand cmd5 = new SqlCommand("Delete from action where (statusid=1 or statusid=2 or statusid=3) AND registerid=@ID", con);                    
                    cmd5.Parameters.AddWithValue("ID", DropDownList1.SelectedValue);                 
                    cmd5.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand("Delete from action where id=@ID", con);
                    cmd3.Parameters.AddWithValue("ID", DropDownList1.SelectedValue);
                    cmd3.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("Delete from register where id=@ID and isAdmin=0", con);
                    cmd.Parameters.AddWithValue("ID", DropDownList1.SelectedValue);
                    cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kayıt Silindi...');</script>");
                    GuncelAdi.Text = null;
                    GuncelSoyadi.Text = null;
                    GuncelKullaniciAdi.Text = null;
                    GuncelSifre.Text = null;
                    DropDown();
                    con.Close();
                }
            }
        }
        protected void Bul_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select name,surname,username from register where id=@ID ", con);
            cmd.Parameters.AddWithValue("ID", DropDownList1.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            GuncelAdi.Text = dr["name"].ToString();
            GuncelSoyadi.Text = dr["surname"].ToString();
            GuncelKullaniciAdi.Text = dr["username"].ToString();
            dr.Close();
            con.Close();
        }

        private void DropDown()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Select id,name,surname, name + ' ' + surname AS fullname from register", con);
                con.Open();
                DropDownList1.Items.Clear();
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "fullname";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                con.Close();
            }
        }
    }
}

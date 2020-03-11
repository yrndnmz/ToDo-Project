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
    public partial class WebForm5 : System.Web.UI.Page
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
                    SqlCommand cmd = new SqlCommand("Select * from status", con);
                    con.Open();
                    DropDownList2.DataSource = cmd.ExecuteReader();
                    DropDownList2.DataTextField = "type";
                    DropDownList2.DataValueField = "id";
                    DropDownList2.DataBind();
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

                FillRepeater(Repeater1, 1);


                FillRepeater(Repeater2, 2);


                FillRepeater(Repeater3, 3);

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
        protected void Arti_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            if (TextBox1.Text == null || TextBox1.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Yeni Görev Kutucuğu Boş Geçilemez...');" + "</script>");
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("Select ISNULL(MAX(sort),0)as sort from action where statusid=" + DropDownList2.SelectedValue + "", con);
                SqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                Session["order"] = dr["sort"];
                int sort = Convert.ToInt32(Session["order"].ToString());
                sort++;
                Session["order"] = sort;
                dr.Close();
                SqlCommand cmd = new SqlCommand("Insert into action (statusid,registerid,description,sort) values (" + DropDownList2.SelectedValue + ",'" + Session["kullaniciid"] + "','" + TextBox1.Text + "'," + Session["order"] + ") ", con);
                cmd.ExecuteNonQuery();
                TextBox1.Text = null;
                con.Close();
                switch (DropDownList2.SelectedValue)
                {
                    case "1":
                        {
                            FillRepeater(Repeater1, 1);
                            break;
                        }
                    case "2":
                        {
                            FillRepeater(Repeater2, 2);
                            break;
                        }
                    case "3":
                        {
                            FillRepeater(Repeater3, 3);
                            break;
                        }
                }
            }
        }

        protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Next":
                    {
                        ChangeStatus(Convert.ToInt32(e.CommandArgument.ToString()), 1, 2);
                        FillRepeater(Repeater1, 1);
                        FillRepeater(Repeater2, 2);
                        break;
                    }
                case "Up":
                    {
                        ChangeOrder(Convert.ToInt32(e.CommandArgument.ToString()), 1);
                        FillRepeater(Repeater1, 1);
                        break;
                    }
                case "Down":
                    {
                        ChangeOrder2(Convert.ToInt32(e.CommandArgument.ToString()), 1);
                        FillRepeater(Repeater1, 1);
                        break;
                    }
                case "Delete":
                    {
                        Delete(Convert.ToInt32(e.CommandArgument.ToString()), 1);
                        FillRepeater(Repeater1, 1);
                        break;
                    }
                case "Update":
                    {
                        TextBox txt = e.Item.FindControl("TextBox2") as TextBox;
                        ChangeDescription(Convert.ToInt32(e.CommandArgument.ToString()), txt.Text);
                        break;
                    }

            }
        }
        protected void Repeater2_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Next":
                    {
                        ChangeStatus(Convert.ToInt32(e.CommandArgument.ToString()), 2, 3);
                        FillRepeater(Repeater2, 2);
                        FillRepeater(Repeater3, 3);
                        break;
                    }
                case "Back":
                    {
                        ChangeStatus(Convert.ToInt32(e.CommandArgument.ToString()), 2, 1);
                        FillRepeater(Repeater2, 2);
                        FillRepeater(Repeater1, 1);
                        break;
                    }
                case "Up":
                    {
                        ChangeOrder(Convert.ToInt32(e.CommandArgument.ToString()), 2);
                        FillRepeater(Repeater2, 2);
                        break;
                    }
                case "Down":
                    {
                        ChangeOrder2(Convert.ToInt32(e.CommandArgument.ToString()), 2);
                        FillRepeater(Repeater2, 2);
                        break;
                    }
                case "Delete":
                    {
                        Delete(Convert.ToInt32(e.CommandArgument.ToString()), 2);
                        FillRepeater(Repeater2, 2);
                        break;
                    }
                case "Update":
                    {
                        TextBox txt = e.Item.FindControl("TextBox3") as TextBox;
                        ChangeDescription(Convert.ToInt32(e.CommandArgument.ToString()), txt.Text);
                        break;
                    }
            }
        }
        protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Back":
                    {
                        ChangeStatus(Convert.ToInt32(e.CommandArgument.ToString()), 3, 2);
                        FillRepeater(Repeater2, 2);
                        FillRepeater(Repeater3, 3);
                        break;
                    }
                case "Up":
                    {
                        ChangeOrder(Convert.ToInt32(e.CommandArgument.ToString()), 3);
                        FillRepeater(Repeater3, 3);
                        break;
                    }
                case "Down":
                    {
                        ChangeOrder2(Convert.ToInt32(e.CommandArgument.ToString()), 3);
                        FillRepeater(Repeater3, 3);
                        break;
                    }
                case "Delete":
                    {
                        Delete(Convert.ToInt32(e.CommandArgument.ToString()), 3);
                        FillRepeater(Repeater3, 3);
                        break;
                    }
                case "Update":
                    {
                        TextBox txt = e.Item.FindControl("TextBox4") as TextBox;
                        ChangeDescription(Convert.ToInt32(e.CommandArgument.ToString()), txt.Text);
                        break;
                    }
            }
        }

        private void FillRepeater(Repeater rpt, byte statusID)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from action where statusid = " + statusID + " and registerid=" + Session["kullaniciid"] + " order by sort asc", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd2;
            DataSet ds = new DataSet();
            da.Fill(ds);
            rpt.DataSource = ds.Tables[0];
            rpt.DataBind();
            con.Close();
        }
        private void ChangeStatus(int actionID, byte sourceStatusID, byte targetStatusID)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();


            SqlCommand cmdSortOld = new SqlCommand("Select sort from action where id = @ACTIONID", con);
            cmdSortOld.Parameters.AddWithValue("ACTIONID", actionID);
            int sortOld = Convert.ToInt32(cmdSortOld.ExecuteScalar());

            SqlCommand cmdSortNew = new SqlCommand("Select ISNULL(MAX(sort), 0) from action where statusid = @STATUSID AND registerid = @REGISTERID", con);
            cmdSortNew.Parameters.AddWithValue("STATUSID", targetStatusID);
            cmdSortNew.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            int sortNew = Convert.ToInt32(cmdSortNew.ExecuteScalar());


            SqlCommand cmdUp = new SqlCommand("Update a Set a.statusid = @STATUSID, a.sort = @SORTNEW FROM action a where a.id = @ACTIONID AND a.registerid = @REGISTERID", con);
            cmdUp.Parameters.AddWithValue("STATUSID", targetStatusID);
            cmdUp.Parameters.AddWithValue("ACTIONID", actionID);
            cmdUp.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdUp.Parameters.AddWithValue("SORTNEW", sortNew + 1);
            cmdUp.ExecuteNonQuery();


            SqlCommand cmdUpOldSort = new SqlCommand("Update a Set a.sort = (a.sort - 1) FROM action a where a.statusid = @STATUSID AND a.registerid = @REGISTERID AND a.sort > @SORT", con);
            cmdUpOldSort.Parameters.AddWithValue("STATUSID", sourceStatusID);
            cmdUpOldSort.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdUpOldSort.Parameters.AddWithValue("SORT", sortOld);
            cmdUpOldSort.ExecuteNonQuery();

            con.Close();
        }
        private void ChangeOrder(int actionID, byte statusID)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();

            SqlCommand cmdSort = new SqlCommand("Select sort from action where id=@ACTIONID", con);
            cmdSort.Parameters.AddWithValue("ACTIONID", actionID);
            int sort = Convert.ToInt32(cmdSort.ExecuteScalar());

            SqlCommand cmdLower = new SqlCommand("Update action set sort=@SORT+1 where sort=@SORT AND registerid=@REGISTERID AND statusid=@STATUSID", con);
            cmdLower.Parameters.AddWithValue("STATUSID", statusID);
            cmdLower.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdLower.Parameters.AddWithValue("SORT", sort - 1);
            cmdLower.ExecuteNonQuery();

            SqlCommand cmdUpper = new SqlCommand("Update action set sort=@SORT where registerid=@REGISTERID AND statusid=@STATUSID AND id=@ACTIONID", con);
            cmdUpper.Parameters.AddWithValue("ACTIONID", actionID);
            cmdUpper.Parameters.AddWithValue("STATUSID", statusID);
            cmdUpper.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdUpper.Parameters.AddWithValue("SORT", sort - 1);
            cmdUpper.ExecuteNonQuery();
        }


        private void ChangeOrder2(int actionID, byte statusID)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();

            SqlCommand cmdSort = new SqlCommand("Select sort from action where id=@ACTIONID", con);
            cmdSort.Parameters.AddWithValue("ACTIONID", actionID);
            int sort = Convert.ToInt32(cmdSort.ExecuteScalar());

            SqlCommand cmdUpper2 = new SqlCommand("Update action set sort=@SORT-1 where sort=@SORT AND registerid=@REGISTERID AND statusid=@STATUSID", con);
            cmdUpper2.Parameters.AddWithValue("STATUSID", statusID);
            cmdUpper2.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdUpper2.Parameters.AddWithValue("SORT", sort + 1);
            cmdUpper2.ExecuteNonQuery();

            SqlCommand cmdLower2 = new SqlCommand("Update action set sort=@SORT where registerid=@REGISTERID AND statusid=@STATUSID AND id=@ACTIONID", con);
            cmdLower2.Parameters.AddWithValue("ACTIONID", actionID);
            cmdLower2.Parameters.AddWithValue("STATUSID", statusID);
            cmdLower2.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdLower2.Parameters.AddWithValue("SORT", sort + 1);
            cmdLower2.ExecuteNonQuery();
        }
        private void Delete(int actionID, int statusID)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();

            SqlCommand cmdSort = new SqlCommand("Select sort from action where id=@ACTIONID", con);
            cmdSort.Parameters.AddWithValue("ACTIONID", actionID);
            int sort = Convert.ToInt32(cmdSort.ExecuteScalar());

            SqlCommand cmdDel = new SqlCommand("Delete from action where id=@ACTIONID", con);
            cmdDel.Parameters.AddWithValue("ACTIONID", actionID);
            cmdDel.ExecuteNonQuery();

            SqlCommand cmdUpSort = new SqlCommand("Update action Set sort = (sort-1)  where statusid = @STATUSID AND registerid = @REGISTERID AND sort > @SORT", con);
            cmdUpSort.Parameters.AddWithValue("STATUSID", statusID);
            cmdUpSort.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdUpSort.Parameters.AddWithValue("SORT", sort);
            cmdUpSort.ExecuteNonQuery();
        }
        private void ChangeDescription(int actionID, string text)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CRBFT1O;Initial Catalog=ToDo;Integrated Security=True");
            con.Open();
            SqlCommand cmdChange = new SqlCommand("Update action set description=@DESCRIPTION where id=@ID AND registerid=@REGISTERID", con);
            cmdChange.Parameters.AddWithValue("DESCRIPTION", text);
            cmdChange.Parameters.AddWithValue("REGISTERID", Session["kullaniciid"]);
            cmdChange.Parameters.AddWithValue("ID", actionID);
            cmdChange.ExecuteNonQuery();
        }
    }
}
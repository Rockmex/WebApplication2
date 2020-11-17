﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication2
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    conn.Open();

                    string getInfoCmd = "select [Email],[Tel],[Password] from UserInfo where Email = '" + Session["Email"] + "'";
                    SqlCommand getInfo = new SqlCommand(getInfoCmd, conn);
                    SqlDataReader reader = getInfo.ExecuteReader();

                    if (reader.Read())
                    {
                        Label_ShowEmail.Text = reader["Email"].ToString();
                        Label_ShowPhone.Text = reader["Tel"].ToString();
                        //Label_ShowPass.Text = reader["Password"].ToString();
                    }
                    else
                    {
                        Response.Write("Error: Unable to get User info");
                    }

                    conn.Close();
                }
            }
        }

        protected void Button_Click_EditEmail(object sender, EventArgs e)
        {
            m1.Visible = true;
            black.Visible = true;
        }

        protected void Button_Click_EditPhone(object sender, EventArgs e)
        {
            m2.Visible = true;
            black.Visible = true;
        }

        protected void Button_Click_EditPassword(object sender, EventArgs e)
        {
            m3.Visible = true;
            black.Visible = true;
        }

        protected void Button_Click_Back(object sender, EventArgs e)
        {
            Response.Redirect("Personal.aspx");
        }

        protected void Button_Click_Back2(object sender, EventArgs e)
        {
            //Response.Redirect("Edit.aspx");
            m1.Visible = false;
            m2.Visible = false;
            m3.Visible = false;
            black.Visible = false;
        }

        protected void Button_Click_Update(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();


                string updateInfocmd = "update UserInfo SET Email = @email where Email = '" + Session["Email"] + "'";
                SqlCommand UpdateInfo = new SqlCommand(updateInfocmd, conn);
                UpdateInfo.Parameters.AddWithValue("@email", new_email.Text);

                UpdateInfo.ExecuteNonQuery();
                Session["Email"] = new_email.Text;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Updated sucessfully!!');window.location ='Personal.aspx';", true);

                conn.Close();
            }
            catch (Exception ex)
            {
                errorMessageHidden.Value = "Update Error:" + ex.ToString();
            }
        }

        protected void Button_Click_Update2(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();


                string updateInfocmd = "update UserInfo SET Tel = @Tel where Email = '" + Session["Email"] + "'";
                SqlCommand UpdateInfo = new SqlCommand(updateInfocmd, conn);
                UpdateInfo.Parameters.AddWithValue("@Tel", new_phone.Text);

                UpdateInfo.ExecuteNonQuery();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Updated sucessfully!!');window.location ='Personal.aspx';", true);

                conn.Close();
            }
            catch (Exception ex)
            {
                errorMessageHidden.Value = "Update Error:" + ex.ToString();
            }
        }

        protected void Button_Click_Update3(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();

                string checkUser = "Select count(*) from UserInfo where Email = '" + Session["Email"] + "' AND password = '" + old_password.Text + "'";
                SqlCommand cmdCheck = new SqlCommand(checkUser, conn);
                int match = Convert.ToInt32(cmdCheck.ExecuteScalar().ToString());

                if (match == 1)
                {
                    string updateInfocmd = "update UserInfo SET Password = @password where Email = '" + Session["Email"] + "'";
                    SqlCommand UpdateInfo = new SqlCommand(updateInfocmd, conn);

                    UpdateInfo.Parameters.AddWithValue("@password", new_password.Text);

                    UpdateInfo.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Updated sucessfully!!');window.location ='Personal.aspx';", true);
                }
                else
                {
                    errorMessageHidden.Value = "Error: Old Password not match";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                errorMessageHidden.Value = "Update Error:" + ex.ToString();
            }
        }
    }
}
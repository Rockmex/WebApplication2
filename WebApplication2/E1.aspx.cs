﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(Object sender, EventArgs e)
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

                Response.Write("Update Sucess !!");

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Update Error:" + ex.ToString());
            }
        }

        protected void Button2_Click(Object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }
    }
}
﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            string checkUser = "SELECT Status FROM FriendRelationship WHERE User1_Id = '" + Session["UID"] + "' AND User2_Id = '" + Session["FID"] + "'";
            SqlCommand cmdCheck = new SqlCommand(checkUser, conn);

            if (cmdCheck.ExecuteScalar() == null)
            {
                Button1.Visible = true;
                Button2.Visible = false;
            }
            else
            {
                int status = Convert.ToInt32(cmdCheck.ExecuteScalar().ToString());

                if (status == 1)
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                }

                else if (status == 0)
                {
                    Button1.Visible = false;
                    Button2.Visible = true;
                }

            }
            conn.Close();
        }

        protected void Request_Button_Click(Object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();

                string insertQuery = "insert into FriendRelationship (User1_Id, User2_Id, Status) values ('" + Session["UID"] + "','" + Session["FID"] + "', 0)";
                string insertQuery_2 = "insert into FriendRelationship (User1_Id, User2_Id, Status) values ('" + Session["FID"] + "','" + Session["UID"] + "', 0)";
                string insertLogQuery = "insert into EventLog values  ('" + Session["UID"] + "','" + Session["FID"] + "')";

                SqlCommand cmdInsert = new SqlCommand(insertQuery, conn);
                SqlCommand cmdInsert_2 = new SqlCommand(insertQuery_2, conn);
                SqlCommand cmdInsertLog = new SqlCommand(insertLogQuery, conn);

                cmdInsert.ExecuteNonQuery();
                cmdInsert_2.ExecuteNonQuery();
                cmdInsertLog.ExecuteNonQuery();

                conn.Close();
            }

            Response.Redirect("Friends.aspx");

            Response.Write("Request send");
        }

        protected void Delete_Button_Click(Object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();

                string deleteQuery = "DELETE FROM FriendRelationship WHERE User1_Id = '" + Session["UID"] + "' AND User2_Id = '" + Session["FID"] + "'";
                string deleteQuery_2 = "DELETE FROM FriendRelationship WHERE User1_Id = '" + Session["FID"] + "' AND User2_Id = '" + Session["UID"] + "'";

                SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn);
                SqlCommand cmdDelete_2 = new SqlCommand(deleteQuery_2, conn);

                cmdDelete.ExecuteNonQuery();
                cmdDelete_2.ExecuteNonQuery();

                conn.Close();
            }

            Response.Redirect("Friends.aspx");

            Response.Write("Request has been canceled");
        }
    }
}
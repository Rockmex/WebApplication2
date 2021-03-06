﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Email"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (Count() == 0)
                    {
                        listview_result.Visible = false;
                        Label_display.Text = "No such result.";
                    }
                    else
                    {
                        ShowResult();
                        Label_display.Text = "We Found " + Count() + " results.";
                    }
                }
            }
        }

        protected void Button_Click_View(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                Session["FID"] = e.CommandArgument;

                if (Session["UID"].ToString() == Session["FID"].ToString())
                {
                    Response.Redirect("Personal.aspx");
                }
                else
                {
                    Session["FID"] = e.CommandArgument;
                    Response.Redirect("Friends.aspx");
                }
            }
        }

        private void ShowResult()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            string searchCmd = "SELECT UID, Fname, Lname, ImageId FROM UserInfo WHERE Fname LIKE'" + Session["Result"] + "%' OR Lname LIKE'" + Session["Result"] + "%'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(searchCmd, conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            listview_result.DataSource = dataTable;
            listview_result.DataBind();
            conn.Close();
        }

        private int Count()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            string searchCmd = "SELECT count(*) FROM UserInfo WHERE Fname LIKE'" + Session["Result"] + "%' OR Lname LIKE'" + Session["Result"] + "%'";
            SqlCommand cmdCheck = new SqlCommand(searchCmd, conn);
            int count = Convert.ToInt32(cmdCheck.ExecuteScalar().ToString());
            conn.Close();
            return count;

        }
    }

}
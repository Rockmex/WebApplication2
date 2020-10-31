﻿using System;

namespace WebApplication2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                LogOut_Button.Visible = false;
            }
        }

        protected void Button_Click_LogOut(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button_Click_Search(object sender, EventArgs e)
        {
            Session["result"] = Search_target.Text;
            Response.Redirect("Result.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class suspendUA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Suspend_Click(object sender, EventArgs e)
    {
        User_Admin ua = new User_Admin(Session["uName"].ToString());

        if (ua.suspend_user(suspendUser.Text)) { 

            Label2.Text = suspendUser.Text + " suspended";
        }
        else
            Label2.Text = "User does not exist.";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Register_Click(object sender, EventArgs e)
    {
        User user = new User(registerUser.Text, registerPwd.Text);
        if (!user.check_username(registerUser.Text))
        {
            Tourist tr = new Tourist(registerUser.Text, registerPwd.Text, registerLName.Text, registerFName.Text, registerEmail.Text, registerCountry.Text);
            tr.create_TR();
            Tour_Guide tg = new Tour_Guide(registerUser.Text, registerPwd.Text, registerLName.Text, registerFName.Text, registerEmail.Text, registerCountry.Text);
            tg.create_TG();

            Response.Redirect("regSubmit.aspx");
        }
        
        else {
            Label2.Text = "Username already in use.";
        }
    }
}
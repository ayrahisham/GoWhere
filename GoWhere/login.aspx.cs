using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class GoWhere_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label2.Visible = false;
        if (!IsPostBack)
            username.Focus(); // blink cursor in TextBox1 
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        String user = loginType.SelectedValue;
        int num = 0;

        Session["uName"] = user;

        if (user.Equals("UA"))
        {
            User_Admin ua = new User_Admin(loginUser.Text, loginPwd.Text);
            if (ua.validate_UA())
                Response.Redirect("homeUA.aspx");
            else
                Label2.Text = "Username or Password is invalid...";
        }

        else if (user.Equals("TG"))
        {
            Tour_Guide tg = new Tour_Guide(loginUser.Text, loginPwd.Text);
            num = tg.validate_TG();
            Session["username"] = loginUser.Text;
            Session["password"] = loginPwd.Text;
            if (num == 1)
                Response.Redirect("homeTG.aspx");
            else if (num == 2)
                Label2.Text = "User is suspended";
            else if (num == 3)
                Label2.Text = "Username or Password is invalid...";
        }

        else if (user.Equals("TR"))
        {
            Tourist tr = new Tourist(loginUser.Text, loginPwd.Text);
            num = tr.validate_TR();
            Session["username"] = loginUser.Text;
            Session["password"] = loginPwd.Text;
            if (num == 1)
                Response.Redirect("homeTR.aspx");
            else if (num == 2)
                Label2.Text = "User is suspended";
            else if (num == 3)
                Label2.Text = "Username or Password is invalid...";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTG : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Tour_Guide tg = new Tour_Guide(Session["uName"].ToString());
        //Tour_Guide tg = new Tour_Guide("user1");
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());

        String reader = tg.view_profile();
        String[] readerArr = reader.Split(';');
        //lab.Text = Session["uName"].ToString();
        //lab.Text = reader.Length.ToString();
        TGFName.Text = readerArr[0];
        TGLName.Text = readerArr[1];
        TGEmail.Text = readerArr[2];
        TGCountry.Text = readerArr[3];
    }
}
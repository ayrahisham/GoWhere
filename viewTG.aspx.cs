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
        Tour_Guide tg = new Tour_Guide(Session["uName"].ToString());
        String reader = tg.view_profile();
        //String[] readerArr = reader.Split(';');

        lab.Text = reader.Length.ToString();
        //TGLName.Text = readerArr[1];
        //TGEmail.Text = readerArr[2];
        //TGCountry.Text = readerArr[3];
    }
}
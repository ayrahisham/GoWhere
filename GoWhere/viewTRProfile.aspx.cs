using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTRProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Tourist tr = new Tourist(Session["username"].ToString());
        String reader = tr.view_profile();

        String[] readerArr = reader.Split(';');

        TGFName.Text = readerArr[0];
        TGLName.Text = readerArr[1];
        TGEmail.Text = readerArr[2];
        TGCountry.Text = readerArr[3];
    }
}
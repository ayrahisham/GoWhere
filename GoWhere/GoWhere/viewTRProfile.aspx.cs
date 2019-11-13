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
        Tourist tr = new Tourist(Session["uName"].ToString());
        String reader = tr.view_profile();

        String[] readerArr = reader.Split(';');

        TGFName.Text = reader.Length.ToString();
    }
}
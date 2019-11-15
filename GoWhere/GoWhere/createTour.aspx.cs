using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class createTour : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void submitTour(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        Tour t = new Tour();
        String tgid = tg.getTGID();
        t.create_Tour(tgid, tourName.Text, tourCat.Text, tourCityCountry.Text, tourStartDate.Text, tourEndDate.Text, tourDesc.Text, tourPrice.Text, "Upcoming");

        Response.Redirect("~/homeTG.aspx");
    }
}
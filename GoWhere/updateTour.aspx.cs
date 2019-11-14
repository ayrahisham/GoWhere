using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class updateTour : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        tourID.Text = Session["tourID"].ToString();

        String reader = tg.getTourInfoForUpdate(Session["tourID"].ToString());
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        var startDate = Convert.ToDateTime(readerArr[0].ToString()).Date;
        tourStartDate.Text = startDate.ToString("dd/MM/yyyy");

        var endDate = Convert.ToDateTime(readerArr[1].ToString()).Date;
        tourEndDate.Text = endDate.ToString("dd/MM/yyyy");
        tourStatus.Text = readerArr[2];
        tourName.Text = readerArr[3];
        tourDesc.Text = readerArr[4];
        tourPrice.Text = readerArr[5];
        tourCat.Text = readerArr[6];
        tourCityCountry.Text = readerArr[7];
    }

    protected void updateTourInfo(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        tg.updateTour(Session["tourID"].ToString(), tourStartDate.Text, tourEndDate.Text, tourStatus.Text,
                     tourName.Text, tourDesc.Text, tourPrice.Text, tourCat.Text, tourCityCountry.Text);
        Response.Redirect("~/homeTG.aspx");
        //testing.Text = "WORLD";
        //System.Diagnostics.Debug.WriteLine("hello world");

    }
}
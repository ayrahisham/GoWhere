using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewUpTour : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        tourID.Text = Session["tourID"].ToString();
        String tgid = tg.getTGID();

        String TID = Session["tourID"].ToString();

        Tour t = new Tour();
        String reader = t.ViewTourInfo(TID);
        String[] readerArr = reader.Split(';');

        var startDate = Convert.ToDateTime(readerArr[0].ToString()).Date;
        tourStartDate.Text = startDate.ToString("dd/MM/yyyy");

        var endDate = Convert.ToDateTime(readerArr[1].ToString()).Date;
        tourEndDate.Text = endDate.ToString("dd/MM/yyyy");


        int days = (int)(endDate - startDate).TotalDays;
        tourDuration.Text = days.ToString();
        tourStatus.Text = readerArr[2].ToString();

        tourName.Text = readerArr[3].ToString();

        tourDesc.Text = readerArr[4].ToString();

        categoryText.Text = readerArr[5].ToString();

        tourCityCountry.Text = readerArr[6].ToString();
    }
}
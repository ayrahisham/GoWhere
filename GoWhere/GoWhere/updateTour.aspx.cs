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
        //tourStartDate.Text = startDate.ToString("dd/MM/yyyy");
        var endDate = Convert.ToDateTime(readerArr[1].ToString()).Date;

        tourStartDate.Attributes.Add("placeholder", startDate.ToString("dd/MM/yyyy"));
        tourEndDate.Attributes.Add("placeholder", endDate.ToString("dd/MM/yyyy"));
        tourStatus.Attributes.Add("placeholder", readerArr[2]);
        tourName.Attributes.Add("placeholder", readerArr[3]);
        tourDesc.Attributes.Add("placeholder", readerArr[4]);
        tourPrice.Attributes.Add("placeholder", readerArr[5]);
        tourCat.Attributes.Add("placeholder", readerArr[6]);
        tourCityCountry.Attributes.Add("placeholder", readerArr[7]);
    }

    protected void updateTourInfo(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        Tour t = new Tour();
        //String name = tourName.Text;
        //testing.Text = name;
        //t.testUpdate(name);
        //tourName.Attributes.Add("placeholder", tour_name);
        int tourID = int.Parse(Session["tourID"].ToString());
        //String status = tourStatusDropdown.SelectedValue;


        t.updateTour(tourID, tourStartDate.Text, tourEndDate.Text, tourStatus.Text,
                     tourName.Text, tourDesc.Text, tourPrice.Text, tourCat.Text, tourCityCountry.Text);
        Response.Redirect("~/homeTG.aspx");
        //testing.Text = "WORLD";
        //System.Diagnostics.Debug.WriteLine("hello world");

    }

    protected void tourName_TextChanged(object sender, EventArgs e)
    {
        String newTourname = tourName.Text;
        testing.Text = newTourname;
    }
}
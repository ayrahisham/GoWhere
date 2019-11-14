using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class giveR2T : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String BID = Session["bookID"].ToString();
        Booking_ID.Text = BID;

        Booking b = new Booking();
        string output = b.getTGInfobyBID(BID);
        String[] readerArr = output.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        string TID = readerArr[6];
        string TGID = readerArr[5];

        TID_label.Text = TID;
        TGID_label.Text = TGID;

    }

    public void submit_ratings(object sender, EventArgs e)
    {
        String BID = Session["bookID"].ToString();

        String ratings;
        if (rating1.Checked)
            ratings = rating1.Text;
        else if (rating2.Checked)
            ratings = rating2.Text;
        else if (rating3.Checked)
            ratings = rating3.Text;
        else if (rating4.Checked)
            ratings = rating4.Text;
        else
            ratings = rating5.Text;

        Booking b = new Booking();
        b.updateBookingWithRatings(BID, ratings);
        Response.Redirect("~/viewR2T.aspx");
    }
}
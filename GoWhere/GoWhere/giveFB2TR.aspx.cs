using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class giveFB2TR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        String TID = Session["TID"].ToString();
        TRID.Text = TID;
        String tour_id = Session["tourID"].ToString();
        tourID.Text = tour_id;

        Booking b = new Booking();
        String reader = b.getBookingIDByTID_tourID(TID, tour_id);
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);
        String booking_id = readerArr[0];
        BID.Text = booking_id;
    }

    protected void submitFeedback(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        Tour t = new Tour();
        String tgid = tg.getTGID();

        // tgid, bookingid, rating, feedback
        String TID = Session["TID"].ToString();
        String tour_id = Session["tourID"].ToString();

        Booking b = new Booking();
        String reader = b.getBookingIDByTID_tourID(TID, tour_id);
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);
        String booking_id = readerArr[0];

        String ratings = "";
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

        String feedback = TRFB.Text;

        TR_Ratings trr = new TR_Ratings();
        trr.sendRatingsAndFeedback(tgid, booking_id, ratings, feedback);

        Response.Redirect("~/viewTRofT.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTRofT : System.Web.UI.Page
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

        Tourist t = new Tourist();
        String tourist = t.viewTourist(TID);
        String[] touristArr = tourist.Split(';'); //  TID, first_name, last_name, email, country
        Array.Resize(ref touristArr, touristArr.Length - 1);

        String fname = touristArr[1];
        TRfname.Text = fname;
        String lname = touristArr[2];
        TRlname.Text = lname;
        String email = touristArr[3];
        TRemail.Text = email;
        String country = touristArr[4];
        TRcountry.Text = country;
    }
}
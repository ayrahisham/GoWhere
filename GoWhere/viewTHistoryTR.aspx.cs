using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTHistoryTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string book_id = Session["bookID"].ToString();

        Booking b = new Booking();
        string output = b.getBookingbyBID(book_id);

        String[] readerArr = output.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        string TID = readerArr[0];
        string tour_id = readerArr[1];
        string tourist_email = readerArr[2];
        string book_date = readerArr[3];
        string pax = readerArr[4];

        tourID.Text = tour_id;
        BID.Text = book_id;
        Bdate.Text = book_date;
        TRID.Text = TID;
        TRemail.Text = tourist_email;
        noOfPax.Text = pax;

        Tour t = new Tour();
        string output_tour = t.getTourByTRID(tour_id);

        readerArr = output_tour.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        string TGID = readerArr[0];
        string tour_name = readerArr[1];
        string tour_type = readerArr[2];
        string city_country = readerArr[3];
        string date_start = readerArr[4];
        string date_end = readerArr[5];
        string tour_desc = readerArr[6];
        string price = readerArr[7];
        string tour_status = readerArr[8];

        tourStartDate.Text = date_start;
        tourEndDate.Text = date_end;
        tourStatus.Text = tour_status;
        tourName.Text = tour_name;
        tourDesc.Text = tour_desc;
        category_field.Text = tour_type;
        tourCityCountry.Text = city_country;
    }
}
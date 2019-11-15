using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewR2TR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        String tgid = tg.getTGID();

        // tourID, touristID, ratings
        // select booking_id, rating FROM TR_Ratings where TGID = tgid AND rating IS NOT NULL
        TR_Ratings trr = new TR_Ratings();
        String reader = trr.getBookingID_rating(tgid); // booking_id, rating
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        int loops = readerArr.Length / 2;
        int bookingCount = 0;
        for (int i = 0; i < loops; i++)
        {
            String booking_id = readerArr[bookingCount]; // 2 
            String rating = readerArr[bookingCount + 1]; // 3

            Booking b = new Booking();
            String tourID_TID = b.getTourID_TID(booking_id); // tour_id, TID
            String[] tourID_TIDArr = tourID_TID.Split(';');
            Array.Resize(ref tourID_TIDArr, tourID_TIDArr.Length - 1);
            TableRow detailsRow = new TableRow();
            TableCell tourIDCell = new TableCell();
            tourIDCell.Text = tourID_TIDArr[0]; // tour_id
            detailsRow.Cells.Add(tourIDCell);

            TableCell tidCell = new TableCell();
            tidCell.Text = tourID_TIDArr[1]; // tourist id
            detailsRow.Cells.Add(tidCell);

            TableCell countCell = new TableCell();
            countCell.Text = rating;
            detailsRow.Cells.Add(countCell);

            viewR2TRTable.Rows.Add(detailsRow);
            bookingCount += 2;
        }
    }
}

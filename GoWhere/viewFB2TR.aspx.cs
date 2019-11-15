using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewFB2TR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        String tgid = tg.getTGID();

        TR_Ratings trr = new TR_Ratings();
        Booking b = new Booking();

        String reader = trr.getBookingID(tgid); // booking_id
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        if (readerArr.Length != 0)
        {
            int count = 0;
            for (int i = 0; i < readerArr.Length; i++)
            {
                String booking_id = readerArr[i];
                String tid_tour_id = b.getTourID_TID(booking_id);
                String[] tid_tour_idArr = tid_tour_id.Split(';'); // tid & tour_id
                Array.Resize(ref tid_tour_idArr, tid_tour_idArr.Length - 1);

                TableRow detailsRow = new TableRow();
                TableCell tourIDCell = new TableCell();
                tourIDCell.Text = tid_tour_idArr[1].ToString(); // tour_id
                detailsRow.Cells.Add(tourIDCell);

                TableCell tidCell = new TableCell();
                tidCell.Text = tid_tour_idArr[0].ToString(); // tid
                detailsRow.Cells.Add(tidCell);

                String feedback = trr.getFeedback(tgid, booking_id);
                String[] feedbackArr = feedback.Split(';');
                Array.Resize(ref feedbackArr, feedbackArr.Length - 1);
                TableCell countCell = new TableCell();
                countCell.Text = feedbackArr[count];
                detailsRow.Cells.Add(countCell);

                viewFB2TRTable.Rows.Add(detailsRow);
                count += 1;
            }
        }
    }
}
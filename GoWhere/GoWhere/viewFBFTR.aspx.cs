using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewFBFTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        String tgid = tg.getTGID();

        // select tourid from tour where tgid = tgid and status = completed --TOUR TABLE
        Tour t = new Tour();
        String reader = t.getTourID_completed(tgid);
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);
  
        Booking b = new Booking();
        for (int i = 0; i < readerArr.Length; i++)
        {
            int count = 0;
            String tourID = readerArr[i];
            String tourID_TID_feedback = b.getTourID_TID_feedback(tourID); // tourid, touristid, feedback --BOOKING TABLE
            if (tourID_TID_feedback != "")
            {
                String[] tourID_TID_feedbackArr = tourID_TID_feedback.Split(';');
                Array.Resize(ref tourID_TID_feedbackArr, tourID_TID_feedbackArr.Length - 1);

                int loops = tourID_TID_feedbackArr.Length / 3;
                for (int j = 0; j < loops; j++)
                {
                    TableRow detailsRow = new TableRow();
                    TableCell tourIDCell = new TableCell();
                    tourIDCell.Text = tourID_TID_feedbackArr[count].ToString();
                    detailsRow.Cells.Add(tourIDCell);

                    count += 1;

                    TableCell tidCell = new TableCell();
                    tidCell.Text = tourID_TID_feedbackArr[count].ToString();
                    detailsRow.Cells.Add(tidCell);

                    count += 1;

                    TableCell countCell = new TableCell();
                    countCell.Text = tourID_TID_feedbackArr[count].ToString();
                    detailsRow.Cells.Add(countCell);

                    viewFBFTRTable.Rows.Add(detailsRow);
                    count += 1;
                }
            }
        }
    }
}
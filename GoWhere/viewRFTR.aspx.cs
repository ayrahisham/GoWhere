using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewRFTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        String tgid = tg.getTGID();


        Booking b = new Booking();

        // tourID, touristID, ratings
        Tour t = new Tour();
        String tour_ids = t.getTourID_completed(tgid); // tourIDs under this tg
        if (tour_ids != "")
        {
            String[] tour_idsArr = tour_ids.Split(';');
            Array.Resize(ref tour_idsArr, tour_idsArr.Length - 1);

            for (int i = 0; i < tour_idsArr.Length; i++)
            {
                String tourID = tour_idsArr[i];
                String reader = b.getTourID_TID_rating(tourID); // tourid, tid, rating
                if (reader != "")
                {
                    String[] readerArr = reader.Split(';');
                    Array.Resize(ref readerArr, readerArr.Length - 1);
                    int loops = readerArr.Length / 3;
                    int count = 0;

                    for (int j = 0; j < loops; j++)
                    {

                        TableRow detailsRow = new TableRow();
                        TableCell tourIDCell = new TableCell();
                        tourIDCell.Text = readerArr[count]; // tour_id
                        detailsRow.Cells.Add(tourIDCell);

                        count += 1;
                        TableCell tidCell = new TableCell();
                        tidCell.Text = readerArr[count]; // tourist id
                        detailsRow.Cells.Add(tidCell);

                        count += 1;
                        TableCell countCell = new TableCell();
                        countCell.Text = readerArr[count]; // rating
                        detailsRow.Cells.Add(countCell);

                        viewRFTRTable.Rows.Add(detailsRow);
                        count += 1;
                    }
                }
            }
        }
    }
}
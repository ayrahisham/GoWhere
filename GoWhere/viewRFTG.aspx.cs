using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewRFTG : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String user = Session["username"].ToString();
        Tourist TR = new Tourist(user);
        String TID = TR.getTIDbyUsername();

        Booking b = new Booking();

        String reader = b.getRatingsFromTGByTID(TID);
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        int loops = readerArr.Length;
        for (int i = 0; i < loops; i += 3)
        {
            TableRow row = new TableRow();

            TableCell TGID_cell = new TableCell();
            TGID_cell.Text = readerArr[i];
            row.Cells.Add(TGID_cell);

            TableCell tour_id_cell = new TableCell();
            tour_id_cell.Text = readerArr[i + 1];
            row.Cells.Add(tour_id_cell);

            TableCell rating_cell = new TableCell();
            rating_cell.Text = readerArr[i + 2];
            row.Cells.Add(rating_cell);

            viewFBFTGTable.Rows.Add(row);
        }
    }
}
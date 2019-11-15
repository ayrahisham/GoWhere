using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewFB2T : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String user = Session["username"].ToString();
        Tourist TR = new Tourist(user);
        String TID = TR.getTIDbyUsername();

        Booking b = new Booking();

        String reader = b.getFeedbackByTID(TID);
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        int loops = readerArr.Length;
        for (int i = 0; i < loops; i += 4)
        {
            TableRow row = new TableRow();

            TableCell tour_id_cell = new TableCell();
            tour_id_cell.Text = readerArr[i];
            row.Cells.Add(tour_id_cell);

            TableCell book_id_cell = new TableCell();
            book_id_cell.Text = readerArr[i + 1];
            row.Cells.Add(book_id_cell);

            TableCell tgid_cell = new TableCell();
            tgid_cell.Text = readerArr[i + 2];
            row.Cells.Add(tgid_cell);

            TableCell feedback_cell = new TableCell();
            feedback_cell.Text = readerArr[i + 3];
            row.Cells.Add(feedback_cell);

            viewFB2TTable.Rows.Add(row);

        }
    }
}
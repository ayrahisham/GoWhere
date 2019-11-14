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

        String reader = tg.getFeedbackFromTourists(); // tourID, senderID, msg

        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        int loops = readerArr.Length / 3;
        int count = 0;
        for (int i = 0; i < loops; i++)
        {

            TableRow detailsRow = new TableRow();
            TableCell tourIDCell = new TableCell();
            tourIDCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(tourIDCell);

            count += 1;
            TableCell tidCell = new TableCell();
            tidCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(tidCell);

            count += 1;
            TableCell countCell = new TableCell();
            countCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(countCell);

            viewFBFTRTable.Rows.Add(detailsRow);
            count += 1;

        }
    }
}
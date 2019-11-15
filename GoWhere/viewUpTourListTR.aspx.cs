using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewUpTourListTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tourist tr = new Tourist(Session["username"].ToString());

        String reader = tr.viewUpcomingToursTR();

        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        int tuple_length = readerArr.Length + 1;
        int loops = tuple_length / 4;

        int count = 0;
        for (int i = 0; i < loops; i++)
        {
            LinkButton s = new LinkButton();
            s.Text = readerArr[count].ToString();
            s.Click += new EventHandler(setBookingId);

            TableRow detailsRow = new TableRow();
            TableCell tgidCell = new TableCell();
            tgidCell.Controls.Add(s);

            detailsRow.Cells.Add(tgidCell);

            count += 1;
            TableCell tidCell = new TableCell();
            tidCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(tidCell);

            count += 1;
            TableCell userCell = new TableCell();
            userCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(userCell);

            count += 1;
            TableCell r = new TableCell();
            r.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(r);

            TRUpTourListTable.Rows.Add(detailsRow);
            count += 1;
        }

    }

    protected void setBookingId(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        Session["bookID"] = link.Text;
        Response.Redirect("~/viewUpTourTR.aspx");

    }
}
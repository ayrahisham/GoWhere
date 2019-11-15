using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTHistoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        Tour t = new Tour();
        String tgid = tg.getTGID();
        String reader = t.viewTourHistoryList(tgid); // tour id and tour name
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        // int touristCount = tg.countTourists(readerArr[0].ToString());
        //testing1.Text = readerArr[0].ToString();
        //testing2.Text = readerArr[1].ToString();
        //testing3.Text = readerArr[2].ToString();
        //testing4.Text = readerArr[3].ToString();
        //tourtotalTR.Text = touristCount.ToString();

        Booking b = new Booking();
        int loops = readerArr.Length / 2;
        int count = 0;
        int touristArrCounter = 0;
        for (int i = 0; i < loops; i++)
        {

            LinkButton s = new LinkButton();
            s.Text = readerArr[count].ToString();
            s.Click += new EventHandler(setTourId);

            TableRow detailsRow = new TableRow();
            TableCell tgidCell = new TableCell();
            //tgidCell.Controls.Add(link);
            tgidCell.Controls.Add(s);

            //tgidCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(tgidCell);

            count += 1;
            TableCell tidCell = new TableCell();
            tidCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(tidCell);

            TableCell countCell = new TableCell();
            countCell.Text = b.countTourists(readerArr[touristArrCounter].ToString()).ToString();
            detailsRow.Cells.Add(countCell);

            TGTHistListTable.Rows.Add(detailsRow);
            count += 1;
            touristArrCounter += 2;
        }

    }

    protected void setTourId(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        Session["tourID"] = link.Text;
        Response.Redirect("~/viewTHistory.aspx");
        //testing.Text = "WORLD";
        //System.Diagnostics.Debug.WriteLine("hello world");

    }
}
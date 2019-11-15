using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTRList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        TID.Text = Session["tourID"].ToString();
        String tourID = Session["tourID"].ToString();

        Booking b = new Booking();
        Tourist t = new Tourist();
        String reader = b.getBookingTuples(tourID);
        String[] readerArr = reader.Split(';'); // contains array of tourist IDs
        // for each tourist ID, query the tourist database and return name and country
        Array.Resize(ref readerArr, readerArr.Length - 1);

        for (int i = 0; i < readerArr.Length; i++)
        {
            String touristID = readerArr[i].ToString();
            String touristInfo = t.queryTourist(touristID);
            String[] touristInfoArr = touristInfo.Split(';');
            Array.Resize(ref touristInfoArr, touristInfoArr.Length - 1);
   
            LinkButton s = new LinkButton();
            s.Text = touristInfoArr[0].ToString();
            s.Click += new EventHandler(goToTourist);

            TableRow detailsRow = new TableRow();
            TableCell tgidCell = new TableCell();
            tgidCell.Controls.Add(s);

            detailsRow.Cells.Add(tgidCell);

            TableCell tidCell = new TableCell();
            tidCell.Text = touristInfoArr[1].ToString();
            detailsRow.Cells.Add(tidCell);

            TableCell userCell = new TableCell();
            userCell.Text = touristInfoArr[2].ToString();
            detailsRow.Cells.Add(userCell);

            viewTRListTable.Rows.Add(detailsRow);            
        }

    }

    protected void goToTourist(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        Session["TID"] = link.Text;
        Response.Redirect("~/viewTR.aspx");
        //testing.Text = "WORLD";
        //System.Diagnostics.Debug.WriteLine("hello world");
    }
}
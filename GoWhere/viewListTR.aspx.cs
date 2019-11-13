using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewListTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        tourID.Text = Session["tourID"].ToString();
        Booking b = new Booking();
        String reader = b.getTIDbyTour(Session["tourID"].ToString()).ToString(); 
        String[] readerArr = reader.Split(';'); // array of tourist IDs
        Array.Resize(ref readerArr, readerArr.Length - 1);

        Tourist t = new Tourist();
        // for each tourist, get TID, first_name and last_name
        for (int i = 0; i < readerArr.Length; i++)
        {
            String touristID = readerArr[i].ToString();
            String touristInfo = t.getTouristName(touristID).ToString();
            String[] touristInfoArr = touristInfo.Split(';'); // array of TID, fname, lname
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

            viewListTRTable.Rows.Add(detailsRow);
        }

    }

    protected void goToTourist(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        Session["TID"] = link.Text;
        Response.Redirect("~/viewTRofT.aspx");
    }
}
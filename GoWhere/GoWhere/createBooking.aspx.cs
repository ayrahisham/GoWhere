using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class createBooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tourID.Text = Session["tourID"].ToString();
        Tourist tr = new Tourist(Session["username"].ToString());

        String TID = Session["tourID"].ToString();
        Tour t = new Tour();
        
        String reader = t.ViewTourInfo(TID);
        String[] readerArr = reader.Split(';');

        var startDate = Convert.ToDateTime(readerArr[0].ToString()).Date;
        tourStartDate.Text = startDate.ToString("dd/MM/yyyy");

        var endDate = Convert.ToDateTime(readerArr[1].ToString()).Date;
        tourEndDate.Text = endDate.ToString("dd/MM/yyyy");


        int days = (int)(endDate - startDate).TotalDays;
        tourDuration.Text = days.ToString();
        tourStatus.Text = readerArr[2].ToString();

        tourName.Text = readerArr[3].ToString();

        tourDesc.Text = readerArr[4].ToString();

        tourCategory.Text = readerArr[5].ToString();

        tourCityCountry.Text = readerArr[6].ToString();

        Tour tour_2 = new Tour();
        String output = tour_2.getTourByTRID(Session["tourID"].ToString());
        String[] outputArr = output.Split(';');

        string tour_price = outputArr[7].ToString();
        Price_L.Text = tour_price;
    }

    protected void book_Click(object sender, EventArgs e)
    {
        Booking b = new Booking();

        String tid_email = b.getTID_email(Session["username"].ToString()); // tid, email
        String[] tid_emailArr = tid_email.Split(';');
        Array.Resize(ref tid_emailArr, tid_emailArr.Length - 1);
        String tid = tid_emailArr[0];
        String email = tid_emailArr[1];


        if (b.createBooking(paxText.Text, Session["tourID"].ToString(), tid, email))
        {
            Tour t_booked = new Tour();
            string reader = t_booked.getTourByTRID(Session["tourID"].ToString());
            String[] readerArr = reader.Split(';');

            string tour_price = readerArr[7].ToString();

            TableRow status = new TableRow();

            TableCell status_cell = new TableCell();
            status_cell.ColumnSpan = 2;
            status_cell.Font.Bold = true;
            status_cell.Text = "BOOKING SUCCESSFUL";
            status.Cells.Add(status_cell);

            bookingTable.Rows.Add(status);

            TableRow price = new TableRow();

            TableCell price_label_cell = new TableCell();
            price_label_cell.Text = "Total Price (SGD):";
            price.Cells.Add(price_label_cell);

            int tour_p = Int32.Parse(tour_price); 
            int pax = Int32.Parse(paxText.Text);
            int total = tour_p * pax;

            TableCell price_cell = new TableCell();
            price_cell.Text = total.ToString();
            price.Cells.Add(price_cell);

            bookingTable.Rows.Add(price);
        }
        else
        {
            TableRow status = new TableRow();

            TableCell status_cell = new TableCell();
            status_cell.ColumnSpan = 2;
            status_cell.Font.Bold = true;
            status_cell.Text = "Error! Please try again later!";
            status.Cells.Add(status_cell);

            bookingTable.Rows.Add(status);
        }
    }
}
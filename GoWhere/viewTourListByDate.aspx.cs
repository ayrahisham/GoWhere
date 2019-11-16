using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTourListByDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Tourist tr = new Tourist(Session["username"].ToString());

        Tour t = new Tour();
        String selectedDate = Session["selectedDate"].ToString();
        String reader = t.getToursByDate(selectedDate);

        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1); // remove last element

        // create new row for adding table heading
        TableRow tableHeading = new TableRow();

        // create and add cells 
        TableHeaderCell tourIdHeading = new TableHeaderCell();
        tourIdHeading.Text = "Tour ID";
        tourIdHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(tourIdHeading);

        TableHeaderCell dateHeading = new TableHeaderCell();
        dateHeading.Text = "Date Start";
        dateHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(dateHeading);

        TableHeaderCell descHeading = new TableHeaderCell();
        descHeading.Text = "Tour Type";
        descHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(descHeading);

        TableHeaderCell cityHeading = new TableHeaderCell();
        cityHeading.Text = "City/Country";
        cityHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(cityHeading);

        TableHeaderCell statusHeading = new TableHeaderCell();
        statusHeading.Text = "Status";
        statusHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(statusHeading);

        showTable.Rows.Add(tableHeading);

        // add details to table
        for (int i = 0; i < readerArr.Length; i++)
        {
            LinkButton s = new LinkButton();
            s.Text = readerArr[i].ToString();
            s.Click += new EventHandler(setTourId);
            TableRow detailsRow = new TableRow();

            TableCell tourIdCell = new TableCell();
            tourIdCell.Controls.Add(s);
            detailsRow.Cells.Add(tourIdCell);

            TableCell dateCell = new TableCell();
            dateCell.Text = readerArr[++i];
            detailsRow.Cells.Add(dateCell);

            TableCell descCell = new TableCell();
            descCell.Text = readerArr[++i];
            detailsRow.Cells.Add(descCell);

            TableCell cityCell = new TableCell();
            cityCell.Text = readerArr[++i];
            detailsRow.Cells.Add(cityCell);

            TableCell statusCell = new TableCell();
            statusCell.Text = readerArr[++i];
            detailsRow.Cells.Add(statusCell);

            showTable.Rows.Add(detailsRow);
        }

        //Button z = new Button();
        //z.Text = "Return to View Available Dates";
        //z.Click += new EventHandler(return_load_date);

        //TableRow return_row = new TableRow();
        //TableCell return_cell = new TableCell();
        //return_cell.ColumnSpan = 5;
        //return_cell.Controls.Add(z);
        //return_row.Cells.Add(return_cell);
        //showTable.Rows.Add(return_row);

    }


    protected void setTourId(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        Session["tourID"] = link.Text;
        Response.Redirect("~/createBooking.aspx");
        //testing.Text = "WORLD";
        System.Diagnostics.Debug.WriteLine("hello world");

    }

}
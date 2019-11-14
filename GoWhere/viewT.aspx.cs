using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tourist tr = new Tourist(Session["uName"].ToString());
        String reader = tr.view_Tours();
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1); // remove last element

        // create new row for adding table heading
        TableRow tableHeading = new TableRow();

        // create and add cells 
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

        DisplayTable.Rows.Add(tableHeading);

        // add details to table
        for (int i = 0; i < readerArr.Length; i++)
        {
            TableRow detailsRow = new TableRow();
            TableCell dateCell = new TableCell();
            dateCell.Text = readerArr[i];
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

            DisplayTable.Rows.Add(detailsRow);
        }
    }
}
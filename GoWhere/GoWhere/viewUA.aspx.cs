using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Collections;

public partial class viewUA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User_Admin ua = new User_Admin(Session["uName"].ToString());
        String reader = ua.view_Users();
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1); // remove last element

        // create new row for adding table heading
        TableRow tableHeading = new TableRow();

        // create and add cells that contain tourist ID
        TableHeaderCell tidHeading = new TableHeaderCell();
        tidHeading.Text = "Tour Guide ID";
        tidHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(tidHeading);

        TableHeaderCell tgidHeading = new TableHeaderCell();
        tgidHeading.Text = "Tourist ID";
        tgidHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(tgidHeading);

        TableHeaderCell userHeading = new TableHeaderCell();
        userHeading.Text = "Username";
        userHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(userHeading);

        TableHeaderCell susHeading = new TableHeaderCell();
        susHeading.Text = "Status";
        susHeading.HorizontalAlign = HorizontalAlign.Left;
        tableHeading.Cells.Add(susHeading);

        DisplayTable.Rows.Add(tableHeading);

        // add details to table
        for (int i = 0; i < readerArr.Length; i++)
        {
            TableRow detailsRow = new TableRow();
            TableCell tgidCell = new TableCell();
            tgidCell.Text = readerArr[i];
            detailsRow.Cells.Add(tgidCell);

            TableCell tidCell = new TableCell();
            tidCell.Text = readerArr[++i];
            detailsRow.Cells.Add(tidCell);

            TableCell userCell = new TableCell();
            userCell.Text = readerArr[++i];
            detailsRow.Cells.Add(userCell);

            TableCell susCell = new TableCell();
            if (readerArr[++i].Equals("true"))
            {
                susCell.Text = "Suspended";
            }
            else 
                susCell.Text = "Active";
            detailsRow.Cells.Add(susCell);

            DisplayTable.Rows.Add(detailsRow);
        }
    }
}
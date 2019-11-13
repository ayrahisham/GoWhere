using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class updateTourList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        String reader = tg.ViewUpcomingTours();
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);


        int tuple_length = readerArr.Length + 1;
        int loops = tuple_length / 3;

        int count = 0;
        for (int i = 0; i < loops; i++)
        {
            //HyperLink link = new HyperLink();
            //String hyperlink = "~/viewUpTourList.aspx";
            //link.NavigateUrl = hyperlink;
            //link.Text = readerArr[count].ToString();
            //link.Attributes.Add("onclick", "setTourId");
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

            count += 1;
            TableCell userCell = new TableCell();
            userCell.Text = readerArr[count].ToString();
            detailsRow.Cells.Add(userCell);

            updateTListTable.Rows.Add(detailsRow);
            count += 1;
        }

        /*
        for (int i = 0; i < 3; i++)
        {
            TableRow detailsRow = new TableRow();
            TableCell tgidCell = new TableCell();
            tgidCell.Text = readerArr[i].ToString();
            detailsRow.Cells.Add(tgidCell);

            //count += 1;
            TableCell tidCell = new TableCell();
            tidCell.Text = readerArr[i].ToString();
            detailsRow.Cells.Add(tidCell);

            //count += 1;
            TableCell userCell = new TableCell();
            userCell.Text = readerArr[i].ToString();
            detailsRow.Cells.Add(userCell);

            TGUpTourListTable.Rows.Add(detailsRow);
            //count = 0;
        }*/
    }

    protected void setTourId(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        Session["tourID"] = link.Text;
        Response.Redirect("~/updateTour.aspx");
        //testing.Text = "WORLD";
        //System.Diagnostics.Debug.WriteLine("hello world");

    }
}
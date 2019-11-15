using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class giveFB2T : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String BID = Session["bookID"].ToString();
        ID.Text = BID;

        Booking b = new Booking();
        string output = b.getTGInfobyBID(BID);
        String[] readerArr = output.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        string TID = readerArr[6];
        string TGID = readerArr[5];

        TID_label.Text = TID;
        TGID_label.Text = TGID;

    }

    public void submit_fb(object sender, EventArgs e)
    {
        String BID = Session["bookID"].ToString();
        string feedback = TRFB.Text;
        Booking b = new Booking();
        b.updateBookingWithFeedback(BID, feedback);
        Response.Redirect("~/viewFB2T.aspx");
    }
}
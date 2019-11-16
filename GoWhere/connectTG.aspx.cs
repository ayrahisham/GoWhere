using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class connectTG : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string BID = Session["bookID"].ToString();

        Booking b = new Booking();
        string output = b.getTGInfobyBID(BID);

        String[] readerArr = output.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        TGfname.Text = readerArr[0];
        TGlname.Text = readerArr[1];
        TGemail.Text = readerArr[2];
        TGcountry.Text = readerArr[3];

        tourID.Text = readerArr[4];
        TGID.Text = readerArr[5];
        TRID.Text = readerArr[6];
        bookingID.Text = BID;

        string TGID_str = readerArr[5];
        string TID_str = readerArr[6];
        Message m = new Message();


        int maxID = -1;

        // sender, receiver, booking, sender_type, receiver_type
        // getLatestMessageID(String sender_id, String receiver_id,
        // String booking_id, String sender_type, String receiver_type)
        maxID = m.getLatestMessageID(TGID_str, TID_str, BID, "TG", "TR");
        System.Diagnostics.Debug.WriteLine(maxID);
        if (maxID == -1)
        {
            reply.Text = "";
        }
        else
        {
            String msg = m.getCorrespondence(maxID);
            reply.Text = msg;
            if (msg.Length != 0)
            {
                String[] msgArr = msg.Split(';');
                Array.Resize(ref msgArr, msgArr.Length - 1);
                reply.Text = msgArr[0];

            }
        }






        //String message = m.getCorrespondence(TGID_str, TID_str, BID);

        //TextBox1.Text = message;

    }

    protected void submitMessage(object sender, EventArgs e)
    {
        string BID = Session["bookID"].ToString();
        Booking b = new Booking();
        string output = b.getTGInfobyBID(BID);
        String[] readerArr = output.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        string tour_id = readerArr[4];
        string tgid = readerArr[5];

        string user_name = Session["username"].ToString();
        Tourist TR = new Tourist(user_name);
        string TID = TR.getTIDbyUsername();

        Message m = new Message();
        DateTime dt = DateTime.Now;
        String date = dt.ToString("dd/MM/yyyy");

        String msg = TGmsg.Text;
        m.sendMessageToTG(BID, tour_id, tgid, TID, date, msg);
        Response.Redirect("~/viewUpTourListTR.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class connectTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Message m = new Mesage();
        // String tgid, String TID, String booking_id
        //reply.Text = m.getCorrespondence();
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        String tgid = tg.getTGID();
        String TID = Session["TID"].ToString();
        String tour_id = Session["tourID"].ToString();
        Booking b = new Booking();
        String booking_id = b.getBookingIDByTID_tourID(TID, tour_id);
        String[] readerArr = booking_id.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);
        String bk_id = readerArr[0];
        System.Diagnostics.Debug.WriteLine("booking results " + booking_id);
        System.Diagnostics.Debug.WriteLine("TID " + TID);
        System.Diagnostics.Debug.WriteLine("tour_id " + tour_id);
        System.Diagnostics.Debug.WriteLine("booking_id " + bk_id);



        Session["booking_id"] = bk_id;
        
        Message m = new Message();
        int maxID = -1;
        //(String sender_id, String receiver_id, String booking_id, String sender_type, String receiver_type)
        maxID = m.getLatestMessageID(TID, tgid, bk_id, "TR", "TG");
        
        //String highestMessageID = "";
        //if (maxID.Length != 0)
        //{
        //    String[] maxIDArr = maxID.Split(';');
        //    Array.Resize(ref maxIDArr, maxIDArr.Length - 1);
        //    highestMessageID = maxIDArr[0];
        //}
       if (maxID == -1)
        {
            reply.Text = "WRONG INDEX";
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

       
        //reply.Text = m.getCorrespondence(tgid, TID, booking_id);
        //reply.Text = " HLELO";

    }


    protected void submitMessage(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();
        String tgid = tg.getTGID(); 

        Message m = new Message();
        String TID = Session["TID"].ToString();
        System.Diagnostics.Debug.WriteLine(TID);
        String tour_id = Session["tourID"].ToString(); 
        System.Diagnostics.Debug.WriteLine(tour_id);
        Booking b = new Booking();
        String reader = b.getBookingIDByTID_tourID(TID, tour_id);
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);
        String booking_id = readerArr[0];

        DateTime dt = DateTime.Now;
        String date = dt.ToString("dd/MM/yyyy");
        String msg = TGmsg.Text;
        m.sendMessageToTR(booking_id, tour_id, tgid, TID, date, msg);
        Response.Redirect("~/viewTRList.aspx");
    }
}
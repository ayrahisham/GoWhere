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
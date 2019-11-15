using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        TID.Text = Session["tourID"].ToString();

        Tourist t = new Tourist();
        String reader = t.viewTourist(Session["TID"].ToString());
        String[] readerArr = reader.Split(';'); 
        Array.Resize(ref readerArr, readerArr.Length - 1);

        TRID.Text = readerArr[0].ToString();
        TRfname.Text = readerArr[1].ToString();
        TRlname.Text = readerArr[2].ToString();
        TRemail.Text = readerArr[3].ToString();
        TRcountry.Text = readerArr[4].ToString();
    }
}
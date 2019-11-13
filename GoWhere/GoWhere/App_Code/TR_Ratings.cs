using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for TR_Ratings
/// </summary>
public class TR_Ratings
{
    private int id;
    private int TGID;
    private int booking_id;
    private int rating;
    private String feedback;

    public TR_Ratings()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    

    public String getBookingID(String TGID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT booking_id FROM TR_Ratings WHERE TGID=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TGID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["booking_id"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getFeedback(String TGID, String booking_id)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT feedback FROM TR_Ratings WHERE TGID=? AND booking_id=booking_id";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TGID);
        cmd.Parameters.AddWithValue("booking_id", booking_id);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["feedback"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getTourID_TID_ratings(String tourID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        // tourid, touristid, feedback --BOOKING TABLE
        sql = "SELECT tour_id, TID, feedback FROM Booking WHERE tour_id=? AND feedback IS NOT NULL";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tourID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["TID"].ToString() + ";" + reader["feedback"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getBookingID_rating(String TGID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT booking_id, rating FROM TR_Ratings WHERE TGID=? AND rating IS NOT NULL";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TGID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["booking_id"].ToString() + ";" + reader["rating"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public void sendRatingsAndFeedback(String TGID, String booking_id, String rating, String feedback)
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();

        cmd.CommandText = "INSERT INTO TR_Ratings ([TGID], [booking_id], [rating], [feedback]) " +
                           "VALUES(@TGID, @booking_id, @rating, @feedback);";
        cmd.Parameters.AddWithValue("@TGID", TGID);
        cmd.Parameters.AddWithValue("@booking_id", booking_id);
        cmd.Parameters.AddWithValue("@rating", rating);
        cmd.Parameters.AddWithValue("@feedback", feedback);
        cmd.ExecuteNonQuery();
        con.Close();
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Booking
/// </summary>
public class Booking
{
    // private variables
    private int booking_id;
    private int TID;
    private int tour_id;
    private int pax;
    private int rating;
    private String feedback;

    // Returns touristID from booking where tourID = parameter
    public String getBookingTuples(String tourID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT TID FROM Booking WHERE tour_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tourID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TID"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    // returns count of bookings where tourID = parameter
    public int countTourists(String tourID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT COUNT(TID) FROM Booking WHERE tour_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tourID);

        //OleDbDataReader reader = cmd.ExecuteReader();
        Int32 count = (Int32)cmd.ExecuteScalar();

        con.Close();

        return count;
    }

    // return TID from booking where tourID = parameter
    public String getTIDbyTour(String tourID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT TID FROM Booking WHERE tour_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tourID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TID"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    // returns tourID, touristID, rating from booking where tourID = parameter
    public String getRatingsFromTourist(String tourID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, TID, rating FROM Booking WHERE tour_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tourID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["TID"].ToString() + ";" + reader["rating"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getTourID_TID(String booking_id)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, TID FROM Booking WHERE booking_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", booking_id);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["TID"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String viewFeedbackToTourists(String bookingID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, TID, rating FROM Booking WHERE tour_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", bookingID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["TID"].ToString() + ";" + reader["rating"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getTourID_TID_feedback(String tourID)
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

    public String getTourID_TID_rating(String tour_id)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        // tourid, touristid, feedback --BOOKING TABLE
        sql = "SELECT tour_id, TID, rating FROM Booking WHERE tour_id=? AND rating IS NOT NULL";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tour_id);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["TID"].ToString() + ";" + reader["rating"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getBookingIDByTID_tourID(String TID, String tour_id)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        // tourid, touristid, feedback --BOOKING TABLE
        sql = "SELECT booking_id FROM Booking WHERE TID=? AND tour_id=tour_id";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);
        cmd.Parameters.AddWithValue("tour_id", tour_id);

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
}
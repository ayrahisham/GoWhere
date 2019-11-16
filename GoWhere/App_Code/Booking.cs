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

    public String getTID_email(String username)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        // tourid, touristid, feedback --BOOKING TABLE
        sql = "SELECT TID, email FROM Tourist WHERE user=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", username);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TID"].ToString() + ";" + reader["email"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public Boolean createBooking(String pax, String tour_id, String tid, String email)
    {
        Boolean check = false;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        //String sql = "SELECT Tourist.TID, Tourist.email FROM Tourist WHERE [user]=?";
        //OleDbCommand cmd = new OleDbCommand(sql, con);
        //cmd.Parameters.AddWithValue("?", uName);

        //OleDbDataReader reader = cmd.ExecuteReader();

        String str = String.Empty;
        //String tid = String.Empty;
        //String email = String.Empty;

        // while (reader.Read())
        // {
        //     str+= reader["TID"].ToString() + ";" + reader["email"].ToString();
        //     //tid = reader["TID"].ToString();
        //     //email = reader["email"].ToString();
        // }
        // reader.Close();

        //String[] readerArr = str.Split(';');

        // tid = readerArr[0];
        // email = readerArr[1];

        DateTime d = DateTime.Now;
        String dt = d.ToString("dd/MM/yyyy");

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "INSERT INTO Booking ([TID], [tour_id], [tourist_email], [booking_date], [pax]) VALUES(@TID, @tour_id, @tourist_email, @booking_date, @pax);";
        cmd.Parameters.AddWithValue("@TID", tid);
        cmd.Parameters.AddWithValue("@tour_id", tour_id);
        cmd.Parameters.AddWithValue("@tourist_email", email);
        cmd.Parameters.AddWithValue("@booking_date", dt);
        cmd.Parameters.AddWithValue("@pax", pax);
        cmd.ExecuteNonQuery();

        /*OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "INSERT INTO Booking ([TID], [tour_id]) VALUES(@TID, @tour_id)";
        cmd.Parameters.AddWithValue("@TID", tid);
        cmd.Parameters.AddWithValue("@tour_id", tour_id);
        cmd.ExecuteNonQuery();*/
        check = true;

        con.Close();
        return check;
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

    // returns upcoming bookings where TID = parameter
    public string getUpcomingBookingsByTID(string TID)
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        sql = "SELECT Booking.booking_id, Tour.tour_name, Tour.date_start, Tour.tour_status" +
            " FROM Tour INNER JOIN Booking ON(Booking.tour_id = Tour.tour_id) " +
            "WHERE Booking.TID = ? AND NOT Tour.tour_status = @status";

        OleDbCommand cmd = new OleDbCommand(sql, con);

        cmd.Parameters.AddWithValue("?", TID);
        cmd.Parameters.AddWithValue("@status", "Completed");
        //cmd.Parameters.AddWithValue("@suspended", "Suspended");

        OleDbDataReader reader = cmd.ExecuteReader();

        String output = "";

        while (reader.Read())
        {
            output += reader["booking_id"].ToString() + ";" + reader["tour_name"].ToString() + ";" + (Convert.ToDateTime(reader["date_start"]).ToShortDateString()).ToString() + ";" + reader["tour_status"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return output;

    }

    //BID = booking ID
    public string getBookingbyBID(string BID)
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        sql = "SELECT * FROM Booking WHERE booking_id = ?";

        OleDbCommand cmd = new OleDbCommand(sql, con);

        cmd.Parameters.AddWithValue("?", BID);


        OleDbDataReader reader = cmd.ExecuteReader();

        String output = "";

        while (reader.Read())
        {
            output += reader["TID"].ToString() + ";" + reader["tour_id"].ToString() + ";" + reader["tourist_email"].ToString() + ";" + (Convert.ToDateTime(reader["booking_date"]).ToShortDateString()).ToString() + ";" + reader["pax"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return output;

    }

    public void cancelBookingbyBID(string BID)
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        sql = "DELETE * FROM Booking WHERE booking_id = ?";
        OleDbCommand cmd = new OleDbCommand(sql, con);

        cmd.Parameters.AddWithValue("?", BID);
        cmd.ExecuteNonQuery();

        con.Close();
    }

    public string getTGInfobyBID(string BID)
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        sql = "SELECT * FROM Booking " +
               " INNER JOIN(Tour_Guide INNER JOIN Tour ON(Tour.TGID = Tour_Guide.TGID))" +
               " ON(Booking.tour_id = Tour.tour_id)" +
               " WHERE Booking.booking_id = ? ";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", BID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String output = "";

        while (reader.Read())
        {
            output += reader["first_name"].ToString() + ";" + reader["last_name"].ToString() + ";" + reader["email"].ToString() + ";" + reader["country"].ToString() + ";";
            output += reader["Tour.tour_id"].ToString() + ";" + reader["Tour.TGID"] + ";" + reader["TID"] + ";";
        }


        reader.Close();
        con.Close();

        return output;


    }

    public string getCompletedBookingsByTID(string TID)
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        sql = "SELECT Booking.booking_id, Tour.tour_name, Tour.date_start FROM Tour INNER JOIN Booking ON(Booking.tour_id = Tour.tour_id) WHERE Booking.TID = ? AND Tour.tour_status = status";

        OleDbCommand cmd = new OleDbCommand(sql, con);

        cmd.Parameters.AddWithValue("?", TID);
        cmd.Parameters.AddWithValue("status", "Completed");

        OleDbDataReader reader = cmd.ExecuteReader();

        String output = "";

        while (reader.Read())
        {
            output += reader["booking_id"].ToString() + ";" + reader["tour_name"].ToString() + ";" + (Convert.ToDateTime(reader["date_start"]).ToShortDateString()).ToString() + ";";
        }
        reader.Close();
        con.Close();

        return output;

    }


    public void updateBookingWithRatings(string BID, string rating_para)
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "UPDATE Booking SET rating = @rating WHERE booking_id =?";
        cmd.Parameters.Add("@ratings", OleDbType.Char).Value = rating_para;
        cmd.Parameters.AddWithValue("?", BID);

        cmd.ExecuteNonQuery();
        con.Close();

    }

    public String getRatingsByTID(String TID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = sql = "SELECT * FROM Booking " +
               " INNER JOIN(Tour_Guide INNER JOIN Tour ON(Tour.TGID = Tour_Guide.TGID))" +
               " ON(Booking.tour_id = Tour.tour_id)" +
               " WHERE TID =? AND rating > 0";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["Booking.tour_id"].ToString() + ";" + reader["booking_id"].ToString() + ";" + reader["Tour.TGID"].ToString() + ";" + reader["rating"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public void updateBookingWithFeedback(string BID, string feedback)
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "UPDATE Booking SET feedback = @feedback WHERE booking_id =?";
        cmd.Parameters.Add("@feedback", OleDbType.Char).Value = feedback;
        cmd.Parameters.AddWithValue("?", BID);

        cmd.ExecuteNonQuery();
        con.Close();

    }

    public String getFeedbackByTID(String TID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = sql = "SELECT * FROM Booking " +
               " INNER JOIN(Tour_Guide INNER JOIN Tour ON(Tour.TGID = Tour_Guide.TGID))" +
               " ON(Booking.tour_id = Tour.tour_id)" +
               " WHERE TID =? AND feedback IS NOT NULL";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["Booking.tour_id"].ToString() + ";" + reader["booking_id"].ToString() + ";" + reader["Tour.TGID"].ToString() + ";" + reader["feedback"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }


    public String getFeedbackFromTGByTID(String TID)
    {

        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT * FROM Booking " +
               " INNER JOIN TR_Ratings" +
               " ON(Booking.booking_id = TR_Ratings.booking_id)" +
               " WHERE TID =?";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TGID"].ToString() + ";" + reader["tour_id"].ToString() + ";" + reader["TR_Ratings.feedback"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getRatingsFromTGByTID(String TID)
    {

        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT * FROM Booking " +
               " INNER JOIN TR_Ratings" +
               " ON(Booking.booking_id = TR_Ratings.booking_id)" +
               " WHERE TID =?";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TGID"].ToString() + ";" + reader["tour_id"].ToString() + ";" + reader["TR_Ratings.rating"].ToString() + ";";
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
        sql = "SELECT booking_id FROM Booking WHERE TID=? AND tour_id=@tour_id";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);
        cmd.Parameters.AddWithValue("@tour_id", tour_id);

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
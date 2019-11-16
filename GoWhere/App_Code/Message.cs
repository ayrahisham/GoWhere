using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{
    // private variables
    private int message_id;
    private String sender_type;
    private String receiver_type;
    private int sender_id;
    private int receiver_id;
    private DateTime message_date; // DateTime.Now.ToString(
    private DateTime message_time; // DateTime.Now.ToString("HH:mm")
    private String message;

    public Message()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void sendMessageToTG(String booking_id, String tour_id, String tgid, String TID, String message_date, String message)
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();

        cmd.CommandText = "INSERT INTO Message ([booking_id], [tour_id], [sender_type], [receiver_type], [sender_id], [receiver_id], [message_date], [message]) " +
                           "VALUES(@booking_id, @tour_id, @sender_type, @receiver_type, @sender_id, @receiver_id, @message_date, @message);";
        cmd.Parameters.AddWithValue("@booking_id", booking_id);
        cmd.Parameters.AddWithValue("@tour_id", tour_id);
        cmd.Parameters.AddWithValue("@sender_type", "TR");
        cmd.Parameters.AddWithValue("@receiver_type", "TG");
        cmd.Parameters.AddWithValue("@sender_id", TID);
        cmd.Parameters.AddWithValue("@receiver_id", tgid);
        cmd.Parameters.AddWithValue("@message_date", message_date);
        cmd.Parameters.AddWithValue("@message", message);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public String getCorrespondence(String TGID, String TID, String booking_id)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        // SELECT message from Message WHERE sender_id = 1 AND sender_type = "TG" AND receiver_id = 473 AND receiver_type = "TR" AND message_id = (SELECT MAX(message_id) FROM Message);
        sql = "SELECT message FROM Message " +
            "WHERE booking_id = @booking_id AND " +
            "sender_id = @sender_id AND " +
            "sender_type = @tg AND " +
            "receiver_id = @receiver_id AND " +
            "receiver_type = @tr AND " +
            "message_id = (SELECT MAX(message_id) FROM Message)";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("@booking_id", booking_id);
        cmd.Parameters.AddWithValue("@sender_id", TID);
        cmd.Parameters.AddWithValue("@tg", "TG");
        cmd.Parameters.AddWithValue("@receiver_id", TGID);
        cmd.Parameters.AddWithValue("@tr", "TR");

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["message"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getFeedbackToTourists(String tgid)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, receiver_id, message FROM Message WHERE sender_type=? AND sender_id=TGID";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", "TG");
        cmd.Parameters.AddWithValue("TGID", tgid);


        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["receiver_id"].ToString() + ";" + reader["message"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getFeedbackFromTourists(String tgid)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, sender_id, message FROM Message WHERE sender_type=? AND receiver_id=TGID";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", "TR");
        cmd.Parameters.AddWithValue("TGID", tgid);


        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["sender_id"].ToString() + ";" + reader["message"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public void sendMessageToTR(String booking_id, String tour_id, String tgid, String TID, String message_date, String message)
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();

        cmd.CommandText = "INSERT INTO Message ([booking_id], [tour_id], [sender_type], [receiver_type], [sender_id], [receiver_id], [message_date], [message]) " +
                           "VALUES(@booking_id, @tour_id, @sender_type, @receiver_type, @sender_id, @receiver_id, @message_date, @message);";
        cmd.Parameters.AddWithValue("@booking_id", booking_id);
        cmd.Parameters.AddWithValue("@tour_id", tour_id);
        cmd.Parameters.AddWithValue("@sender_type", "TG");
        cmd.Parameters.AddWithValue("@receiver_type", "TR");
        cmd.Parameters.AddWithValue("@sender_id", tgid);
        cmd.Parameters.AddWithValue("@receiver_id", TID);
        cmd.Parameters.AddWithValue("@message_date", message_date);
        cmd.Parameters.AddWithValue("@message", message);
        cmd.ExecuteNonQuery();
        con.Close();
    }
                                  
    public int getLatestMessageID(String sender_id, String receiver_id, String booking_id, String sender_type, String receiver_type)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
       
        sql = "SELECT MAX(message_id) FROM Message WHERE booking_id = @booking_id AND sender_id = @sender_id AND sender_type = @sender_type AND receiver_id = @receiver_id AND receiver_type = @receiver_type";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("@booking_id", booking_id);
        cmd.Parameters.AddWithValue("@sender_id", sender_id);
        cmd.Parameters.AddWithValue("@sender_type", sender_type);
        cmd.Parameters.AddWithValue("@receiver_id", receiver_id);
        cmd.Parameters.AddWithValue("@receiver_type", receiver_type);

       
        Int32 count = 0;

        try
        {
            count = (Int32)cmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            count = -1;
        }
        
        con.Close();

        return count;
    }

    public String getCorrespondence(int maxID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
       
        sql = "SELECT message FROM Message WHERE message_id = @maxID"; 
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("@maxID", maxID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["message"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }
}
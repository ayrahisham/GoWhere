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
}
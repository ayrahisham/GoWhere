using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Tour
/// </summary>
public class Tour
{
    // private variables
    private int tour_id;
    private int TGID; // foreign key
    private String tour_name;
    private String tour_type;
    private String city_country;
    private DateTime date_start; // new DateTime(yyyy, mm, dd); 
    private DateTime date_end;  // .Year .Month .Day
    private String tour_desc;
    private double price;
    private String tour_status;

    public Tour()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private void getTourInfo(int tour_id)
    {

    }

    private void updateTourInfo()
    {

    }

    private void filterTour()
    {

    }

    public String getTourByTRID(String TRID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT * FROM Tour WHERE tour_id = ?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TRID);
        
        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TGID"].ToString() + ";" + reader["tour_name"].ToString() + ";" + reader["tour_type"].ToString() + ";" + reader["city_country"].ToString() + ";" + reader["date_start"].ToString() + ";" + reader["date_end"].ToString() + ";" + reader["tour_desc"].ToString() + ";" + reader["price"].ToString() + ";" + reader["tour_status"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String ViewUpcomingTours()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT tour_id, tour_name, date_start FROM Tour WHERE TGID=? AND tour_status=status";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.TGID);
        cmd.Parameters.AddWithValue("status", "Upcoming");

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["tour_name"].ToString() + ";" + reader["date_start"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String ViewTourInfo(String tourID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT date_start, date_end, tour_status, tour_name, tour_desc, tour_type, city_country FROM Tour WHERE tour_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tourID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["date_start"].ToString() + ";" + reader["date_end"].ToString() + ";"
                 + reader["tour_status"].ToString() + ";" + reader["tour_name"].ToString() + ";"
                 + reader["tour_desc"].ToString() + ";" + reader["tour_type"].ToString() + ";"
                 + reader["city_country"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String viewTourHistoryList()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, tour_name FROM Tour WHERE TGID=? AND tour_status=status";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.TGID);
        cmd.Parameters.AddWithValue("status", "Completed");

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + reader["tour_name"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getToursByTG()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id FROM Tour WHERE TGID=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.TGID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getTourInfoForUpdate(String tourID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT date_start, date_end, tour_status, tour_name, tour_desc, price, tour_type, city_country FROM Tour WHERE tour_id=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tourID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["date_start"].ToString() + ";" + reader["date_end"].ToString() + ";" + reader["tour_status"].ToString() + ";"
                + reader["tour_name"].ToString() + ";" + reader["tour_desc"].ToString() + ";" + reader["price"].ToString() + ";"
                + reader["tour_type"].ToString() + ";" + reader["city_country"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }
}
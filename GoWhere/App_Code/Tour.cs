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
            str += reader["TGID"].ToString() + ";" + reader["tour_name"].ToString() + ";" + reader["tour_type"].ToString() + ";" + reader["city_country"].ToString() + ";" + (Convert.ToDateTime(reader["date_start"]).ToShortDateString()).ToString() + ";" + (Convert.ToDateTime(reader["date_end"]).ToShortDateString()).ToString() + ";" + reader["tour_desc"].ToString() + ";" + reader["price"].ToString() + ";" + reader["tour_status"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String ViewUpcomingTours(String TGID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT tour_id, tour_name, date_start FROM Tour WHERE TGID=? AND tour_status=status";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TGID);
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

    public String viewTourHistoryList(String TGID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, tour_name FROM Tour WHERE TGID=? AND tour_status=status";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TGID);
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

    public String viewUpcoming_Tours()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, date_start, tour_type, city_country, tour_status FROM Tour WHERE tour_status=status";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("status", "Upcoming");

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + (Convert.ToDateTime(reader["date_start"]).ToShortDateString()).ToString() + ";" + reader["tour_type"].ToString() + ";" + reader["city_country"].ToString() + ";" + reader["tour_status"].ToString() + ";";
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

    public void create_Tour(String tgid, String tour_name, String tour_type, String city_country, String date_start,
                           String date_end, String tour_desc, String price, String tour_status)
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "INSERT INTO Tour ([TGID], [tour_name], [tour_type], [city_country], [date_start], [date_end], [tour_desc], [price], [tour_status]) " +
                            "VALUES(@TGID, @tour_name, @tour_type, @city_country, @date_start, @date_end, @tour_desc, @price, @tour_status);";
        cmd.Parameters.AddWithValue("@TGID", tgid);
        cmd.Parameters.AddWithValue("@tour_name", tour_name);
        cmd.Parameters.AddWithValue("@tour_type", tour_type);
        cmd.Parameters.AddWithValue("@city_country", city_country);
        cmd.Parameters.AddWithValue("@date_start", date_start);
        cmd.Parameters.AddWithValue("@date_end", date_end);
        cmd.Parameters.AddWithValue("@tour_desc", tour_desc);
        cmd.Parameters.AddWithValue("@price", Convert.ToDouble(price));
        cmd.Parameters.AddWithValue("@tour_status", tour_status);
        cmd.ExecuteNonQuery();
        con.Close();
    }



    public void updateTour(int tour_id, String date_start, String date_end, String tour_status, String tour_name,
                           String tour_desc, String price, String tour_type, String city_country)
    {
        OleDbConnection con = new OleDbConnection();

        string sql = string.Empty;

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        //sql = "UPDATE Tour SET tour_name = @tour_name WHERE tour_id=?";
        OleDbCommand cmd = con.CreateCommand();
        //cmd.Parameters.AddWithValue("?", tour_id);
        //cmd.Parameters.AddWithValue("@tour_name", tour_name);

        cmd.CommandText = "UPDATE Tour SET tour_name = @tour_name, tour_type = @tour_type, city_country = @city_country, " +
             "date_start = @date_start, date_end = @date_end, tour_desc = @tour_desc, price = @price, tour_status = @tour_status WHERE tour_id = @tour_id";
        //cmd.CommandText = "UPDATE Tour SET tour_name = @tour_name, tour_type = @tour_type, city_country = @city_country, date_start = @date_start, date_end = @date_end, tour_desc = @tour_desc, price = @price WHERE tour_id = @tour_id";
        cmd.Parameters.AddWithValue("@tour_name", tour_name);
        cmd.Parameters.AddWithValue("@tour_type", tour_type);
        cmd.Parameters.AddWithValue("@city_country", city_country);
        cmd.Parameters.AddWithValue("@date_start", date_start);
        cmd.Parameters.AddWithValue("@date_end", date_end);
        cmd.Parameters.AddWithValue("@tour_desc", tour_desc);
        cmd.Parameters.AddWithValue("@price", Convert.ToDouble(price));
        cmd.Parameters.AddWithValue("@tour_status", tour_status);
        cmd.Parameters.AddWithValue("@tour_id", tour_id);

        // cmd.CommandText = "UPDATE Tour SET tour_name = @tour_name, tour_type = @tour_type, city_country = @city_country, " +
        //     "date_start = @date_start, date_end = @date_end, tour_desc = @tour_desc, price = @price, tour_status = @tour_status WHERE tour_id = @tour_id";
        //cmd.CommandText = "UPDATE Tour SET tour_name = @tour_name, tour_type = @tour_type, city_country = @city_country, date_start = @date_start, date_end = @date_end, tour_desc = @tour_desc, price = @price WHERE tour_id = @tour_id";
        //cmd.Parameters.AddWithValue("@tour_name", tour_name);
        //cmd.Parameters.AddWithValue("@tour_type", tour_type);
        //cmd.Parameters.AddWithValue("@city_country", city_country);
        //cmd.Parameters.AddWithValue("@date_start", date_start);
        //cmd.Parameters.AddWithValue("@date_end", date_end);
        //cmd.Parameters.AddWithValue("@tour_desc", tour_desc);
        ////cmd.Parameters.AddWithValue("@tour_status", tour_status);
        //cmd.Parameters.AddWithValue("@price", price);
        //cmd.Parameters.AddWithValue("@tour_id", tour_id);

        //cmd.Parameters.AddWithValue("@tour_type", tour_type);
        //cmd.Parameters.AddWithValue("@city_country", "TEST");
        //cmd.Parameters.AddWithValue("@date_start", date_start);
        //cmd.Parameters.AddWithValue("@date_end", date_end);
        //cmd.Parameters.AddWithValue("@tour_desc", tour_desc);
        //cmd.Parameters.AddWithValue("@price", price);
        //cmd.Parameters.AddWithValue("@tour_status", tour_status);

        //OleDbCommand cmd = con.CreateCommand();
        //cmd.CommandText = "UPDATE Tour SET tour_name = @tour_name WHERE tour_id=?";
        //cmd.Parameters.AddWithValue("?", tour_id);
        //cmd.Parameters.AddWithValue("@tour_name", tour_name);
        //cmd.Parameters.Add("@tour_name", OleDbType.Char).Value = tour_name;

        //cmd.CommandText = "UPDATE Tour SET tour_status = @tour_status, tour_name = @tour_name, " +
        //                  "tour_desc = @tour_desc, price = @price, tour_type = @tour_type, city_country = @city_country Where tour_id=102";
        //cmd.Parameters.AddWithValue("@date_start", date_start);
        //cmd.Parameters.AddWithValue("@date_end", date_end);
        //cmd.Parameters.AddWithValue("@tour_status", tour_status);
        //cmd.Parameters.AddWithValue("@tour_name", tour_name);
        //cmd.Parameters.AddWithValue("@tour_desc", tour_desc);
        //cmd.Parameters.AddWithValue("@price", price);
        //cmd.Parameters.AddWithValue("@tour_type", tour_type);
        //cmd.Parameters.AddWithValue("@city_country", city_country);
        //cmd.Parameters.AddWithValue("@tour_id", tour_id);

        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void testUpdate(String tour_name)
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "UPDATE Tour SET tour_name =? WHERE tour_id=122";
        cmd.Parameters.AddWithValue("?", tour_name);

        cmd.ExecuteNonQuery();
        con.Close();
    }

    public String getTourID_completed(String tgid)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        //select tourid from tour where tgid = tgid and status = completed--TOUR TABLE
        sql = "SELECT tour_id FROM Tour WHERE tgid=? AND tour_status=status";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", tgid);
        cmd.Parameters.AddWithValue("status", "Completed");

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

    public String getTourDistinctDates()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT DISTINCT date_start FROM TOUR where tour_status = @status";

        OleDbCommand cmd = new OleDbCommand(sql, con);

        cmd.Parameters.AddWithValue("@status", "Upcoming");

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += (Convert.ToDateTime(reader["date_start"]).ToShortDateString()).ToString() + ";";
        }

        reader.Close();
        con.Close();

        return str;
    }

    public String getToursByDate(string date)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, date_start, tour_type, city_country, tour_status FROM Tour WHERE date_start = @date";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("@date", date);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + (Convert.ToDateTime(reader["date_start"]).ToShortDateString()).ToString() + ";" + reader["tour_type"].ToString() + ";" + reader["city_country"].ToString() + ";" + reader["tour_status"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

}
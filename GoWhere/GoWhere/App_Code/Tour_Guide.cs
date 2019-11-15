using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for TourGuide
/// </summary>
public class Tour_Guide : User
{
    // private variables
    private int TGID;
    private String last_name;
    private String first_name;
    private String email;
    private String country;
    private bool suspended;

    public Tour_Guide(String user)
    {
        this.user = user;
    }

    public Tour_Guide(String user, String pass)
    {
        this.user = user;
        this.pass = pass;
    }

    public Tour_Guide(String user, String pass, String first_name, String last_name, String email, String country)
    {
        this.user = user;
        this.pass = pass;
        this.last_name = last_name;
        this.first_name = first_name;
        this.email = email;
        this.country = country;
    }

    public String getTGID()
    {
        return this.TGID.ToString();
    }

    // login.aspx - check if TG account exists
    public int validate_TG()
    {
        bool check = false; String sql = ""; int row = 0;
        int num = 0;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT COUNT(*) FROM Tour_Guide WHERE user='" + this.user + "' AND pass='" + this.pass + "' AND suspended=false";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database.
        if (row > 0)
        {
            check = true;
            num = 1;    // user exists and is NOT suspended
            con.Close();
            return num;
        }

        else if (check == false)
        {
            sql = "SELECT COUNT(*) FROM Tour_Guide WHERE user='" + this.user + "' AND pass='" + this.pass + "' AND suspended=true";

            cmd = new OleDbCommand(sql, con);
            row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database.

            if (row > 0)
                num = 2;    // user exists and is suspended
            else
                num = 3;    // user does not exist
        }

        con.Close();
        return num;
    }

    // register.aspx - create a TG account
    public void create_TG()
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "INSERT INTO Tour_Guide ([user], [pass], [last_name], [first_name], [email], [country]) VALUES(@user, @pass, @lName, @fName, @email, @country);";
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@pass", pass);
        cmd.Parameters.AddWithValue("@lName", last_name);
        cmd.Parameters.AddWithValue("@fName", first_name);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@country", country);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // viewTG.aspx - View TG profile
    public String view_profile()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT Tour_Guide.* FROM Tour_Guide WHERE user=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.user);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            this.TGID = int.Parse(reader["TGID"].ToString());

            str += reader["first_name"].ToString() + ";" + reader["last_name"].ToString() + ";"
                    + reader["email"].ToString() + ";" + reader["country"].ToString();
        }

        reader.Close();
        con.Close();

        return str;
    }

    public void setInfo()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT Tour_Guide.* FROM Tour_Guide WHERE user=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.user);

        OleDbDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            this.TGID = int.Parse(reader["TGID"].ToString());
            this.first_name = reader["first_name"].ToString();
            this.last_name = reader["last_name"].ToString();
            this.email = reader["email"].ToString();
            this.country = reader["country"].ToString();
        }

        reader.Close();
        con.Close();

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

    public String queryTourist(String TID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT TID, first_name, email FROM Tourist WHERE TID=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TID"].ToString() + ";" + reader["first_name"].ToString() + ";" + reader["email"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String viewTourist(String TID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT TID, first_name, last_name, email, country FROM Tourist WHERE TID=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TID"].ToString() + ";" + reader["first_name"].ToString() + ";" + reader["last_name"].ToString() + ";"
                + reader["email"].ToString() + ";" + reader["country"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String viewTourHistory()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT TID, first_name, last_name, email, country FROM Tourist WHERE TID=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.TGID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TID"].ToString() + ";" + reader["first_name"].ToString() + ";" + reader["last_name"].ToString() + ";"
                + reader["email"].ToString() + ";" + reader["country"].ToString() + ";";
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

    public String getTouristName(String TID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT TID, first_name, last_name FROM Tourist WHERE TID=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TID);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TID"].ToString() + ";" + reader["first_name"].ToString() + ";" + reader["last_name"].ToString() + ";";
        }
        reader.Close();
        con.Close();

        return str;
    }

    public String getFeedbackToTourists()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, receiver_id, message FROM Message WHERE sender_type=? AND sender_id=TGID";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", "TG");
        cmd.Parameters.AddWithValue("TGID", this.TGID);


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

    public String getFeedbackFromTourists()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT tour_id, sender_id, message FROM Message WHERE sender_type=? AND receiver_id=TGID";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", "TR");
        cmd.Parameters.AddWithValue("TGID", this.TGID);


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

    public void create_Tour(String tour_name, String tour_type, String city_country, String date_start, 
                            String date_end, String tour_desc, String price, String tour_status)
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "INSERT INTO Tour ([TGID], [tour_name], [tour_type], [city_country], [date_start], [date_end], [tour_desc], [price], [tour_status]) " +
                            "VALUES(@TGID, @tour_name, @tour_type, @city_country, @date_start, @date_end, @tour_desc, @price, @tour_status);";
        cmd.Parameters.AddWithValue("@TGID", this.TGID);
        cmd.Parameters.AddWithValue("@tour_name", tour_name);
        cmd.Parameters.AddWithValue("@tour_type", tour_type);
        cmd.Parameters.AddWithValue("@city_country", city_country);
        cmd.Parameters.AddWithValue("@date_start", date_start);
        cmd.Parameters.AddWithValue("@date_end", date_end);
        cmd.Parameters.AddWithValue("@tour_desc", tour_desc);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@tour_status", tour_status);
        cmd.ExecuteNonQuery();
        con.Close();
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

    public void updateTour(String tour_id, String date_start, String date_end, String tour_status, String tour_name, 
                           String tour_desc, String price, String tour_type, String city_country)
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();
        //cmd.CommandText = "UPDATE Tour SET tour_name = @tour_name, tour_type = @tour_type, city_country = @city_country, date_start = @date_start," +
        //                    "date_end = @date_end, tour_desc = @tour_desc, price = @price WHERE tour_id=?";
        cmd.CommandText = "UPDATE Tour SET tour_name = @tour_name WHERE tour_id =?";
        
        
        
        cmd.Parameters.AddWithValue("?", tour_id);
        //cmd.Parameters.Add("@tour_id", OleDbType.Char).Value = tour_id;
        cmd.Parameters.Add("@tour_name", OleDbType.Char).Value = tour_name;
        //cmd.Parameters.Add("@tour_type", OleDbType.Char).Value = tour_type;
        //cmd.Parameters.Add("@city_country", OleDbType.Char).Value = city_country;
        //cmd.Parameters.Add("@date_start", OleDbType.Char).Value = date_start;
        //cmd.Parameters.Add("@date_end", OleDbType.Char).Value = date_end;
        //cmd.Parameters.Add("@tour_desc", OleDbType.Char).Value = tour_desc;
        //cmd.Parameters.Add("@price", OleDbType.Char).Value = price;





        //cmd.Parameters.Add("@tour_id", OleDbType.Char).Value = tour_id;
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


}
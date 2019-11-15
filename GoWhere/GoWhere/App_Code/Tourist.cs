using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Tourist
/// </summary>
public class Tourist : User
{
    // private variables
    private int TID;
    private String last_name;
    private String first_name;
    private String email;
    private String country;
    private bool suspended;

    public Tourist()
    {

    }

    public Tourist(String user)
    {
        this.user = user;
    }

    public Tourist(String user, String pass)
    {
        this.user = user;
        this.pass = pass;
    }

    public Tourist(String user, String pass, String last_name, String first_name, String email, String country)
    {
        this.user = user;
        this.pass = pass;
        this.last_name = last_name;
        this.first_name = first_name;
        this.email = email;
        this.country = country;
    }

    // login.aspx - check if a TR account exists
    public int validate_TR()
    {
        bool check = false; String sql = ""; int row = 0;
        int num = 0;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT COUNT(*) FROM Tourist WHERE user='" + this.user + "' AND pass='" + this.pass + "' AND suspended=false";

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
            sql = "SELECT COUNT(*) FROM Tourist WHERE user='" + this.user + "' AND pass='" + this.pass + "' AND suspended=true";

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

    // register.aspx - create a TR account
    public void create_TR()
    {
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "INSERT INTO Tourist ([user], [pass], [last_name], [first_name], [email], [country]) VALUES(@user, @pass, @lName, @fName, @email, @country);";
        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@pass", pass);
        cmd.Parameters.AddWithValue("@lName", last_name);
        cmd.Parameters.AddWithValue("@fName", first_name);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@country", country);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // viewT.aspx - TR views list of tours
    public String view_Tours()
    {
        string sql = "";
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT Tour.* FROM Tour WHERE date_start >= DATE()";
        OleDbCommand cmd = new OleDbCommand(sql, con);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["tour_id"].ToString() + ";" + (Convert.ToDateTime(reader["date_start"]).ToShortDateString()).ToString() + ";" + reader["tour_type"].ToString() + ";"
                    + reader["city_country"].ToString() + ";" + reader["tour_status"].ToString() + ";";
        }

        reader.Close();
        con.Close();

        return str;
    }

    // viewTG.aspx - View TR profile
    public String view_profile()
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT Tourist.* FROM Tourist WHERE user=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.user);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["first_name"].ToString() + ";" + reader["last_name"].ToString() + ";"
                    + reader["email"].ToString() + ";" + reader["country"].ToString();
        }

        reader.Close();
        con.Close();

        return str;
    }

    private void getTouristInfo(int TID)
    {

    }

    private void getTouristInfoByBookID(int booking_id)
    {

    }

    public string viewUpcomingToursTR()
    {

        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        // connection open 
        con.Open();

        sql = "SELECT TID FROM Tourist WHERE user=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.user);

        OleDbDataReader reader = cmd.ExecuteReader();
        String TID_str = "";

        while (reader.Read())
        {
            TID_str += reader["TID"].ToString();
        }

        reader.Close();
        con.Close();

        Booking b = new Booking();
        string output = b.getUpcomingBookingsByTID(TID_str);

        return output;

    }

    public string getTIDbyUsername()
    {
        string sql = string.Empty;

        OleDbConnection con = new OleDbConnection();
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open();

        sql = "SELECT TID from Tourist WHERE user = ?";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.user);

        OleDbDataReader reader = cmd.ExecuteReader();

        string output = "";

        while (reader.Read())
        {
            output = reader["TID"].ToString();
        }


        return output;

    }

    public string viewCompletedToursTR()
    {

        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        // connection open 
        con.Open();

        sql = "SELECT TID FROM Tourist WHERE user=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", this.user);

        OleDbDataReader reader = cmd.ExecuteReader();
        String TID_str = "";

        while (reader.Read())
        {
            TID_str += reader["TID"].ToString();
        }

        reader.Close();
        con.Close();

        Booking b = new Booking();
        string output = b.getCompletedBookingsByTID(TID_str);

        return output;

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

    public String viewTourHistory(String TGID)
    {
        string sql = string.Empty;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 
        sql = "SELECT TID, first_name, last_name, email, country FROM Tourist WHERE TID=?";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("?", TGID);

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

}
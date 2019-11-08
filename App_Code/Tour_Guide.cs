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

    // login.aspx - check if TG account exists
    public bool validate_TG()
    {
        bool check = false; String sql = ""; int row = 0;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT COUNT(*) FROM Tour_Guide WHERE user='" + this.user + "' AND pass='" + this.pass + "' AND suspended=false";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database.
        if (row > 0)
            check = true;
        con.Close();
        return check;
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
            str += reader["first_name"].ToString() + ";" + reader["last_name"].ToString() + ";"
                    + reader["email"].ToString() + ";" + reader["country"].ToString();
        }

        reader.Close();
        con.Close();

        return str;
    }
}
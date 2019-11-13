using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for UserAdmin
/// </summary>
public class User_Admin : User
{
    // private variables
    private int user_admin_id;

    public User_Admin() { }

    public User_Admin(String user)
    {
        this.user = user;
    }

    public User_Admin(String user, String pass)
    {
        this.user = user;
        this.pass = pass;
    }

    // login.aspx - check if UA account exists
    public bool validate_UA()
    {
        bool check = false; String sql = ""; int row=0;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT COUNT(*) FROM User_Admin WHERE user='" + this.user + "' AND pass='" + this.pass + "'";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database.
        if (row > 0)
            check = true;
        con.Close();
        return check;
    }

    // viewUA.aspx - User admin views all TR/TG accounts
    public String view_Users()
    {
        string sql = "";
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT Tour_Guide.TGID, Tourist.TID, Tour_Guide.user, Tour_Guide.suspended FROM Tour_Guide INNER JOIN Tourist ON(Tour_Guide.suspended = Tourist.suspended) AND(Tour_Guide.pass = Tourist.pass) AND(Tour_Guide.user = Tourist.user);";
        OleDbCommand cmd = new OleDbCommand(sql, con);

        OleDbDataReader reader = cmd.ExecuteReader();

        String str = "";

        while (reader.Read())
        {
            str += reader["TGID"].ToString() + ";" + reader["TID"].ToString() + ";" + reader["user"].ToString() + ";";
            if (Convert.ToBoolean(reader["suspended"]) == true)
            {
                str += "true;";
            }
            else
            {
                str += "false;";
            }
        }

        reader.Close();
        con.Close();

        return str;
    }

    // suspendUA.aspx - User admin suspends a TR/TG account
    public bool suspend_user(String uName)
    {
        string sql = ""; int row = 0; bool suspended = false;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT COUNT(*) FROM Tour_Guide WHERE user='" + uName + "'";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database.

        OleDbDataReader reader = cmd.ExecuteReader();

        if (row > 0)
        {
            // suspend TG account
            sql = "UPDATE Tour_Guide SET [suspended]=? WHERE user=?";
            cmd = new OleDbCommand(sql, con);
            cmd.Parameters.AddWithValue("?", true);
            cmd.Parameters.AddWithValue("?", uName);
            cmd.ExecuteNonQuery();

            // suspend TR account
            sql = "UPDATE Tourist SET [suspended]=? WHERE user=?";
            cmd = new OleDbCommand(sql, con);
            cmd.Parameters.AddWithValue("?", true);
            cmd.Parameters.AddWithValue("?", uName);
            cmd.ExecuteNonQuery();

            sql = "UPDATE Tour SET [tour_status]='Suspended' WHERE TGID=(SELECT TGID FROM Tour_Guide WHERE user=?)";
            cmd = new OleDbCommand(sql, con);
            cmd.Parameters.AddWithValue("?", uName);
            cmd.ExecuteNonQuery();

            suspended = true;
        }
        reader.Close();
        con.Close();
        return suspended;
    }
}
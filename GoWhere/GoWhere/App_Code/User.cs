using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for User
/// consists of Tour_Guide, Tourist, and User_Admin
/// </summary>

public class User
{
    protected String user;
    protected String pass;

    public User() { }

    public User(String user, String pass)
    {
        this.user = user;
        this.pass = pass;
    }

    public bool check_username(String user)
    {
        bool check = false; String sql = ""; int row = 0;
        OleDbConnection con = new OleDbConnection();

        // establish connection  
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/GoWhere/App_Data/Database.mdb");
        con.Open(); // connection open 

        sql = "SELECT COUNT(*) FROM Tour_Guide WHERE user='" + this.user + "'";

        OleDbCommand cmd = new OleDbCommand(sql, con);
        row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database.
        if (row > 0)
            check = true;
        return check;
    }
}
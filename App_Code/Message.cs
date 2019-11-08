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
}
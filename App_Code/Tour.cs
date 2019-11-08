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
}
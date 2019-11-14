using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class viewRFTR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tour_Guide tg = new Tour_Guide(Session["username"].ToString());
        tg.setInfo();

        String reader = tg.getToursByTG(); // tourIDs given by TG
        String[] readerArr = reader.Split(';');
        Array.Resize(ref readerArr, readerArr.Length - 1);

        for (int i = 0; i < readerArr.Length; i++)
        {
            String tourID = readerArr[i];
            String ratings = tg.getRatingsFromTourist(tourID); // tourID, TID, rating
            if (ratings.Length != 0)
            {
                String[] ratingsArr = ratings.Split(';');
                Array.Resize(ref ratingsArr, ratingsArr.Length - 1);

                TableRow detailsRow = new TableRow();
                TableCell tourIDCell = new TableCell();
                tourIDCell.Text = ratingsArr[0].ToString();
                detailsRow.Cells.Add(tourIDCell);

                TableCell tidCell = new TableCell();
                tidCell.Text = ratingsArr[1].ToString();
                detailsRow.Cells.Add(tidCell);

                TableCell countCell = new TableCell();
                countCell.Text = ratingsArr[2].ToString();
                detailsRow.Cells.Add(countCell);

                viewRFTRTable.Rows.Add(detailsRow);
            }

        }
        //getRatingsFromTourist(String tourID)

    }
}
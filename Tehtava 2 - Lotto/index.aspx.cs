using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebForm1 : System.Web.UI.Page
{
    BLLotto blotto = new BLLotto();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (rivit.Items.Count == 0)
        {
            for (int i = 1; i < 11; i++)
            {
                rivit.Items.Add(new ListItem(Convert.ToString(i)));
            }
        }
    }

    protected void haeRivit_Click(object sender, EventArgs e)
    {
        if (tyyppi.SelectedValue == "Lotto")
        {
            blotto.ArvoRivi(1, Convert.ToInt32(rivit.SelectedValue));
            foreach (var list in blotto.drawnNumbers)
            {
                foreach (var number in list)
                {
                    showResults.Text = showResults.Text + " " + number;
                }
                showResults.Text = showResults.Text + "<br />";
            }

        }
        else if (tyyppi.SelectedValue == "ViikingLotto")
        {
            blotto.ArvoRivi(2, Convert.ToInt32(rivit.SelectedValue));
            foreach (var list in blotto.drawnNumbers)
            {
                foreach (var number in list)
                {
                    showResults.Text = showResults.Text + " " + number;
                }
                showResults.Text = showResults.Text + "<br />";
            }
        }
    }
}
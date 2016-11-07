using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnLaske_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            double leveys = Convert.ToDouble(txtLeveys.Text);
            double korkeus = Convert.ToDouble(txtKorkeus.Text);
            double karminLeveys = Convert.ToDouble(txtKarminLeveys.Text);
            double pintaAla = (korkeus / 100) * (leveys / 100); //neliömetreinä
            double piiri = (leveys * 2 / 100 + korkeus * 2 / 100);
            double kate = Convert.ToDouble(ConfigurationManager.AppSettings["kate"]) / 100;
            double nelioHinta = Convert.ToDouble(ConfigurationManager.AppSettings["nelioHinta"]);
            double alumiininHinta = Convert.ToDouble(ConfigurationManager.AppSettings["alumiininHinta"]);
            double tyomenekki = Convert.ToDouble(ConfigurationManager.AppSettings["tyomenekki"]);

            double hinta = (1 + kate) * ((pintaAla * nelioHinta) + (piiri * alumiininHinta) + tyomenekki);

            lblNaytaPintaAla.Text = Convert.ToString(pintaAla);
            lblNaytaKarminPiiri.Text = Convert.ToString(piiri);
            lblNaytaTarjousHinta.Text = Convert.ToString(hinta);
        }
        catch (Exception)
        {
            lblError.Text = "Input numbers only!";
        }

    }
}
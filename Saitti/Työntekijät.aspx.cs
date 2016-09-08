using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Työntekijät : System.Web.UI.Page
{
    string xmlfilu;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Haetaan web.configista xml-tiedoston nimi
        xmlfilu = ConfigurationManager.AppSettings["xmlfilu"];
        lblMessages.Text = xmlfilu;
    }

    protected void btnHae_Click(object sender, EventArgs e)
    {
        // Haetaan xml-data DataView-olioon, joka kytketään GridView:n
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        ds.ReadXml(Server.MapPath(xmlfilu));
        dt = ds.Tables[0];
        dv = dt.DefaultView;

        gvData.DataSource = dv;
        gvData.DataBind();
    }
}
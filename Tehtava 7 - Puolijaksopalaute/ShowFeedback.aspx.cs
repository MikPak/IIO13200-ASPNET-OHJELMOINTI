using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tehtava_7___Puolijaksopalaute
{
    public partial class ShowFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xml = "App_Data\\data.xml";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            ds.ReadXml(Server.MapPath(xml));
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            gvPalautteet.DataSource = dv;
            gvPalautteet.DataBind();
        }
    }
}
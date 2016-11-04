using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = JAMK.IT.DBDemoxOy.GetDataReal();
        gvMovies2.DataSource = dt;
        gvMovies2.DataBind();
    }
}

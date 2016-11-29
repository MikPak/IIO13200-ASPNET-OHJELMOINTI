using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tehtava_5___Asiakastiedot_EntityFrameworkilla
{
    public partial class index : System.Web.UI.Page
    {
        protected static DemoxOyEntities ctx;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ctx = new DemoxOyEntities();
                Panel1.Visible = false;
                DataTable dt = new DataTable();
                var result = ctx.asiakas.GroupBy(c => c.maa)
                       .Select(grp => grp.FirstOrDefault());
                ddlCountries.DataSource = result.ToList();
                ddlCountries.DataTextField = "maa";
                ddlCountries.DataBind();
            }
        }

        protected void btnHaeKaikki_Click(object sender, EventArgs e)
        {
            gvAsiakkaat.DataSource = ctx.asiakas.ToList();
            gvAsiakkaat.DataBind();
            gvAsiakkaat.Visible = true;
        }

        protected void btnHaeMaasta_Click(object sender, EventArgs e)
        {
            gvAsiakkaat.Visible = true;
            lblMessages.Text = "";
            string cid;
            cid = ddlCountries.SelectedValue;
            // haetaan valittu asiakas
            var result = from c in ctx.asiakas where c.maa == cid select c;

            gvAsiakkaat.DataSource = result.ToList();
            gvAsiakkaat.DataBind();

        }

        protected void btnHaeMaittain_Click(object sender, EventArgs e)
        {
            lblMessages.Text = "";
            gvAsiakkaat.Visible = false;
            DataTable dt = new DataTable();
            string maa = "";
            var result = from c in ctx.asiakas orderby c.maa select new { c.maa, c.asnimi, c.yhteyshlo };
            foreach (var item in result)
            {
                if (maa != item.maa)
                {
                    lblMessages.Text += string.Format("<h1> {0} </h1> {1} {2} <br>", item.maa, item.asnimi, item.yhteyshlo);
                }
                else if (maa == item.maa)
                {
                    lblMessages.Text += string.Format("{0} {1} <br>", item.asnimi, item.yhteyshlo);
                }
                maa = item.maa;
            }
        }

        protected void btnLuo_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            gvAsiakkaat.Visible = false;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            bool isThere = ctx.asiakas.Any(c => (c.astunnus.Contains(txtAsTunnus.Text) | c.asnimi.Contains(txtAsNimi.Text)));
            if (isThere)
            {
                lblMessages.Text = string.Format("Asiakas {0} tai {1} on jo olemassa", txtAsNimi.Text, txtAsTunnus.Text);
            }
            else
            {
                //luodaan kontekstiin uusi asiakas entiteetti
                try
                {
                    asiakas cus = new asiakas();
                    cus.asnimi = txtAsNimi.Text;
                    cus.astunnus = txtAsTunnus.Text;
                    cus.asvuosi = Convert.ToInt16(txtAsVuosi.Text);
                    cus.ostot = Convert.ToInt16(txtOstot.Text);
                    cus.maa = txtMaa.Text;
                    cus.postinro = txtPostiNro.Text;
                    cus.postitmp = txtPostiTmp.Text;
                    cus.yhteyshlo = txtAsYhtHlo.Text;
                    ctx.asiakas.Add(cus);
                    ctx.SaveChanges();
                    lblMessages.Text = string.Format("uusi asiakas {0} luotu onnistuneesti", cus.asnimi);
                }
                catch (Exception)
                {

                }

            }
            Panel1.Visible = false;
            gvAsiakkaat.Visible = true;
        }
    }
}
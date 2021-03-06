﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Tehtava_6___LevykauppaX
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Read("LevykauppaX.xml");
        }

        public void Read(string fileName)
        {
            XDocument doc = XDocument.Load(Server.MapPath(fileName));

            foreach (XElement el in doc.Root.Elements())
            {
                string ISBN, artist, title, price;
                ISBN = artist = title = price = string.Empty;
                foreach (XElement element in el.Elements())
                {
                    foreach (XAttribute attr in element.Attributes())
                    {
                        if (attr.Name == "ISBN")
                        {
                            ISBN = attr.Value;
                        }
                        else if (attr.Name == "Artist")
                        {
                            artist = attr.Value;
                        }
                        else if (attr.Name == "Title")
                        {
                            title = attr.Value;
                        }
                        else if (attr.Name == "Price")
                        {
                            price = attr.Value;

                            var cph = (ContentPlaceHolder)Master.FindControl("MainContent");

                            /* Title */
                            HtmlGenericControl titleH2 = new HtmlGenericControl("h2");
                            titleH2.InnerText = artist + " : " + title;
                            cph.FindControl("foo_bar").Controls.Add(titleH2);

                            /* Kansi */
                            HtmlGenericControl imgDiv = new HtmlGenericControl("div");
                            Image myImg = new Image();
                            myImg.ImageUrl = "~/Images/" + ISBN + ".jpg";
                            myImg.Visible = true;
                            imgDiv.Controls.Add(myImg);
                            cph.FindControl("foo_bar").Controls.Add(imgDiv);

                            /* ISBN */
                            HyperLink hyp = new HyperLink();
                            hyp.Text = ISBN;
                            hyp.ID = ISBN;
                            hyp.NavigateUrl = "LevynTiedot.aspx?ISBN="+ISBN;

                            HtmlGenericControl ISBNp = new HtmlGenericControl("p");
                            ISBNp.InnerText = "ISBN: ";
                            cph.FindControl("foo_bar").Controls.Add(ISBNp);
                            ISBNp.Controls.Add(hyp);

                            /* Hinta */
                            HtmlGenericControl hintap = new HtmlGenericControl("p");
                            hintap.InnerText = "Hinta: " + price;
                            cph.FindControl("foo_bar").Controls.Add(hintap);
                        }
                    }
                }
            }
        }
    }
}
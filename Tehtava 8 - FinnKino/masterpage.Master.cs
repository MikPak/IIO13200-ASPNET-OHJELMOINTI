using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace Tehtava_8___FinnKino
{
    public partial class masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TheatersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday); // Get starting date of current week
            //Debug.WriteLine(TheatersListBox.SelectedValue + " - " + dt.ToString("dd.MM.yyy"));
            ParseShows("http://www.finnkino.fi/xml/Schedule/?area="
            + TheatersListBox.SelectedValue + "&dt="
            + dt.ToString("dd.MM.yyy")
            + "&nrOfDays=7");
        }

        public void ParseShows(string xmlUrl)
        {
            ContentPlaceHolder cph = MainContent;
            XmlDocument xdoc = new XmlDocument(); //xml doc used for xml parsing
            xdoc.Load(xmlUrl); //loading XML in xml doc

            XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("/Schedule/Shows/Show"); //reading node so that we can traverse thorugh the XML

            if (xNodelst != null)
            {
                foreach (XmlNode xNode in xNodelst)//traversing XML 
                {
                    if (xNode != null)
                    {
                        XmlNodeList xNodelst2 = xNode.SelectNodes("Images");
                        foreach (XmlNode xNode2 in xNodelst2)//traversing XML 
                        {
                            if (xNode2 != null)
                            {
                                try
                                {
                                    string portraitURL = xNode2.SelectSingleNode("EventMediumImagePortrait").InnerText;
                                    if (portraitURL != null)
                                    {
                                        Image img = new Image();
                                        img.ImageUrl = portraitURL;
                                        img.AlternateText = "";
                                        cph.FindControl("MainContentDiv").Controls.Add(img);
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                //Debug.WriteLine(portraitURL);
                            }
                        }
                    }
                }
            }
        }
    }
}
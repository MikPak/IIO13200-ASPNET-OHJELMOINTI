using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Tehtava_8___FinnKino
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ParseTheaters("http://www.finnkino.fi/xml/TheatreAreas/");
        }

        /*
         * Parse Theaters-data from xml url and populate dropdownlist
         */
        public void ParseTheaters(string xmlUrl) {
            ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("LeftMenu");
            ListBox theatersListBox = (ListBox)cph.FindControl("TheatersListBox");

            if (theatersListBox.Items.Count == 0)
            {

                XmlDocument xdoc = new XmlDocument(); //xml doc used for xml parsing
                xdoc.Load(xmlUrl); //loading XML in xml doc

                XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("/TheatreAreas/TheatreArea"); //reading node so that we can traverse thorugh the XML

                foreach (XmlNode xNode in xNodelst)//traversing XML 
                {
                    if (xNode != null)
                    {
                        string id = xNode.SelectSingleNode("ID").InnerText;
                        string name = xNode.SelectSingleNode("Name").InnerText;

                        if (theatersListBox != null)
                        {
                            //Debug.WriteLine(id + " - " + name);
                            theatersListBox.Items.Add(new ListItem(name, id));

                        }
                        //Debug.WriteLine(id + " - " + name);
                    }
                }
                //theatersListBox.SelectedIndex = theatersListBox.Items.IndexOf(theatersListBox.Items.FindByText("Valitse alue/teatteri")); // Set selectedIndex for dropdown list
            }
        }
    }
}
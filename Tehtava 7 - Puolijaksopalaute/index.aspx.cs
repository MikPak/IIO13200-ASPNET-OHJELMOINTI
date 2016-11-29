using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Tehtava_7___Puolijaksopalaute
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pvm.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        protected void SendFeedback_Click(object sender, EventArgs e)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.Indent = true;
            string path = Server.MapPath("~/App_Data") + "/data.xml";
            if (File.Exists(path) == false)
            {
                using (XmlWriter writer = XmlWriter.Create(path, xmlWriterSettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Palautteet");
                    writer.WriteStartElement("Palaute");

                    writer.WriteElementString("pvm", Pvm.Text);   // <-- These are new
                    writer.WriteElementString("tekija", Nimi.Text);
                    writer.WriteElementString("opittu", Opittu.Text);
                    writer.WriteElementString("haluanoppia", HaluanOppia.Text);
                    writer.WriteElementString("hyvaa", Hyvaa.Text);
                    writer.WriteElementString("parannettavaa", Parannettavaa.Text);
                    writer.WriteElementString("muuta", Muuta.Text);

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                    userMessage.Text = "Palaute lähetetty onnistuneesti.";
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load(path);
                XElement root = xDocument.Element("Palautteet");
                IEnumerable<XElement> rows = root.Descendants("Palaute");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                   new XElement("Palaute",
                   new XElement("pvm", Pvm.Text),
                   new XElement("tekija", Nimi.Text),
                   new XElement("opittu", Opittu.Text),
                   new XElement("haluanoppia", HaluanOppia.Text),
                   new XElement("hyvaa", Hyvaa.Text),
                   new XElement("parannettavaa", Parannettavaa.Text),
                   new XElement("muuta", (Muuta.Text))));
                xDocument.Save(path);
                userMessage.Text = "Palaute lähetetty onnistuneesti.";
            }
        }

        protected void SendFeedBackMySQL_Click(object sender, EventArgs e)
        {
            string opintojakso = "IIO13200";
            string ConnString = ConfigurationManager.ConnectionStrings["Mysql"].ConnectionString;
            string insert = "Insert into palaute(opintojakso, tekija, opittu, haluanoppia, hyvaa, parannettavaa, muuta, pvm) values('" + opintojakso + "','" + Nimi.Text + "','" + Opittu.Text + "','" + HaluanOppia.Text +
                "','" + Hyvaa.Text + "','" + Parannettavaa.Text + "','" + Muuta.Text + "','" + Pvm.Text + "')";

            try
            {
                MySqlConnection conn = new MySqlConnection(ConnString);
                MySqlCommand MyCommand = new MySqlCommand(insert, conn);
                MySqlDataReader MyReader;
                conn.Open();
                MyReader = MyCommand.ExecuteReader();
                conn.Close();
                userMessage.Text = "Palaute lähetetty onnistuneesti.";
            }
            catch (Exception ex)
            {
                userMessage.Text = ex.Message;
            }

        }
    }
}
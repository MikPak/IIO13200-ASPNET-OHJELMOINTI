using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kalenteri : System.Web.UI.Page
{
    DateTime currentDate;
    DateTime selectedDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            currentDate = DateTime.Today;
            lblThisDate.Text = "Tänään on: " + currentDate.ToString("d");
        }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        currentDate = DateTime.Today;
        selectedDate = Calendar1.SelectedDate;
        TimeSpan result = selectedDate - currentDate;

        int years = Convert.ToInt16(result.Days / 365);
        int months = Convert.ToInt16((result.Days % 365) / 30);
        int days = Convert.ToInt16((result.Days % 365) % 30);

        lblThisDate.Text = "Tänään on: " + currentDate.ToString("d");
        lblSelectedDate.Text = selectedDate.ToString("d");

        lblShow.Text = Convert.ToString(years) + " Vuotta, " + Convert.ToString(months) + " Kuukautta, " + Convert.ToString(days) + " Päivää";

    }

    protected void decreaseYear_Click(object sender, EventArgs e)
    {
        selectedDate = Calendar1.SelectedDate;
        if (selectedDate.Year <= 1)
        {
            selectedDate = DateTime.Today;
        }
        int day = Convert.ToInt16(selectedDate.Day);
        int month = Convert.ToInt16(selectedDate.Month);
        int year = Convert.ToInt16(selectedDate.Year - 1);
        Calendar1.VisibleDate = new DateTime(year, month, day);
        Calendar1.SelectedDate = new DateTime(year, month, day);
    }

    protected void addYear_Click(object sender, EventArgs e)
    {
        selectedDate = Calendar1.SelectedDate;
        if (selectedDate.Year <= 1)
        {
            selectedDate = DateTime.Today;
        }
        int day = Convert.ToInt16(selectedDate.Day);
        int month = Convert.ToInt16(selectedDate.Month);
        int year = Convert.ToInt16(selectedDate.Year + 1);
        Calendar1.VisibleDate = new DateTime(year, month, day);
        Calendar1.SelectedDate = new DateTime(year, month, day);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Train
{
    public int trainNumber { get; set; }
    public string departureDate { get; set; }
    public int operatorUICCode { get; set; }
    public string operatorShortCode { get; set; }
    public string trainType { get; set; }
    public string trainCategory { get; set; }
    public string commuterLineID { get; set; }
    public bool runningCurrently { get; set; }
    public bool cancelled { get; set; }
    public object version { get; set; }
    public List<TimeTableRow> timeTableRows { get; set; }
}

public class TimeTableRow
{
    public string stationShortCode { get; set; }
    public int stationUICCode { get; set; }
    public string countryCode { get; set; }
    public string type { get; set; }
    public bool trainStopping { get; set; }
    public bool commercialStop { get; set; }
    public string commercialTrack { get; set; }
    public bool cancelled { get; set; }
    public string scheduledTime { get; set; }
    public string actualTime { get; set; }
    public int differenceInMinutes { get; set; }
    public List<object> causes { get; set; }
    public string liveEstimateTime { get; set; }
}

public class ComboboxItem
{
    public string Text { get; set; }
    public object Value { get; set; }

    public override string ToString()
    {
        return Text;
    }
}

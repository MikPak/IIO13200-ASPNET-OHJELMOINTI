using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Harjoitustyo___Ruokapaivakirja.Models;

namespace Harjoitustyo___Ruokapaivakirja.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        /* Saves calendar event to database, returns inserted row id if successful, else -1*/
        [HttpPost]
        public int addEvent(ImproperCalendarEvent improperEvent)
        {
            // FullCalendar 2.x
            CalendarEvent cevent = new CalendarEvent()
            {
                title = improperEvent.title,
                description = improperEvent.description,
                start = Convert.ToDateTime(improperEvent.start).ToUniversalTime(),
                end = Convert.ToDateTime(improperEvent.end).ToUniversalTime(),
                allDay = improperEvent.allDay
            };

            if (CheckAlphaNumeric(cevent.title) && CheckAlphaNumeric(cevent.description))
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.calendarEvent.Add(cevent);
                    //db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    db.SaveChanges();
                    int key = cevent.id;
                    Debug.WriteLine("Lisätty event: " + key);

                    List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];

                    if (idList != null)
                    {
                        idList.Add(key);
                    }

                    return key; //return the primary key of the added cevent object
                }
            }
            return -1; //return a negative number just to signify nothing has been added
        }

        [HttpPost]
        public ActionResult getEvents(long start, long end)
        {
            Debug.WriteLine("called getEvents");
            var epoch = new DateTime(1970, 1, 1);
            var startDate = epoch.AddMilliseconds(start);
            var endDate = epoch.AddMilliseconds(end);

            using (OurDbContext db = new OurDbContext())
            {
                var data = db.calendarEvent
                .Where(i => startDate <= i.start && i.end <= endDate).Take(20).ToList();

                db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                return Json(data);
            }
        }

        private static bool CheckAlphaNumeric(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z0-9 ]*$");
        }
    }
}
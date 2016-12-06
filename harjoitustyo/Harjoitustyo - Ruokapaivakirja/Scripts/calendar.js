$(document).ready(function () {

var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;

function addSuccess(addResult) {
    // if addresult is -1, means event was not added
    alert("added key: " + addResult);

    if (addResult != -1) {
        $('#calendar').fullCalendar('renderEvent',
                        {
                            title: $("#addEventName").val(),
                            start: addStartDate,
                            end: addEndDate,
                            id: addResult,
                            description: $("#addEventDesc").val(),
                            allDay: globalAllDay
                        },
                        true // make the event "stick"
                    );


        $('#calendar').fullCalendar('unselect');
    }
}

function selectDate(start, end, allDay) {

    $('#addDialog').dialog('open');
    $("#addEventStartDate").text("" + start.toLocaleString());
    $("#addEventEndDate").text("" + end.toLocaleString());

    addStartDate = start;
    addEndDate = end;
    globalAllDay = allDay;
    //alert(allDay);
}

function isAllDay(startDate, endDate) {
    var allDay;

    if (startDate.format("HH:mm:ss") == "00:00:00" && endDate.format("HH:mm:ss") == "00:00:00") {
        allDay = true;
        globalAllDay = true;
    }
    else {
        allDay = false;
        globalAllDay = false;
    }

    return allDay;
}

function checkForSpecialChars(stringToCheck) {
    var pattern = /[^A-Za-z0-9 ]/;
    return pattern.test(stringToCheck);
}

//add dialog
$('#addDialog').dialog({
    autoOpen: false,
    width: 470,
    buttons: {
        "Add": function () {
            //alert("sent:" + addStartDate.format("dd-MM-yyyy hh:mm:ss tt") + "==" + addStartDate.toLocaleString());
            var eventToAdd = {
                title: $("#addEventName").val(),
                description: $("#addEventDesc").val(),

                // FullCalendar 2.x
                start: addStartDate.toJSON(),
                end: addEndDate.toJSON(),

                allDay: isAllDay(addStartDate, addEndDate)
            };

            if (checkForSpecialChars(eventToAdd.title) || checkForSpecialChars(eventToAdd.description)) {
                alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
            }
            else {
                //alert("sending " + eventToAdd.title);

                $.ajax({
                    url: '/Calendar/addEvent',
                    type: 'POST',
                    data: eventToAdd,
                    dataType: 'html',
                    success: function (data) { addSuccess(data); },
                    statusCode: {
                        404: function (content) { alert('cannot find resource'); },
                        500: function (content) { alert('internal server error'); }
                    },
                    error: function (req, status, errorObj) {
                        // handle status === "timeout"
                        // handle other errors
                    }
                });
                $(this).dialog("close");
            }
        }
    }
});

var date = new Date();
var d = date.getDate();
var m = date.getMonth();
var y = date.getFullYear();
var options = {
    weekday: "long", year: "numeric", month: "short",
    day: "numeric", hour: "2-digit", minute: "2-digit"
};

$('#calendar').fullCalendar({
    header: {
        left: 'prev,next today',
        center: 'title',
        right: 'month,agendaWeek,agendaDay'
    },
    editable: true,
    selectable: true,
    selectHelper: true,
    select: selectDate,
    events: function (start, end, callback) {
        $.ajax({
            type: "post",
            url: '../../calendar/getEvents?start=' + start + "&end=" + end,
            data: {},
            success: function (doc) {
                $('#calendar').fullCalendar('removeEvents', function (e) { return !e.isUserCreated });
                var events = [];
                events.push(doc);
                //console.log(events);
                //alert(doc[0].title + ' ' + doc[0].start);
                $.each(events[0], function (key, value) {
                    $('#calendar').fullCalendar('renderEvent',
                    {
                        title: doc[key].title,
                        start: doc[key].start,
                        end: doc[key].end,
                        id: doc[key].id,
                        description: doc[key].description,
                        allDay: doc[key].allDay
                    },
                    true // make the event "stick"
                    );
                });
                //alert(events[0].title + ' ' + events[0].start);
            },
            error: function () {
                alert('there was an error while fetching events!');
            }
        });
    }
})


});

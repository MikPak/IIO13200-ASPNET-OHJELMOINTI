$(document).ready(function () {

    // page is now ready, initialize the calendar...

    $('#calendar').fullCalendar({
        // put your options and callbacks here
        dayClick: function (date, jsEvent, view) {
            var title = prompt('Lisää Ruoka:');
            if (title) {
                var randomColor = Math.floor(Math.random() * 16777215).toString(16);
                addCalanderEvent(1, date, date, title, "#" + randomColor);
            }
        }
    })

    function addCalanderEvent(id, start, end, title, colour) {
        var eventObject = {
            title: title,
            start: start,
            end: end,
            id: id,
            color: colour
        };

        $('#calendar').fullCalendar('renderEvent', eventObject, true);
        return eventObject;
    }
});

var offsetMiliseconds = new Date().getTimezoneOffset() * 60000;
var toplevelpanel = "636";
$(document).ready(function () {

    localStorage.pageNumber = 1;
    $('#prev_btn').css('display', 'none');




    $('#next_btn').click(function () {
        localStorage.pageNumber = (parseInt(localStorage.pageNumber)) + 1;

        $('#PageNumber').val(localStorage.pageNumber);
        $("#FilterType").val('other');
        SearchEvents();
        $('#prev_btn').show();
    });

    $('#prev_btn').click(function () {
        localStorage.pageNumber = (parseInt(localStorage.pageNumber)) - 1;
        $("#FilterType").val('other');
        $('#PageNumber').val(localStorage.pageNumber);

        if ((parseInt(localStorage.pageNumber)) === 1) {
            $('#prev_btn').hide();
            $('#next_btn').show();
        }
        SearchEvents();
    });

    if (localStorage.interval === undefined || localStorage.interval === "") {

        localStorage.interval = 1000 * 60 * $('#Interval :selected').val();
    }
    else {
        $("#Interval").val(parseInt(localStorage.interval) / parseInt(1000 * 60 * parseInt(localStorage.selectedInterval)));
    }

    localStorage.selectedCategory = localStorage.selectedCategory === undefined ? "" : localStorage.selectedCategory;

    GetTop5Events();
    intervalfunction();

    $(window).load(function () {
        $('input[name=EventsDate]').val('');
    });

    $('#categories').multiselect({
        includeSelectAllOption: true
    });

    $(".panel-top").resizable({
        handleSelector: ".splitter-horizontal",
        //resizeWidth: true,
        handles: 's, n',
        alsoResize: '.search-filter',
        stop: displayNewDimensions
    });

    $('input[name=EventsDate]').daterangepicker({
        firstDayOfWeek: 1,
        timePicker: true,
        startDate: moment().startOf('hour'),
        endDate: moment().startOf('hour').add(32, 'hour'),
        locale: {
            format: 'MM/DD/YYYY HH:mm',
        }
    });


    // configuration stream setting.
    $('#SaveConfiguration').click(function () {

        localStorage.IsSwitchOn = $('#switchbtn').hasClass('active') ? true : false;
        var selected = $("#categories option:selected");
        localStorage.selectedCategory = "";
        selected.each(function () {
            localStorage.selectedCategory += $(this).val() + ",";
        });
        localStorage.selectedCategory = localStorage.selectedCategory.replace(/,\s*$/, "");
        localStorage.serverDetail = $("#Stream_Server").val();
        $("#modalconfiguration").modal('hide');
    });


    var triggerCount = 0;
    $('#searchbox').click(function () {
        if (triggerCount !== 0) {
            if ($('.search-filter:visible').length == 0) {

                $('#searchbox i.arrow').removeClass('fa-caret-down').addClass('fa-caret-up');

                $('.search-filter').css('display', 'block').css('width', '301px');

                $('#panelTop').css("height", "636px");

                $('.child_div2').css("height", "").css("overflow", "");

                $('.responsive-grid').removeClass('responsive-full-grid');
                $('#panelBottom').css("height", "49%");
                toplevelpanel = "636";

            }
            else {

                $('#searchbox i.arrow').removeClass('fa-caret-up').addClass('fa-caret-down');

                $('.search-filter').css('display', 'none');
                $('.responsive-grid').addClass('responsive-full-grid');
                $('#panelTop').css("height", "8%");
                $('#panelBottom').css("height", "90%");
                toplevelpanel = "0";
            }

        }
        else {
            $('.search-filter').css('display', 'none');
            $('#searchbox i.arrow').removeClass('fa-caret-up').addClass('fa-caret-down');
            $('.responsive-grid').addClass('responsive-full-grid');
            $('#panelTop').css("height", "8%");
            $('#panelBottom').css("height", "90%");
            toplevelpanel = "0";
        }
        triggerCount = 1;

    });


    $("#Interval").change(function () {
        localStorage.selectedInterval = $('option:selected', this).val();

        var interval = 1000 * 60 * localStorage.selectedInterval;
        localStorage.interval = interval;
        intervalfunction();
    });

    if (localStorage.IsSwitchOn === "true") {
        $('#switchbtn').addClass('active')
    }

    if (localStorage.serverDetail === undefined) {
        $("#Stream_Server").val(localStorage.serverDetail);
    }
    if (localStorage.serverDetail === undefined) {
        $("#Stream_Server").val(localStorage.serverDetail);
    }

    if (localStorage.selectedCategory !== undefined) {
        var categories = localStorage.selectedCategory.split(',');
        for (var i in categories) {
            var optionVal = categories[i];
            $("#categories").find("option[value=' + optionVal + ']").prop("selected", "selected");
        }
        $("#categories").multiselect('refresh');

        $("#Stream_Server").val(localStorage.serverDetail);
    }
    // search and cancel btn functionality.
    $('#Searchbtn').click(function () {

        if ($("#EventsDate").val() !== '') {
            var date = $("#EventsDate").val().split('-');
            var toDate = convertDateToLocalDateBeforPost(date[0]);
            var fromDate = convertDateToLocalDateBeforPost(date[1]);
            $("#CreatedDate").val(toDate + '~' + fromDate);
        }

        localStorage.pageNumber = 1;
        $('#PageNumber').val(localStorage.pageNumber);
        $('#prev_btn').hide();
        $("#FilterType").val('search');

        SearchEvents();
    });

    $('#cancel-btn').click(function () {
        localStorage.pageNumber = 1;
        ClearAll();
        SearchEvents();
    });
    $("#FilterType").val('');
});

function intervalfunction() {
    // interval function.
    setInterval(function () {
        EventsInterval();
    }, localStorage.interval);
}


function SearchEvents() {

    $("#cover-spin").show();

    if ($("input[name=EventsDate]").val() === "") {
        $("#CreatedDate").val('');
    }
    $.ajax({
        dataType: 'HTML',
        type: 'POST',
        url: '../Main/SearchEvents',
        data: $('#searchform').serialize(),
        success: function (result) {
            var grid = $("#grid").data("kendoGrid");
            grid.dataSource.page(1);
            $("#cover-spin").hide();
        },
        failure: function (response) {
            $('#tbody').html(response);
            $("#cover-spin").hide();
        }
    });
}

function EventDetail(eventid) {
    $("#cover-spin").show();

    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'HTML',
        type: 'GET',
        url: '../Main/GetEventDetail',
        data: { EventId: eventid },
        success: function (data) {
            $('#modelbody').html('');
            $('#modelbody').html(data);
            $("#modalDetail").modal('show');
            $("#cover-spin").hide();
        },
        failure: function (response) {
            $('#modelbody').html(response);
            $("#cover-spin").hide();
        }
    });
}

function EventsInterval() {
    if (localStorage.IsSwitchOn === "true") {
        GetTop5Events();

    }
}

function GetTop5Events() {

    $("#cover-spin").show();
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'HTML',
        type: 'GET',
        url: '../Main/GetTop5Events',
        data: { Category: localStorage.selectedCategory, ServerDetail: localStorage.serverDetail },
        success: function (data) {

            $('.responsive-grid').html('');
            $('.responsive-grid').html(data);
            $("#cover-spin").hide();
        },
        failure: function (response) {
            $('.responsive-grid').html(response);
            $("#cover-spin").hide();
        }
    });

}
function ClearAll() {

    $("textarea[name=Message]").val('');
    $("textarea[name=Summary]").val('');
    $("input[name=Source]").val('');
    $("input[name=ServerDetail]").val('');
    $("input[name=ErrorCode]").val('');
    $("input[name=CreatedDate]").val('');
    $("input[name=Attachment]").val('');
    $('#Category').val('');
    $("input[name=EventsDate]").val('');
    $("#FilterType").val('');
}

function showDetails(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    EventDetail(dataItem.EventId)
}

function onDataBound(e) {
    var span = "<span class='k-icon k-i-information'></span>"
    e.sender.tbody.find(".k-grid-viewdetail").prepend(span);
    $('.k-grid-viewdetail').removeClass('k-button k-button-icontext');

    var eventGrid = $("#grid").data("kendoGrid");
    var eventdataSource = eventGrid.dataSource;
    if (eventdataSource.total() < 20) {
        $('#next_btn').hide();
    }
    else {
        $('#next_btn').show();
    }
    if (eventdataSource.total() < 20 && localStorage.pageNumber == "1") {
        $('#prev_btn').hide();
    }
    
}

function onRequestEnd(e) {
    if (e.response.Data && e.response.Data.length) {
        var events = e.response.Data;
        if (this.group().length && e.type == "read") {
            for (var i = 0; i < events.length; i++) {
                var gr = events[i];
                addOffset(gr.Items);
            }
        } else {
            addOffset(events);
        }
    }
}

function addOffset(events) {
    for (var i = 0; i < events.length; i++) {
        events[i].CreatedDate = convertUTCDateToLocalDate(new Date(events[i].CreatedDate));

    }
}

//function convertUTCDateToLocalDate(date) {


//    var testdate = new Date(date +' UTC');
//   var test= testdate.toString()

//    ////// Get user locale
//    var locale = window.navigator.userLanguage || window.navigator.language;

//    //var utc_datetime = Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds());
//    //const event = new Date(utc_datetime);

//    //var newDate = new Date(event.getTime() + event.getTimezoneOffset() * 60 * 1000);
//    //var offset = event.getTimezoneOffset() / 60;
//    //var hours = event.getHours();
//    //newDate.setHours(hours - offset);
//    return testdate.toLocaleString(locale);

//}

function displayNewDimensions(e, ui) {

    var topPanelHeight = $(".panel-top")[0].style.height.replace('px', '');

    var changedHeight = 0;
    var bottompannelHeight = $('.responsive-grid').css('max-height').replace('px', '');
    var searchfilterHeight = $('.search-filter').css('height').replace('px', '');

    var searchFormHeight = '';
    if (parseInt(topPanelHeight) < 636) {
        searchFormHeight = parseInt(topPanelHeight) - 93;
        searchFormHeight = searchFormHeight + "px";
        $('.child_div2').css("height", '' + searchFormHeight + '').css("overflow", 'auto').scrollTop();
    }
    else {
        $('.child_div2').css("overflow", '');
        $(".search-filter").css('width', '301px');
    }

    if (toplevelpanel > topPanelHeight) {

        searchfilterHeight = parseInt(searchfilterHeight) - 30;
        searchfilterHeight = searchfilterHeight + "px";

        changedHeight = toplevelpanel - topPanelHeight;
        changedHeight = (parseInt(bottompannelHeight) + parseInt(changedHeight)) + "px";
        toplevelpanel = topPanelHeight;

        $('#panelTop').css("width", "100%");
        $('.search-filter').css("width", "100%");

    }
    else {
        changedHeight = topPanelHeight - toplevelpanel;
        changedHeight = (parseInt(bottompannelHeight) - parseInt(changedHeight)) + "px";
        toplevelpanel = topPanelHeight;
        searchfilterHeight = parseInt(searchfilterHeight) + 10;
        searchfilterHeight = searchfilterHeight + "px";

        $('#panelTop').css("width", "");
    }

    $(".search-filter").css('height', '' + searchfilterHeight + '');
    $(".responsive-grid").css('max-height', '' + changedHeight + '');
}

//function convertDateToLocalDateBeforPost(date) {
//    debugger;
//    var selectedDate = new Date(date);
//    var newDate = new Date(selectedDate.getTime() + selectedDate.getTimezoneOffset() * 60 * 1000);
//    var offset = selectedDate.getTimezoneOffset() / 60;
//    var hours = selectedDate.getHours();
//    newDate.setHours(hours + offset);
//    newDate = moment(newDate).format('YYYY-MM-DD HH:mm');
//    return newDate;
//}


function convertUTCDateToLocalDate(date) {   
    var testdate = new Date(date + ' UTC');    
    ////// Get user locale
    var locale = window.navigator.userLanguage || window.navigator.language;
    return testdate.toLocaleString(locale);
}

function convertDateToLocalDateBeforPost(date) {
    var selectedDate = new Date(date);
    var latestDate = selectedDate.toUTCString();

    var temp = new Date(latestDate.substring(5, latestDate.length - 4));
    return moment(temp).format('YYYY-MM-DD HH:mm');
}
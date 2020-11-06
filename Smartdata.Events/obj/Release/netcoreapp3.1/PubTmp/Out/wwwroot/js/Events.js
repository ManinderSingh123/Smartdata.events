

$(document).ready(function () {
    
    if (localStorage.interval === undefined || localStorage.interval === "" ) {
        
        localStorage.interval = 1000 * 60 * $('#Interval :selected').val();
    }
    else {
        $("#Interval").val(parseInt(localStorage.interval) / parseInt(1000 * 60 * parseInt(localStorage.selectedInterval)));
    }

    localStorage.selectedCategory === undefined ? "" : localStorage.selectedCategory;

    GetTop5Events();
    intervalfunction();
    $('#categories').multiselect({
        includeSelectAllOption: true
    });
    //time stamp date range picker.
    $('input[name=CreatedDate]').dateRangePicker(
        {
            startOfWeek: 'monday',
            separator: ' ~ ',
            format: 'YYYY-MM-DD HH:mm',
            autoClose: false,
            time: {
                enabled: true
            },
            defaultTime: moment().startOf('day').toDate(),
            defaultEndTime: moment().endOf('day').toDate()
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

    $("#Interval").change(function () {
        localStorage.selectedInterval = $('option:selected', this).val();

        interval = 1000 * 60 * selectedInterval;
        localStorage.interval = interval;
        intervalfunction();
    });

    if (localStorage.IsSwitchOn === "true") {
        $('#switchbtn').addClass('active')
    };

    if (localStorage.serverDetail === undefined) {
        $("#Stream_Server").val(localStorage.serverDetail);
    }
    if (localStorage.serverDetail === undefined) {
        $("#Stream_Server").val(localStorage.serverDetail);
    }

    if (localStorage.selectedCategory !== undefined) {
        var selectitem = "";
        var categories = localStorage.selectedCategory.split(',');
        $('.multiselect-selected-text').text('');

        $('#categories option').each(function () {           
            if (categories.indexOf($(this).val()) > -1)
            {     
                selectitem += $(this).text() + ",";               

                $('.multiselect-container li').each(function (i) {                    
                    if (categories.indexOf($(this).find('input[type=checkbox]').val()) !== -1) {
                        
                        $(this).find('input[type=checkbox]').prop('checked', 'checked');
                        $(this).addClass('active')
                    }
                    
                });
               
            }
            
        });
        $('.multiselect-selected-text').append(selectitem.replace(/,\s*$/, ""));
        $("#Stream_Server").val(localStorage.serverDetail);
    }
    // search and cancel btn functionality.
    $('#Searchbtn').click(function () {
        SearchEvents();
    });

    $('.btn-cancel').click(function () {
        ClearAll();
        SearchEvents();
    });   

});

function intervalfunction() {
    // interval function.
    setInterval(function () {
        EventsInterval();
    }, localStorage.interval);
}


function SearchEvents() {
    $("#cover-spin").show();
    $.ajax({
        dataType: 'HTML',
        type: 'POST',
        url: '/Events/SearchEvents',
        data: $('#searchform').serialize(),
        success: function (result) {
           
            var content = JSON.parse(result);
            var configuration = {
                dataSource: content,
                //scrollable: false,
                pageable: {
                    input: false,
                    numeric: true,
                    butonCount: 5,
                    pageSize: 20,
                    alwaysVisible: true,
                    previousNext: true
                },
                columns: [
                    { command: { text: "View Details", click: showDetails }, title: " ", width: "130px" },
                    { field: "Category", width: 130, title: "Category" },
                    { field: "Message", width: 130, title: "Message" },
                    { field: "Summary", width: 130, title: "Summary" },
                    { field: "Serverdetail", width: 130, title: "Server detail" },
                    { field: "Source", width: 105, title: "Source" },
                    { field: "Errorcode", width: 130, title: "Event Code" },
                    { field: "CreatedDate", width: 150, title: "Time Stamp" },
                    { field: "Attachment", width: 150, title: "Attachment" }                    
                ],
                height: 800,
                serverPaging: true               
            };

            var grid = $("#grid").kendoGrid(configuration).data("kendoGrid");
            debugger;
            if (result !== "[]") {
                grid.dataSource.total = function () {
                    return JSON.parse(result)[0].TotalCount;
                };
            }
            
           
            grid.dataSource.group("Category");
            grid.refresh();
            grid.pager.refresh();
            //});


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
        url: '/Events/GetEventDetail',
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
        url: '/Events/GetTop5Events',
        data: { CategoryId: localStorage.selectedCategory, ServerDetail: localStorage.serverDetail },
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
    $('#CategoryId option:eq(0)').attr('selected', 'select');

}
function error_handler(e) {

    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}
function showDetails(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    EventDetail(dataItem.EventId)
}


using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Redmap.Events.Common;
using Redmap.Events.DTO;
using Redmap.Events.Services.Interface;
using Redmap.Events.SessionExtention;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Redmap.Events.Areas.Events.Controllers
{
    /// <summary>
    /// Event controller
    /// </summary>
    [Area("events")]
    public class MainController : Controller
    {
        private readonly ILogMessagesService logMessagesService;
        private readonly string pageSize;
        

       /// <summary>
       /// Log Controller Constructer
       /// </summary>
       /// <param name="logMessagesService"></param>
       /// <param name="configuration"></param>
        public MainController(ILogMessagesService logMessagesService, IConfiguration configuration)
        {
            this.logMessagesService = logMessagesService;
            pageSize = configuration.GetValue<string>("KendoGridInfo:PageSize");            
        }       

        /// <summary>
        /// RedmapEvent
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            EventsDto model = new EventsDto();
            var eventCategories = Enum.GetValues(typeof(Categories)).Cast<Categories>().ToList();
            var categories = eventCategories.Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString()
            });

            // Setting.  
            ViewBag.MultiSelectCategories = new SelectList(categories.ToList(), "Value", "Text");
            ViewBag.PageSize = Convert.ToInt32(pageSize);
            ViewBag.MasterCategories = new SelectList(categories.ToList(), "Value", "Text");
            return View(model);
        }


        /// <summary>
        /// Event grid binding
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult EventsBinding([DataSourceRequest] DataSourceRequest request)
        {
            SearchFilters filtermodel = HttpContext.Session.GetComplexData<SearchFilters>("Filters");
            filtermodel = filtermodel != null ? filtermodel : new SearchFilters();            
            filtermodel.PageSize = request.PageSize;            
            IEnumerable<EventsDto> model = null;

            if (string.IsNullOrEmpty(filtermodel.FilterType))
            {
                model = logMessagesService.GetLatestLogs(Convert.ToInt32(pageSize));
            }
            else if (filtermodel.FilterType == "search")
            {
                filtermodel.PageNumber = 1;
                model = logMessagesService.GetLogMessages(filtermodel);
            }
            else if (filtermodel.FilterType == "other")
            {
                model = logMessagesService.GetLogMessages(filtermodel);
            }
            request.Page = 1;

            var data = model.ToDataSourceResult(request);
            filtermodel.FilterType = "other";
            HttpContext.Session.SetComplexData("Filters", filtermodel);
            return Json(data);
        }       

        /// <summary>
        /// Search Events
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SearchEvents(SearchFilters model)
        {           
            
            //model.PageNumber = 1;
            model.PageSize=Convert.ToInt32(pageSize);
            ViewBag.PageSize = Convert.ToInt32(pageSize);
            HttpContext.Session.SetComplexData("Filters", model);

            return Json("ok");
        }
        /// <summary>
        /// Export Events
        /// </summary>       
        /// <returns></returns>
         [HttpPost]
        public IActionResult ExportEvents()
        {           
            SearchFilters filtermodel = HttpContext.Session.GetComplexData<SearchFilters>("Filters");
            filtermodel = filtermodel != null ? filtermodel : new SearchFilters();
            IEnumerable<EventsDto> events = logMessagesService.GetExportEvents(filtermodel);           
            var content = CommonClass.ExportToExcel(events);
            return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "events.xlsx");
        }
        

        /// <summary>
        /// Get Event Detail
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public ActionResult GetEventDetail(int eventId)
        {
            EventsDto result = logMessagesService.GetEventDetail(eventId);
            return PartialView("~/Areas/Events/Views/Shared/_EventDetail.cshtml", result);
        }
        
        /// <summary>
        /// Get top 5 events
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTop5Events(string Category,string ServerDetail)
       {            
            IEnumerable<EventsDto> result = logMessagesService.GetTop5Events(Category, ServerDetail);
            return PartialView("~/Areas/Events/Views/Shared/_Top5Events.cshtml", result);
       }

    }
}
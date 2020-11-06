using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Redmap.Events.Common;
using Redmap.Events.DTO;
using Redmap.Events.Services.Interface;
namespace Redmap.Events.Controllers
{
    /// <summary>
    /// Log Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly ILogMessagesService logMessagesService;
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Log Controller Constructer
        /// </summary>
        /// <param name="logMessagesService"></param>
        public LogController(ILogMessagesService logMessagesService, IConfiguration configuration)
        {
            this.logMessagesService = logMessagesService;
            _configuration = configuration;
        }

        [HttpGet("encrypt/{plainText}")]
        public IActionResult Encrypt(string plainText)
        {
            return Ok(StringCipher.Encrypt(plainText, _configuration.GetValue<string>("PassPhrase")));
        }

        /// <summary>
        /// For fetch log messages data with parameter.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns>LogMessageModel</returns>
        [HttpGet("{categoryName}")]
        public ActionResult<List<EventsDto>> GetLogMessage(string categoryName)
        {
            int LogCategoryId = CommonClass.GetCategoryId(categoryName);
            List<EventsDto> logMessages = logMessagesService.GetLogMessages(LogCategoryId).ToList();
            return logMessages;
        }

        /// <summary>
        /// For fetch log messages data.
        /// </summary>        
        /// <returns></returns>
        [HttpPut]
        public IActionResult Log() {
            return Ok("Success put");
        }
        /// <summary>
        /// For fetch log messages data.
        /// </summary>        
        /// <returns></returns>
        [HttpGet]
        [Route("GetLogMessage")]
        public ActionResult<List<EventsDto>> GetLogMessage()
        {                       
            return logMessagesService.GetLatestLogs(50).ToList();
        }

        [HttpGet]
        [Route("PostLogMessage")]
        public ActionResult<List<EventsDto>> PostLogMessage(string Message,string Summary,string source,string category)
        {
            SearchFilters filters = new SearchFilters();
            filters.Category = category;
            filters.Message = Message;
            filters.Summary = Summary;
            filters.Source = source;
            filters.PageNumber = 1;
            filters.PageSize = 20;

            return logMessagesService.GetLogMessages(filters).ToList();
        }

        [HttpPost]
        [Route("PostLogMessage")]
        public ActionResult<List<EventsDto>> PostLogMessage([FromBody]SearchFilters filters)
        {
            filters = filters == null ? new SearchFilters() : filters;
            filters.PageNumber = 1;
            filters.PageSize = 20;
            return logMessagesService.GetLogMessages(filters).ToList();
        }

        /// <summary>
        /// For fetch log messages data.
        /// </summary>        
        /// <returns></returns>
        [HttpGet]
        [Route("GetTop5LogMessage")]
        public ActionResult<List<EventsDto>> GetTop5LogMessage(string Category, string ServerDetail)
        {
            return logMessagesService.GetTop5Events(Category, ServerDetail).ToList();
        }

        /// <summary>
        /// Save log message data with attached file.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>logid</returns>
        [HttpPost]
        [Produces("application/json")]
        // [RequestSizeLimit(500000000)]
        public ActionResult AttachedFileWithData([FromForm] LogMessageDto model)
        {
           var response= logMessagesService.SaveLogMessage(model);
            return Ok(new { status = response.StatusCode, message = response.Message });
        }            

    }
}
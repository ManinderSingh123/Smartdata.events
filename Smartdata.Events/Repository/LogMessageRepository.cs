using Microsoft.Extensions.Configuration;
using Npgsql;
using Redmap.Events.Common;
using Redmap.Events.DTO;
using Redmap.Events.Model;
using Redmap.Events.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Redmap.Events.Repository
{
    /// <summary>
    /// Event Message Repository
    /// </summary>
    public class LogMessageRepository : BaseRepository, ILogMessageRepository
    {
        #region database connection
        private string connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public LogMessageRepository(IConfiguration configuration) : base(configuration)
        {
            //connectionString = StringCipher.Decrypt(Environment.GetEnvironmentVariable("CONN_STRING"), passPhrase); // change connection when live.
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }
        #endregion


        #region repository functions


        /// <summary>
        /// For fetch event messages data with parameter using postgreSQL function.
        /// </summary>
        /// <param name="logCategoryId"></param>
        /// <returns>List of type LogMessageModel</returns>
        public List<LogMessageModel> GetLogMessages(int logCategoryId)
        {
            var query = "select * from public.func_geteventmessagesbycategory(" + logCategoryId + ") ";
            var logMessages = Get<LogMessageModel>(query);
            return logMessages.ToList();
        }

        /// <summary>
        /// Get filter events
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<LogMessageModel> GetLogMessages(SearchFilters model)
        {

            var getCountQuery = "";
            var query = "";
            var compares = "";
            var isFirstParameter = 0;
            int totalCount = 0;
            List<LogMessageModel> logMessages = new List<LogMessageModel>();


            if (!string.IsNullOrEmpty(model.Category))
            {
                compares += string.Format("t1.eventcategory={0} ", "@eventcategory");
                isFirstParameter++;
            }

            if (!string.IsNullOrEmpty(model.Errorcode))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.errorcode) similar to  {0} ", "@errorcode");
                isFirstParameter++;
            }
            if (!string.IsNullOrEmpty(model.Message))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.message) similar to  {0} ", "@message");
                isFirstParameter++;
            }
            if (!string.IsNullOrEmpty(model.Attachment))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.attachment) similar to  {0} ", "@attachment");
                isFirstParameter++;
            }
            if (!string.IsNullOrEmpty(model.Serverdetail))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.serverdetail) similar to  {0} ", "@serverdetail");
                isFirstParameter++;
            }
            if (!string.IsNullOrEmpty(model.Summary))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.summary) similar to  {0} ", "@summary");
                isFirstParameter++;
            }
            if (!string.IsNullOrEmpty(model.Source))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.source) similar to  {0} ", "@source");
                isFirstParameter++;
            }

            if (!string.IsNullOrEmpty(model.Tag1))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.tag1) similar to  {0} ", "@tag1");
                isFirstParameter++;
            }

            if (!string.IsNullOrEmpty(model.Tag2))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("lower(t1.tag2) similar to  {0} ", "@tag2");
                isFirstParameter++;
            }

            if (!string.IsNullOrEmpty(model.Startdate) && !string.IsNullOrEmpty(model.Enddate))
            {
                if (isFirstParameter >= 1)
                {
                    compares += "AND ";
                }
                compares += string.Format("t1.createddate  between {0} AND {1}", "@Startdate", "@Enddate");
                isFirstParameter++;
            }

            query += "SELECT t1.eventid, t1.eventcategory,LEFT(t1.summary, 30) as summary,t1.errorcode,t1.attachment,LEFT(t1.message, 30) as message ,t1.serverdetail,t1.tag1,t1.tag2,t1.source,t1.createddate from public.eventmessagenew t1";

            if (!string.IsNullOrEmpty(compares))
            {
                query += string.Format(" Where {0} ", compares);
            }

            query += string.Format(" order by t1.createddate desc ");

            query += string.Format(" LIMIT {0}", model.PageSize);
            query += string.Format(" OFFSET {0} * ({1} - 1)", model.PageSize, model.PageNumber);

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var cmd = new NpgsqlCommand(query, conn);
                cmd = CommonClass.SetParametersValue(model, cmd);

                if (!CommonClass.VerifyQuery(query))
                {

                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    logMessages = reader.MapToList<LogMessageModel>();
                    conn.Close();                    
                }

            }

            return logMessages;
        }
        /// <summary>
        /// Export events
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<LogMessageModel> GetExportEvents(SearchFilters model)
        {

            var query = "";
            if (string.IsNullOrEmpty(model.CreatedDate))
            {
                query = "select * from public.func_exportevents('" + model.Category + "','" + model.Message + "','" + model.Summary + "','" + model.Source + "','" + model.Serverdetail + "','" + model.Errorcode + "','" + model.Attachment + "','" + model.Tag1 + "','" + model.Tag2 + "'," + "null" + "," + "null" + ") ";
            }
            else
            {
                query = "select * from public.func_exportevents('" + model.Category + "','" + model.Message + "','" + model.Summary + "','" + model.Source + "','" + model.Serverdetail + "','" + model.Errorcode + "','" + model.Attachment + "','" + model.Tag1 + "','" + model.Tag2 + "','" + model.Startdate.ToString() + "','" + model.Enddate.ToString() + "') ";
            }

            var logMessages = Get<LogMessageModel>(query);
            return logMessages.ToList();
        }


        /// <summary>
        /// For fetch event messages data using postgreSQL function.
        /// </summary>        
        /// <returns>List of type LogMessageModel </returns>
        public List<LogMessageModel> GetLogMessages()
        {
            var query = "select * from public.func_geteventmessages()";
            var logMessages = Get<LogMessageModel>(query);
            return logMessages.ToList();
        }

        /// <summary>
        /// Get event detail.
        /// </summary>        
        /// <returns>single event </returns>
        public LogMessageModel GetEventDetail(int EventId)
        {
            var query = "select * from public.func_geteventdetail(" + EventId + ")";
            var logMessages = Get<LogMessageModel>(query).FirstOrDefault();
            return logMessages;
        }

        /// <summary>
        /// Save event message data using postgreSQL function.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>eventid</returns>
        public int SaveLogMessage(LogMessageModel model)
        {

            var query = "select * from public.func_saveeventsnew('" + model.EventCategory + "','" + model.Message + "','" + model.Summary + "','" + model.Errorcode + "','" + model.Attachment + "','" + model.Serverdetail + "','" + model.Source + "','" + model.Tag1 + "','" + model.Tag2 + "'," + "null" + ") ";

            var logMessage = Get<LogMessageModel>(query).FirstOrDefault();
            return logMessage.EventId;
        }

        /// <summary>
        /// Get top 5 events.
        /// </summary>
        /// <returns></returns>
        public List<LogMessageModel> GetTop5Events(string Category, string ServerDetail)
        {
            var query = "select * from public.func_gettop5eventsnew('" + Category + "','" + ServerDetail + "')";
            var logMessages = Get<LogMessageModel>(query);
            return logMessages.ToList();
        }


        /// <summary>
        /// Get Latest Logs
        /// </summary>
        /// <returns></returns>
        public List<LogMessageModel> GetLatestLogs(int PageSizeLimit)
        {
            var query = "select * from public.func_getlatesteventmessages(" + PageSizeLimit + ") ";
            return Get<LogMessageModel>(query).ToList();
        }

    }

    #endregion

}




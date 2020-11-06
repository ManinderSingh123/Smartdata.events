using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Npgsql;
using NpgsqlTypes;
using Redmap.Events.DTO;
using Redmap.Events.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Redmap.Events.Common
{
    /// <summary>
    /// Class with common functions.
    /// </summary>
    public static class CommonClass
    {
        /// <summary>
        /// Getting category id from enum by category name.
        /// </summary>
        /// <param name="categoryname"></param>
        /// <returns></returns>
        public static int GetCategoryId(string categoryname)
        {
            int logCategoryId = 0;
            if (categoryname != null)
            {
                switch (categoryname.ToLower())
                {
                    case "error":
                        logCategoryId = (int)Categories.Error;
                        break;
                    case "failure":
                        logCategoryId = (int)Categories.Failure;
                        break;
                    case "successAudit":
                        logCategoryId = (int)Categories.SuccessAudit;
                        break;
                    case "information":
                        logCategoryId = (int)Categories.Information;
                        break;
                    case "summary":
                        logCategoryId = (int)Categories.Summary;
                        break;
                    case "warning":
                        logCategoryId = (int)Categories.Warning;
                        break;
                    case "debug":
                        logCategoryId = (int)Categories.Debug;
                        break;

                }
            }
            return logCategoryId;
        }

        /// <summary>
        /// Upload File To S3 Bucket.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="accesskey"></param>
        /// <param name="secertkey"></param>
        /// <param name="bucketname"></param>
        public static void UploadFileToS3(IFormFile file, string fileName, string accesskey, string secertkey, string bucketname)
        {
            using (var client = new AmazonS3Client(accesskey, secertkey, RegionEndpoint.APSoutheast1))
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = fileName,
                        BucketName = bucketname,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    var fileTransferUtility = new TransferUtility(client);
                    fileTransferUtility.Upload(uploadRequest);
                }
            }
        }


        /// <summary>
        /// Replace Single Quotes with double
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceSingleQuotes(string text)
        {
            text = string.IsNullOrEmpty(text) ? text : text.Replace("'", "''"); ;
            return text;
        }
        /// <summary>
        /// Change Date Format
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ChangeDateFormat(string text)
        {
            string returnDate = "";
            if (!string.IsNullOrEmpty(text))
            {
                var splitdate = text.Split('/');
                returnDate = splitdate[1] + "/" + splitdate[0] + "/" + splitdate[2];
            }

            return returnDate;
        }

        /// <summary>
        /// Export To Excel
        /// </summary>
        public static byte[] ExportToExcel(IEnumerable<EventsDto> events)
        {
            byte[] content = null;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Events");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "EventId";
                worksheet.Cell(currentRow, 2).Value = "Catetory";
                worksheet.Cell(currentRow, 3).Value = "Message";
                worksheet.Cell(currentRow, 4).Value = "Summary";
                worksheet.Cell(currentRow, 5).Value = "Source";
                worksheet.Cell(currentRow, 6).Value = "EventCode";
                worksheet.Cell(currentRow, 7).Value = "Attachmemnt";
                worksheet.Cell(currentRow, 8).Value = "Time stamp";
                foreach (var evnt in events)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = evnt.EventId;
                    worksheet.Cell(currentRow, 2).Value = evnt.EventCategory;
                    worksheet.Cell(currentRow, 3).Value = evnt.Message;
                    worksheet.Cell(currentRow, 4).Value = evnt.Summary;
                    worksheet.Cell(currentRow, 5).Value = evnt.Source;
                    worksheet.Cell(currentRow, 6).Value = evnt.Errorcode;
                    worksheet.Cell(currentRow, 7).Value = evnt.Attachment;
                    worksheet.Cell(currentRow, 8).Value = evnt.CreatedDate;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    content = stream.ToArray();

                    return content;
                }

            }
        }

        /// <summary>
        /// Check Multi Keyword
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CheckMultiKeyword(string text)
        {
            string returValue = "";
            string[] stringArray = null;
            stringArray = string.IsNullOrEmpty(text) ? stringArray : text.Trim().Split(' ');
            var count = 0;
            foreach (var item in stringArray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (count == 0)
                    {
                        //returValue +=item ;
                        returValue += "%(" + item.ToLower();
                    }
                    else
                    {
                        returValue += "|" + item;
                        //returValue += " or like '%" + item.ToLower() + "%' ";
                    }
                    count++;
                }
            }
            returValue += ")%";
            return returValue;
        }

        /// <summary>
        /// Verify sql injection
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static bool VerifyQuery(string query)
        {
            bool status = false;

            // Check for database special commands
            foreach (var item in BadChars.badCommands)
            {
                if (query.ToUpper().Contains(item.ToUpper()))
                {
                    status = true;
                }
            }

            return status;
        }

        /// <Summary>
        /// Map data from DataReader to list of objects
        /// </Summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="dr">Data Reader</param>
        /// <returns>List of objects having data from data reader</returns>
        public static List<T> MapToList<T>(this DbDataReader dr) where T : new()
        {
            List<T> RetVal = null;
            var Entity = typeof(T);
            var PropDict = new Dictionary<string, PropertyInfo>();

            if (dr != null && dr.HasRows)
            {
                RetVal = new List<T>();
                var Props = Entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                PropDict = Props.ToDictionary(p => p.Name.ToUpper(), p => p);
                while (dr.Read())
                {
                    T newObject = new T();
                    for (int Index = 0; Index < dr.FieldCount; Index++)
                    {
                        if (PropDict.ContainsKey(dr.GetName(Index).ToUpper()))
                        {
                            var Info = PropDict[dr.GetName(Index).ToUpper()];
                            if ((Info != null) && Info.CanWrite)
                            {
                                var Val = dr.GetValue(Index);
                                Info.SetValue(newObject, (Val == DBNull.Value) ? null : Val, null);
                            }
                        }
                    }
                    RetVal.Add(newObject);
                }
            }

            return RetVal;
        }

        /// <summary>
        /// Set npgsql parameters
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static NpgsqlCommand SetParametersValue(SearchFilters model, NpgsqlCommand cmd)
        {
           

                if (!string.IsNullOrEmpty(model.Category))
                {
                    cmd.Parameters.AddWithValue("@eventcategory", NpgsqlDbType.Varchar, model.Category);
                }

                if (!string.IsNullOrEmpty(model.Errorcode))
                {
                    cmd.Parameters.AddWithValue("@errorcode", NpgsqlDbType.Varchar, model.Errorcode);
                }
                if (!string.IsNullOrEmpty(model.Message))
                {
                    cmd.Parameters.AddWithValue("@message", NpgsqlDbType.Varchar, model.Message);
                }
                if (!string.IsNullOrEmpty(model.Attachment))
                {
                    cmd.Parameters.AddWithValue("@attachment", NpgsqlDbType.Varchar, model.Attachment);
                }
                if (!string.IsNullOrEmpty(model.Serverdetail))
                {
                    cmd.Parameters.AddWithValue("@serverdetail", NpgsqlDbType.Varchar, model.Serverdetail);
                }
                if (!string.IsNullOrEmpty(model.Summary))
                {
                    cmd.Parameters.AddWithValue("@summary", NpgsqlDbType.Varchar, model.Summary);
                }

                if (!string.IsNullOrEmpty(model.Tag1))
                {
                    cmd.Parameters.AddWithValue("@tag1", NpgsqlDbType.Varchar, model.Tag1);
                }

                if (!string.IsNullOrEmpty(model.Tag2))
                {
                    cmd.Parameters.AddWithValue("@tag2", NpgsqlDbType.Varchar, model.Tag2);
                }

                if (!string.IsNullOrEmpty(model.Source))
                {
                    cmd.Parameters.AddWithValue("@source", NpgsqlDbType.Varchar, model.Source);
                }

                if (!string.IsNullOrEmpty(model.Startdate) && !string.IsNullOrEmpty(model.Enddate))
                {
                    cmd.Parameters.AddWithValue("@Startdate", NpgsqlDbType.Timestamp, Convert.ToDateTime(model.Startdate));
                    cmd.Parameters.AddWithValue("@Enddate", NpgsqlDbType.Timestamp, Convert.ToDateTime(model.Enddate));
                }


            return cmd;
        }


    }
}

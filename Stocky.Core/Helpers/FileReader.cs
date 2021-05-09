using CsvHelper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Core.Helpers
{
    public static class FileReader<T> where T : class, new()
    {
        // CSV file reader
        public static IEnumerable<T> ReadFromCSV(IFormFile file)
        {
            var records = new List<T>();
            var errors = new List<string>();
            int ind = 0;

            try
            {
                // Allow only *.csv files
                if (file == null || (Path.GetExtension(file.FileName).ToLower() != ".csv")) return records;
                var isbadRecord = false;

                using (var fileStream = file.OpenReadStream())
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                    csv.Configuration.BadDataFound = context =>
                    {
                        isbadRecord = true;
                        errors.Add(context.RawRecord);
                    };

                    while (csv.Read())
                    {
                        ind += 1;
                        var record = csv.GetRecord<T>();
                        if (isbadRecord == false)
                        {
                            records.Add(record);
                        }

                        isbadRecord = false;
                    }

                    //records = csv.GetRecords<T>().ToList();
                    if (errors.Any()) throw new Exception("InvalidRecordExists");
                    return records;
                }
            }
            catch (Exception ex)
            {
                var exceptionInfo = new Exception("Invalid Record");
                exceptionInfo.Data["Message"] = $"Row #{ind}: {ex.Message}";
                exceptionInfo.Data["ErrorList"] = errors;

                if (ex.Message == "InvalidRecordExists")
                {
                    exceptionInfo.Data["Message"] = $"Invalid Record exists";
                }

                throw (exceptionInfo);
            }
        }

        // JSON file reader
        public static T ReadFromJSON(IFormFile file) 
        {
            try
            {
                // Allow only *.json files
                if (file == null || (Path.GetExtension(file.FileName).ToLower() != ".json")) return new T();

                var fileStream = file.OpenReadStream();
                using (var reader = new StreamReader(fileStream))
                {
                    var data = reader.ReadToEnd();

                    fileStream.Close();
                    return JsonConvert.DeserializeObject<T>(data);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

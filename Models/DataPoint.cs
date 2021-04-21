using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace centricTeam4.Models
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(double y, string label)
        {
            this.Y = y;
            this.Label = label;
        }

        public DataPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }


        public DataPoint(double x, double y, string label)
        {
            this.X = x;
            this.Y = y;
            this.Label = label;
        }

        public DataPoint(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public DataPoint(double x, double y, double z, string label)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Label = label;
        }


        //Explicitly setting the name to be used while serializing to JSON. 
        [DataMember(Name = "label")]
        public string Label = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<double> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "z")]
        public Nullable<double> Z = null;
    }
}
//    private static List<DataPoint> _dataPoints;
//    JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

//    public ActionResult categoryCharts(string chartType)
//    {
//        if (chartType is null || chartType.Length < 3)
//        {
//            chartType = "pie";
//        }
//        _dataPoints = new List<DataPoint>();
//        var catergories = DBNull.employeeRecognitions.Where(c => c.Award.Count > 0);
//        try
//        {
//            foreach (var cat in catergories)
//            {
//                var x = cat.Award.Count();
//                var y = catergories.CategoryName;
//                _dataPoints.Add(new DataPoint(x, y));
//            }
//            ViewBag.chartType = chartType;
//            ViewBag.chartTitle = "Number of Each Core Value Received";
//            ViewBag.DataPoints = JsonConvert.SerializeObject(_dataPoints.ToList(), _jsonSetting);
//        }
//        catch (System.Data.Entity.Core.EntityException)
//        {

//            return View("Error");
//        }
//        catch (System.Data.SqlClient.SqlException)
//        {
//            return View("Error");
//        }
//        return View();

//    }
//}

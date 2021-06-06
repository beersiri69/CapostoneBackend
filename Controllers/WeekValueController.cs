using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Http;
using System.Web.Http.Cors;
using OSIsoft.AF.PI;
using OSIsoft.AF.Time;

namespace Backendtest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class WeekValueController : ApiController
    {
        private PIServer _piserver;
        private string _piserverIP = "202.44.12.146";
        private readonly NetworkCredential cred = new NetworkCredential("Group2", "inc.382");

        private object CheckConnect(string tag, string StartDate, string EndDate)
        {
            var cn = piConnect();
            if (cn.ConnectionInfo.IsConnected)
            {
                var point = PIPoint.FindPIPoint(cn, tag);
                var timeRange = new AFTimeRange(StartDate, EndDate);

                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                List<(double, string)> valueAll = new List<(double, string)>();
                foreach (var item in value)
                {
                    valueAll.Add((Convert.ToDouble(item.Value), Convert.ToString(item.Timestamp)));
                }
                return Ok(new { result = valueAll, message = "success" });
            }
            else
            {
                return Ok(new { message = "can not connect to pi server" });
            }
        }
        private PIServer piConnect()
        {
            // connecto PI Server 
            _piserver = new PIServers()[_piserverIP];
            _piserver.Connect(cred);

            return _piserver;
        }

        [HttpGet]
        [ActionName("WIPW")]
        public IHttpActionResult WIPW(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA78", "A002-0300-S3-DATA79", "A002-0100-S3-DATA80",
                                 "A002-0100-S3-DATA81", "A002-0400-S3-DATA82"};

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 5))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }

        [HttpGet]
        [ActionName("QueueW")]
        public IHttpActionResult QueueW(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA18", "A002-0300-S3-DATA19", "A002-0100-S3-DATA20",
                                 "A002-0100-S3-DATA21", "A002-0400-S3-DATA22",
                                 "A002-0000-S3-DATA33", "A002-0300-S3-DATA34", "A002-0100-S3-DATA35",
                                 "A002-0100-S3-DATA36", "A002-0400-S3-DATA37"};

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 10))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }

        [HttpGet]
        [ActionName("DonutW")]
        public IHttpActionResult DonutW(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA68", "A002-0100-S3-DATA69" };

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 2))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }

        [HttpGet]
        [ActionName("UtilizeW")]
        public IHttpActionResult UtilizeW(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA83", "A002-0300-S3-DATA84", "A002-0100-S3-DATA85",
                                 "A002-0100-S3-DATA86","A002-0400-S3-DATA87"};

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 5))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }

        [HttpGet]
        [ActionName("ShowAmountW")]
        public IHttpActionResult ShowAmountW(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA3", "A002-0100-S3-DATA4", "A002-0000-S3-DATA9",
                                 "A002-0000-S3-DATA10","A002-0100-S3-DATA74","A002-0100-S3-DATA75","A002-0000-S3-DATA65"};

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 7))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }


        [HttpGet]
        [ActionName("Income")]
        public IHttpActionResult Income(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA3", "A002-0100-S3-DATA4", "A002-0000-S3-DATA9",
                                 "A002-0000-S3-DATA10","A002-0100-S3-DATA74","A002-0100-S3-DATA75","A002-0000-S3-DATA65"};

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 7))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }









        [HttpGet]
        [ActionName("GetByID")]
        public IHttpActionResult GetByID(string id)
        {
            var Tag_Search = id;

            return (IHttpActionResult)CheckConnect(Tag_Search, "*-4y", "*");
        }
    }
}

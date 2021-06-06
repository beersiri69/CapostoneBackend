using OSIsoft.AF.PI;
using OSIsoft.AF.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Http;
using System.Web.Http.Cors;


namespace Backendtest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class MonthValueController : ApiController
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
        [ActionName("WIPM")]
        public IHttpActionResult WIPM(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA48", "A002-0300-S3-DATA49", "A002-0100-S3-DATA50",
                                 "A002-0100-S3-DATA51", "A002-0400-S3-DATA52"};

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
        [ActionName("QueueM")]
        public IHttpActionResult QueueM(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA23", "A002-0300-S3-DATA24", "A002-0100-S3-DATA25",
                                 "A002-0100-S3-DATA26", "A002-0400-S3-DATA27",
                                 "A002-0000-S3-DATA38", "A002-0300-S3-DATA39", "A002-0100-S3-DATA40",
                                 "A002-0100-S3-DATA41", "A002-0400-S3-DATA42",};

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
        [ActionName("DonutM")]
        public IHttpActionResult DonutM(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA70", "A002-0100-S3-DATA71"};

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
        [ActionName("UtilizeM")]
        public IHttpActionResult UtilizeM(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA58", "A002-0300-S3-DATA59", "A002-0100-S3-DATA60",
                                 "A002-0100-S3-DATA61","A002-0400-S3-DATA62"};

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
        [ActionName("ShowAmountM")]
        public IHttpActionResult ShowAmountM(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA5", "A002-0100-S3-DATA6", "A002-0000-S3-DATA11",
                                 "A002-0000-S3-DATA12","A002-0100-S3-DATA76","A002-0100-S3-DATA77","A002-0000-S3-DATA64"};

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

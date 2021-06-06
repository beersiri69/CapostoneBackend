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
    public class DailyValueController : ApiController
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
        [ActionName("WIPD")]
        public IHttpActionResult WIPD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA43", "A002-0300-S3-DATA44", "A002-0100-S3-DATA45",
                                 "A002-0100-S3-DATA46", "A002-0400-S3-DATA47"};

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
        [ActionName("QueueD")]
        public IHttpActionResult QueueD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA13", "A002-0300-S3-DATA14", "A002-0100-S3-DATA15",
                                 "A002-0100-S3-DATA16", "A002-0400-S3-DATA17",
                                 "A002-0000-S3-DATA28", "A002-0300-S3-DATA29", "A002-0100-S3-DATA30",
                                 "A002-0100-S3-DATA31", "A002-0400-S3-DATA32"};

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
        [ActionName("DonutD")]
        public IHttpActionResult DonutD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA66", "A002-0100-S3-DATA67" };

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
        [ActionName("UtilizeD")]
        public IHttpActionResult UtilizeD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA53", "A002-0300-S3-DATA54", "A002-0100-S3-DATA55",
                                 "A002-0100-S3-DATA56","A002-0400-S3-DATA57"};

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
        [ActionName("ShowAmountD")]
        public IHttpActionResult ShowAmountD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA1", "A002-0100-S3-DATA2", "A002-0000-S3-DATA7",
                                 "A002-0000-S3-DATA8","A002-0100-S3-DATA72","A002-0100-S3-DATA73","A002-0000-S3-DATA63"};

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

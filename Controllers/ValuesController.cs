using System;
using System.Collections.Generic;

using System.Net;

using System.Web.Http;
using System.Web.Http.Cors;
using OSIsoft.AF.PI;
using OSIsoft.AF.Time;

namespace Backendtest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class ValuesController : ApiController
    {
        private PIServer _piserver;
        private string _piserverIP = "202.44.12.146";
        private readonly NetworkCredential cred = new NetworkCredential("Group2", "inc.382");

        private object CheckConnect(string tag, string StartDate, string EndDate) {
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
        [ActionName("GetByID")]
        public IHttpActionResult GetByID(string id)
        {
            var Tag_Search = id;

            return (IHttpActionResult)CheckConnect(Tag_Search, "*-4y", "*");
        }

        [HttpGet]
        [ActionName("TruckinRange")]
        public IHttpActionResult TruckinRange(string Start,string End)
        {
            var Tag_Search = "A002-0000-S3-DATA7";
            var Cal_Start    =   cal_date.count_start(Start);
            var Cal_End      =   cal_date.count_start(End);
            var Search_Start =   "*-" + Cal_Start + "d";
            var Search_End   =   "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }

        [HttpGet]
        [ActionName("TruckinExact")]
        public IHttpActionResult TruckinExact(string id)
        {   
            var Tag_Search = "A002-0000-S3-DATA7";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start); 
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }

        [HttpGet]
        [ActionName("TruckinAll")]
        public IHttpActionResult TruckinAll()
        {
            var Tag_Search = "A002-0000-S3-DATA7";
            var Cal_Start = cal_date.count_start("2018-03-01");
            var Search_Start = "*-" + Cal_Start + "d"; 
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, "*");
        }
        [HttpGet]
        [ActionName("AmoutGExact")]
        public IHttpActionResult AmoutGExact(string id)
        {
            var Tag_Search = "A002-0100-S3-DATA1";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("AmoutDExact")]
        public IHttpActionResult AmoutDExact(string id)
        {
            var Tag_Search = "A002-0100-S3-DATA2";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("TruckOutExact")]
        public IHttpActionResult TruckOutExact(string id)
        {
            var Tag_Search = "A002-0000-S3-DATA8";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("FailDExact")]
        public IHttpActionResult FailDExact(string id)
        {
            var Tag_Search = "A002-0100-S3-DATA72";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("FailGExact")]
        public IHttpActionResult FailGExact(string id)
        {
            var Tag_Search = "A002-0100-S3-DATA73";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("CycleExact")]
        public IHttpActionResult CycleExact(string id)
        {
            var Tag_Search = "A002-0000-S3-DATA63";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("DBusy")]
        public IHttpActionResult DBusy(string id)
        {
            var Tag_Search = "A002-0100-S3-DATA66";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("GBusy")]
        public IHttpActionResult GBusy(string id)
        {
            var Tag_Search = "A002-0100-S3-DATA67";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
       




    }
}

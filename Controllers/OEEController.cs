using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using OSIsoft.AF.PI;
using OSIsoft.AF.Time;
namespace Backendtest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class OEEController : ApiController
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
        //====================================   Percent A Percent P Percent Q   ========================================-


        [HttpGet]
        [ActionName("AllAPQD")]
        public IHttpActionResult AllAPQ(string id)
        {
            
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 32;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";

            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            

            string[] Taglist = { "A002-0100-S4-DATA1", "A002-0100-S4-DATA2", "A002-0100-S4-DATA3",
                                 "A002-0100-S4-DATA4", "A002-0100-S4-DATA5", "A002-0100-S4-DATA6",

                                 "A002-0100-S4-DATA9", "A002-0100-S4-DATA10", "A002-0100-S4-DATA11",
                                 "A002-0100-S4-DATA12","A002-0100-S4-DATA13","A002-0100-S4-DATA14",

                                  "A002-0100-S4-DATA27","A002-0100-S4-DATA28","A002-0100-S4-DATA29",
                                  "A002-0100-S4-DATA30","A002-0100-S4-DATA31","A002-0100-S4-DATA32",

                                  "A002-0100-S4-DATA15","A002-0100-S4-DATA16","A002-0100-S4-DATA17",
                                  "A002-0100-S4-DATA18","A002-0100-S4-DATA19","A002-0100-S4-DATA20"};


            /////////////////////////////////////////////////////////WAIT FOR %Q////////////////////////////////
            List<(double, string)> valueAll = new List<(double, string)>();

            foreach (int i in Enumerable.Range(0, 24))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
               
            }
           
      
            return Ok(new { result = valueAll, message = "success" });

        }
        //====================================     Work in Process     ====================================
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

            List<(double, string, string)> valueAll = new List<(double, string, string)>();
            foreach (int i in Enumerable.Range(0, 5))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp), Taglist[i]));
            }
            return Ok(new { result = valueAll, message = "success" });

        }
            //====================================     Average No. OF Queue     ====================================

        [HttpGet]
        [ActionName("AVGNOQD")]
        public IHttpActionResult AVGNOQD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA13", "A002-0300-S3-DATA14", "A002-0100-S3-DATA15",
                                 "A002-0100-S3-DATA16", "A002-0400-S3-DATA17"};

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 5))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }

        //====================================     Average Time. OF Queue     ====================================
        
        [HttpGet]
        [ActionName("AVGTQD")]
        public IHttpActionResult AVGTQD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0000-S3-DATA28", "A002-0300-S3-DATA29","A002-0100-S3-DATA30", "A002-0100-S3-DATA31",
                                 "A002-0400-S3-DATA32"};

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 5))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }
        //====================================     Fail Day    ====================================

        [HttpGet]
        [ActionName("FailD")]
        public IHttpActionResult FailD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA72", "A002-0100-S3-DATA73" };

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
        [ActionName("FailW")]
        public IHttpActionResult FailW(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA74", "A002-0100-S3-DATA75" };

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
        [ActionName("FailM")]
        public IHttpActionResult FailM(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA76", "A002-0100-S3-DATA77" };

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 2))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }

        // //==================================================== Busy =======================================
        [HttpGet]
        [ActionName("BusyD")]
        public IHttpActionResult BusyD(string id)
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
        [ActionName("BusyW")]
        public IHttpActionResult BusyW(string id)
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
        [ActionName("BusyM")]
        public IHttpActionResult BusyM(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0100-S3-DATA70", "A002-0100-S3-DATA71" };

            List<(double, string)> valueAll = new List<(double, string)>();
            foreach (int i in Enumerable.Range(0, 2))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));
            }
            return Ok(new { result = valueAll, message = "success" });
        }

        /*
        [HttpGet]
        [ActionName("AVGTQD")]
        public IHttpActionResult AVGTQD(string id)
        {
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();
            string[] Taglist = { "A002-0300-S3-DATA29", "A002-0100-S3-DATA30", "A002-0100-S3-DATA31",
                                 "A002-0400-S3-DATA32", "A002-0000-S3-DATA33"};

            List<(double, string, string)> valueAll = new List<(double, string,string)>();

            foreach (int i in Enumerable.Range(0, 6))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);

                foreach (var item in value)
                {
                    valueAll.Add((Convert.ToDouble(item.Value), Convert.ToString(item.Timestamp), Taglist[i]));
                }               
            }
            return Ok(new { result = valueAll, message = "success" });
        }
     */

        //====================================Avialable====================================
        [HttpGet]
        [ActionName("A1")]
        public IHttpActionResult A1(string id)
        {
            var Tag_Search = "A002-0100-S4-DATA1";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("A2")]
        public IHttpActionResult A2(string id)
        {
            var Tag_Search = "A002-0100-S4-DATA2";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("A3")]
        public IHttpActionResult A3(string id)
        {
            var Tag_Search = "A002-0100-S4-DATA3";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("A4")]
        public IHttpActionResult A4(string id)
        {
            var Tag_Search = "A002-0100-S4-DATA4";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
        [HttpGet]
        [ActionName("A5")]
        public IHttpActionResult A5(string id)
        {
            var Tag_Search = "A002-0100-S4-DATA5";
            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";
            return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
        }
    
    //====================================Performance====================================
    [HttpGet]
    [ActionName("P1")]
    public IHttpActionResult P1(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA9";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("P2")]
    public IHttpActionResult P2(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA10";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("P3")]
    public IHttpActionResult P3(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA11";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("P4")]
    public IHttpActionResult P4(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA12";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("P5")]
    public IHttpActionResult P5(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA13";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
        //====================================NOTFINISH====================================
        //====================================NOTFINISH====================================
        //====================================NOTFINISH====================================
        //====================================NOTFINISH====================================
        //====================================NOTFINISH====================================
        //====================================NOTFINISH====================================
    [HttpGet]
    [ActionName("Q1")]
    public IHttpActionResult Q1(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA1";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("Q2")]
    public IHttpActionResult Q2(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA2";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("Q3")]
    public IHttpActionResult Q3(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA3";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("Q4")]
    public IHttpActionResult Q4(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA4";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }
    [HttpGet]
    [ActionName("Q5")]
    public IHttpActionResult Q5(string id)
    {
        var Tag_Search = "A002-0100-S4-DATA5";
        var Start = id;
        var Cal_Start = cal_date.count_start(Start);
        var Cal_End = Cal_Start - 1;
        var Search_Start = "*-" + Cal_Start + "d";
        var Search_End = "*-" + Cal_End + "d";
        return (IHttpActionResult)CheckConnect(Tag_Search, Search_Start, Search_End);
    }

        [HttpGet]
        [ActionName("AllAPQDM")]
        public IHttpActionResult AllAPQDM(string id)
        {

            var Start = id;
            var Cal_Start = cal_date.count_start(Start);
            var Cal_End = Cal_Start - 1;
            var Search_Start = "*-" + Cal_Start + "d";
            var Search_End = "*-" + Cal_End + "d";

            var timeRange = new AFTimeRange(Search_Start, Search_End);
            var cn = piConnect();


            string[] Taglist = { "A002-0100-S4-DATA33", "A002-0100-S4-DATA34", "A002-0100-S4-DATA35",
                                 "A002-0100-S4-DATA36", "A002-0100-S4-DATA37", "A002-0100-S4-DATA38",

                                 "A002-0100-S4-DATA39", "A002-0100-S4-DATA40", "A002-0100-S4-DATA41",
                                 "A002-0100-S4-DATA42","A002-0100-S4-DATA43","A002-0100-S4-DATA44",

                                  "A002-0100-S4-DATA45","A002-0100-S4-DATA46","A002-0100-S4-DATA47",
                                  "A002-0100-S4-DATA48","A002-0100-S4-DATA49","A002-0100-S4-DATA49",

                                  "A002-0100-S4-DATA51","A002-0100-S4-DATA52","A002-0100-S4-DATA53",
                                  "A002-0100-S4-DATA54","A002-0100-S4-DATA55","A002-0100-S4-DATA56"};


            /////////////////////////////////////////////////////////WAIT FOR %Q////////////////////////////////
            List<(double, string)> valueAll = new List<(double, string)>();

            foreach (int i in Enumerable.Range(0, 24))
            {
                var point = PIPoint.FindPIPoint(cn, Taglist[i]);
                var value = point.RecordedValues(timeRange, 0, "", true, 0);
                valueAll.Add((Convert.ToDouble(value[0].Value), Convert.ToString(value[0].Timestamp)));

            }


            return Ok(new { result = valueAll, message = "success" });

        }
    }
}




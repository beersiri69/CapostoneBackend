using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Data.Entity;
using Backendtest.DbContxt;
using System.Data.Entity.Core.Objects;

namespace Backendtest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class AuthController : ApiController
    {
        // GET: Auth
   

        [HttpGet]
        [ActionName("staff")]
        public IHttpActionResult GetStaff()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                var users = _DBContext.Staff.ToList();
                return Ok(new { result = users, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("Payment")]
        public IHttpActionResult GetPayment()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                var Payment = _DBContext.Payment.ToList();
                


                return Ok(new { result = Payment, message = "success" });
            }
        }
        [HttpGet]
        [ActionName("Transactionfromstart")]
        public IHttpActionResult Transactionfromstart(string id)
        {   
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
               
                DateTime oDate = Convert.ToDateTime(id);

                var Transac = _DBContext.Transac.Where(o => o.Date < oDate).ToList();
                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("TransactionByDate")]
        public IHttpActionResult TransactionByDate(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {                
                DateTime oDate = DateTime.Parse(id);
                var Transac = _DBContext.Transac.Where(t => t.Date == oDate).ToList();
                
                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("Transaction")]
        public IHttpActionResult GetTransac()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                var Transac = _DBContext.Transac.ToList();
                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("Customer")]
        public IHttpActionResult GetCustomer()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {

                var users = _DBContext.Customer.ToList();
                return Ok(new { result = users, message = "success" });
            }

        }

        [HttpGet]
        [ActionName("login")]
        public IHttpActionResult LoginbyID(string id)
        {
            using (CapstoneV3Entities9 _databaseContext = new CapstoneV3Entities9())
            {
                // Where in DB (Single or default)
                var users = _databaseContext.Staff.SingleOrDefault(o => o.Staff_ID == id);
                return Ok(new { result = users, message = "sucess" });
            }
        }

        [HttpGet]
        [ActionName("searchStaffby")]
        public IHttpActionResult searchStaffby(string id)
        {
            using (CapstoneV3Entities9 _databaseContext = new CapstoneV3Entities9())
            {
                // Where in DB (Single or default)
                var users = _databaseContext.Staff.Where(o => o.Staff_ID.Contains(id)).ToList();
                return Ok(new { result = users, message = "sucess" });
            }
        }

        [HttpGet]
        [ActionName("searchCustomerby")]
        public IHttpActionResult searchCustomerby(string id)
        {
            using (CapstoneV3Entities9 _databaseContext = new CapstoneV3Entities9())
            {
                // Where in DB (Single or default)
                var users = _databaseContext.Customer.Where(o => o.Customer_ID.Contains(id)).ToList();
                
                return Ok(new { result = users, message = "sucess" });
            }
        }

        [HttpGet]
        [ActionName("IncomeBeforeDate")]
        public IHttpActionResult IncomfromStart(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                DateTime oDate = Convert.ToDateTime(id);
                var Transac = _DBContext.Income.ToList().LastOrDefault(o => o.date == oDate);

                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("SumCashBeforeDate")]
        public IHttpActionResult SumCashBeforeDate(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                DateTime oDate = DateTime.Parse(id);
                var Transac = _DBContext.Transac.Where(t => t.Date < oDate).ToList();

                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("GetExpense")]
        public IHttpActionResult GetExpense()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                var Transac = _DBContext.Expense.ToList();

                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("IncomeBetween")]
        public IHttpActionResult IncomeBetween(string Start , string End)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                DateTime StartDate = DateTime.Parse(Start);
                DateTime EndDate = DateTime.Parse(End);

                var Transac = _DBContext.Income.Where(t => t.date >= StartDate && t.date<= EndDate).ToList();

                return Ok(new { result = Transac, message = "success" });
            }
        }
        [HttpGet]
        [ActionName("DeliverAll")]
        public IHttpActionResult DeliverAll()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {

                var Transac = _DBContext.Deliver.ToList();

                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("PaymentAll")]
        public IHttpActionResult PaymentAll()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                var Transac = _DBContext.Payment.ToList();
                return Ok(new { result = Transac, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("PurchaseAll")]
        public IHttpActionResult PurchaseAll()
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                var Transac = _DBContext.Purchase_Order.ToList();

                return Ok(new { result = Transac, message = "success" });
            }
        }
        /*
        [HttpGet]
        [ActionName("DeliverByDate")]
        public IHttpActionResult DeliverByDate(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                DateTime oDate = DateTime.Parse(id);
                var Transac = _DBContext.Deliver.Where(t => t.Date == oDate).ToList();

                return Ok(new { result = Transac, message = "success" });
            }
        }
        */
        [HttpGet]
        [ActionName("PaymentByDate")]
        public IHttpActionResult PaymentByDate(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
               
                DateTime oDate = DateTime.Parse(id);


                var values = _DBContext.Purchase_Order.Where(x => x.Deliver_Date==oDate).Select(x => x.e_Bill_NO).ToString();

                var value2 = _DBContext.Payment.Where(p => values.Contains(p.e_Bill_NO)).ToList();
                return Ok(new { result = value2, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("PO")]
        public IHttpActionResult Pe(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {

                var values = _DBContext.Purchase_Order.Where(x => x.PO_NO == id).Select(x => x.e_Bill_NO).First().ToString();

                var Invoice = _DBContext.Payment.Where(z => z.e_Bill_NO == values).Select( x=> x.Invoice_NO).ToList();

                var PO = _DBContext.Purchase_Order.Where(x => x.PO_NO == id).ToList();

                var value1 = _DBContext.Purchase_Order.Where(z => z.PO_NO == id).Select(x => x.Deliver_Date).ToList();
                var value2 = _DBContext.Price.Where(p => value1.Contains(p.Date)).ToList();

                return Ok(new { result = Invoice,PO, value1,value2, message = "success" });
            }
        }
        [HttpGet]
        [ActionName("Recon")]
        public IHttpActionResult tamp(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                var values = _DBContext.Deliver.Where(x => x.PO_NO == id).Select(x => new{ x.Truck_NO,x.Deliver_ID}).ToList();
                var value3 = _DBContext.Purchase_Order.Where(x => x.PO_NO == id).Select(x =>new { x.Fuel_Amount,x.Gas_type,x.e_Bill_NO,x.Deliver_Date,x.Customer_ID}).ToList();
               
                var value4 = _DBContext.Purchase_Order.Where(x => x.PO_NO == id).Select(x => x.e_Bill_NO).ToList();
                var value6 = _DBContext.Payment.Where(p => value4.Contains(p.e_Bill_NO)).Select(p => p.Invoice_NO).ToList();
                return Ok(new { result = values,purchase_order = value3,invoice = value6, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("Reconlist")]
        public IHttpActionResult Reconlist(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                DateTime oDate = DateTime.Parse(id);

                var Purchase = _DBContext.Purchase_Order.Where(o => o.Deliver_Date == oDate).ToList();

                var PO_tok1 = _DBContext.Purchase_Order.Where(o => o.Deliver_Date == oDate).Select(x => x.e_Bill_NO).ToList();
                var Payment = _DBContext.Payment.Where(p => PO_tok1.Contains(p.e_Bill_NO)).Select(p => new { p.e_Bill_NO, p.Invoice_NO,p.Amount}).ToList();

                var PO_tok2 = _DBContext.Purchase_Order.Where(o => o.Deliver_Date == oDate).Select(x => x.PO_NO).ToList();
                var Deliver = _DBContext.Deliver.Where(p => PO_tok2.Contains(p.PO_NO)).Select(w => new { w.Deliver_ID,w.Truck_NO, w.Purchase_Order }).ToList();



                return Ok(new { Payment, Purchase, Deliver, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("InventoryStock")]
        public IHttpActionResult InventoryStock(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                if(id == "1")
                {

                }
                else if (id == "2")
                {

                }
                else if (id == "3")
                {

                }
                else
                {

                }

                var result = _DBContext.Income.ToList();

                //return Ok(new { Deliver, Payment, message = "success" });
                return Ok(new { result= result, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("Invoice")]
        public IHttpActionResult Invoice(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {

                var PO = _DBContext.Purchase_Order.Where(p => p.PO_NO == id).ToList();

                var Getdate = _DBContext.Purchase_Order.Where(p => p.PO_NO == id).Select(x => x.Deliver_Date).First();

                var Price = _DBContext.Price.Where(p => p.Date == Getdate).ToList();

                var GetCustomer = _DBContext.Purchase_Order.Where(p => p.PO_NO == id).Select(x => x.Customer_ID).First();

                var Customer = _DBContext.Customer.Where(p => p.Customer_ID == GetCustomer).Select(x => new {x.Customer_Title, x.Customer_Name , x.Customer_Surname,x.Taxpayer_ID } ).ToList();

                var GetPlayment = _DBContext.Purchase_Order.Where(p => p.PO_NO == id).Select(x => x.e_Bill_NO).First();

                var Payment = _DBContext.Payment.Where(p => p.e_Bill_NO == GetPlayment).Select(x => x.Invoice_NO).First();
                //return Ok(new { Deliver, Payment, message = "success" });
                return Ok(new { result = PO, Price, Customer, GetPlayment, Payment, message = "success" });
            }
        }

        [HttpGet]
        [ActionName("PurchaseByDate")]
        public IHttpActionResult PurchaseByDate(string id)
        {
            using (CapstoneV3Entities9 _DBContext = new CapstoneV3Entities9())
            {
                DateTime oDate = DateTime.Parse(id);
                var Transac = _DBContext.Purchase_Order.Where(t => t.Deliver_Date == oDate).ToList();

                return Ok(new { result = Transac, message = "success" });
            }
        }
    }
}
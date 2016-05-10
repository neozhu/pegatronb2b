


using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Infrastructure;
using pegatronb2b.Web.Models;
using pegatronb2b.Web.Services;
using pegatronb2b.Web.Repositories;
using pegatronb2b.Web.Extensions;


namespace pegatronb2b.Web.Controllers
{
    public class PgaGrsController : Controller
    {
        
        //Please RegisterType UnityConfig.cs
        //container.RegisterType<IRepositoryAsync<PgaGr>, Repository<PgaGr>>();
        //container.RegisterType<IPgaGrService, PgaGrService>();
        
        //private B2BContext db = new B2BContext();
        private readonly IPgaGrService  _pgaGrService;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public PgaGrsController (IPgaGrService  pgaGrService, IUnitOfWorkAsync unitOfWork)
        {
            _pgaGrService  = pgaGrService;
            _unitOfWork = unitOfWork;
        }

        // GET: PgaGrs/Index
        public ActionResult Index()
        {
            
            //var pgagrs  = _pgaGrService.Queryable().AsQueryable();
            //return View(pgagrs  );
			return View();
        }

        // Get :PgaGrs/PageList
        // For Index View Boostrap-Table load  data 
        [HttpGet]
        public ActionResult GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            int totalCount = 0;
            //int pagenum = offset / limit +1;
                        var pgagrs  = _pgaGrService.Query(new PgaGrQuery().Withfilter(filters)).OrderBy(n=>n.OrderBy(sort,order)).SelectPage(page, rows, out totalCount);
                        var datarows = pgagrs .Select(  n => new {  Id = n.Id , UDNo = n.UDNo , Material = n.Material , Quantity = n.Quantity , GrDate = n.GrDate , Warehouse = n.Warehouse , RC = n.RC , Plant = n.Plant , Vendor = n.Vendor , GRNo = n.GRNo , GRItem = n.GRItem , Area = n.Area , Brand = n.Brand , TransmitId = n.TransmitId , StoreKey = n.StoreKey , ReceiptKey = n.ReceiptKey , ReceiptDate = n.ReceiptDate , QtyReceived = n.QtyReceived , Status = n.Status , Susr1 = n.Susr1 , Susr2 = n.Susr2 , ReceiptType = n.ReceiptType , CreatedDate = n.CreatedDate , ModifiedDate = n.ModifiedDate , CreatedBy = n.CreatedBy , ModifiedBy = n.ModifiedBy }).ToList();
            var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }

		[HttpPost]
		public ActionResult SaveData(PgaGrChangeViewModel pgagrs)
        {
            if (pgagrs.updated != null)
            {
                foreach (var updated in pgagrs.updated)
                {
                    _pgaGrService.Update(updated);
                }
            }
            if (pgagrs.deleted != null)
            {
                foreach (var deleted in pgagrs.deleted)
                {
                    _pgaGrService.Delete(deleted);
                }
            }
            if (pgagrs.inserted != null)
            {
                foreach (var inserted in pgagrs.inserted)
                {
                    _pgaGrService.Insert(inserted);
                }
            }
            _unitOfWork.SaveChanges();

            return Json(new {Success=true}, JsonRequestBehavior.AllowGet);
        }

		
		
       
        // GET: PgaGrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaGr pgaGr = _pgaGrService.Find(id);
            if (pgaGr == null)
            {
                return HttpNotFound();
            }
            return View(pgaGr);
        }
        

        // GET: PgaGrs/Create
        public ActionResult Create()
        {
            PgaGr pgaGr = new PgaGr();
            //set default value
            return View(pgaGr);
        }

        // POST: PgaGrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UDNo,Material,Quantity,GrDate,Warehouse,RC,Plant,Vendor,GRNo,GRItem,Area,Brand,TransmitId,StoreKey,ReceiptKey,ReceiptDate,QtyReceived,Status,Susr1,Susr2,ReceiptType,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PgaGr pgaGr)
        {
            if (ModelState.IsValid)
            {
             				_pgaGrService.Insert(pgaGr);
                           _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a PgaGr record");
                return RedirectToAction("Index");
            }

            if (Request.IsAjaxRequest())
            {
                var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(pgaGr);
        }

        // GET: PgaGrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaGr pgaGr = _pgaGrService.Find(id);
            if (pgaGr == null)
            {
                return HttpNotFound();
            }
            return View(pgaGr);
        }

        // POST: PgaGrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UDNo,Material,Quantity,GrDate,Warehouse,RC,Plant,Vendor,GRNo,GRItem,Area,Brand,TransmitId,StoreKey,ReceiptKey,ReceiptDate,QtyReceived,Status,Susr1,Susr2,ReceiptType,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PgaGr pgaGr)
        {
            if (ModelState.IsValid)
            {
                pgaGr.ObjectState = ObjectState.Modified;
                				_pgaGrService.Update(pgaGr);
                                
                _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a PgaGr record");
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(pgaGr);
        }

        // GET: PgaGrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaGr pgaGr = _pgaGrService.Find(id);
            if (pgaGr == null)
            {
                return HttpNotFound();
            }
            return View(pgaGr);
        }

        // POST: PgaGrs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PgaGr pgaGr =  _pgaGrService.Find(id);
             _pgaGrService.Delete(pgaGr);
            _unitOfWork.SaveChanges();
           if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            DisplaySuccessMessage("Has delete a PgaGr record");
            return RedirectToAction("Index");
        }


       

 

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

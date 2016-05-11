


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
    public class PgaKittingsController : Controller
    {
        
        //Please RegisterType UnityConfig.cs
        //container.RegisterType<IRepositoryAsync<PgaKitting>, Repository<PgaKitting>>();
        //container.RegisterType<IPgaKittingService, PgaKittingService>();
        
        //private B2BContext db = new B2BContext();
        private readonly IPgaKittingService  _pgaKittingService;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public PgaKittingsController (IPgaKittingService  pgaKittingService, IUnitOfWorkAsync unitOfWork)
        {
            _pgaKittingService  = pgaKittingService;
            _unitOfWork = unitOfWork;
        }

        // GET: PgaKittings/Index
        public ActionResult Index()
        {
            
            //var pgakittings  = _pgaKittingService.Queryable().AsQueryable();
            //return View(pgakittings  );
			return View();
        }

        // Get :PgaKittings/PageList
        // For Index View Boostrap-Table load  data 
        [HttpGet]
        public ActionResult GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            int totalCount = 0;
            //int pagenum = offset / limit +1;
                        var pgakittings  = _pgaKittingService.Query(new PgaKittingQuery().Withfilter(filters)).OrderBy(n=>n.OrderBy(sort,order)).SelectPage(page, rows, out totalCount);
                        var datarows = pgakittings .Select(  n => new {  Id = n.Id , SeqId = n.SeqId , Plant = n.Plant , HubId = n.HubId , PdLine = n.PdLine , TransType = n.TransType , MO = n.MO , Stage = n.Stage , ItemNo = n.ItemNo , Material = n.Material , Description = n.Description , Keeper = n.Keeper , FromWH = n.FromWH , ToWH = n.ToWH , RequestQty = n.RequestQty , Building = n.Building , Dock = n.Dock , RequestDate = n.RequestDate , Remark = n.Remark , LotNo = n.LotNo , UDNo = n.UDNo , CloseDateTime = n.CloseDateTime , KittingId = n.KittingId , OrderKey = n.OrderKey , StoreKey = n.StoreKey , ShipDate = n.ShipDate , ShipQty = n.ShipQty , OrderStatus = n.OrderStatus , Status = n.Status , Remark1 = n.Remark1 , Note = n.Note , Unit = n.Unit , TrailerNumber = n.TrailerNumber }).ToList();
            var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }

		[HttpPost]
		public ActionResult SaveData(PgaKittingChangeViewModel pgakittings)
        {
            if (pgakittings.updated != null)
            {
                foreach (var updated in pgakittings.updated)
                {
                    _pgaKittingService.Update(updated);
                }
            }
            if (pgakittings.deleted != null)
            {
                foreach (var deleted in pgakittings.deleted)
                {
                    _pgaKittingService.Delete(deleted);
                }
            }
            if (pgakittings.inserted != null)
            {
                foreach (var inserted in pgakittings.inserted)
                {
                    _pgaKittingService.Insert(inserted);
                }
            }
            _unitOfWork.SaveChanges();

            return Json(new {Success=true}, JsonRequestBehavior.AllowGet);
        }

		
		
       
        // GET: PgaKittings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaKitting pgaKitting = _pgaKittingService.Find(id);
            if (pgaKitting == null)
            {
                return HttpNotFound();
            }
            return View(pgaKitting);
        }
        

        // GET: PgaKittings/Create
        public ActionResult Create()
        {
            PgaKitting pgaKitting = new PgaKitting();
            //set default value
            return View(pgaKitting);
        }

        // POST: PgaKittings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SeqId,Plant,HubId,PdLine,TransType,MO,Stage,ItemNo,Material,Description,Keeper,FromWH,ToWH,RequestQty,Building,Dock,RequestDate,Remark,LotNo,UDNo,CloseDateTime,KittingId,OrderKey,StoreKey,ShipDate,ShipQty,OrderStatus,Status,Remark1,Note,Unit,TrailerNumber,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PgaKitting pgaKitting)
        {
            if (ModelState.IsValid)
            {
             				_pgaKittingService.Insert(pgaKitting);
                           _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a PgaKitting record");
                return RedirectToAction("Index");
            }

            if (Request.IsAjaxRequest())
            {
                var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(pgaKitting);
        }

        // GET: PgaKittings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaKitting pgaKitting = _pgaKittingService.Find(id);
            if (pgaKitting == null)
            {
                return HttpNotFound();
            }
            return View(pgaKitting);
        }

        // POST: PgaKittings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SeqId,Plant,HubId,PdLine,TransType,MO,Stage,ItemNo,Material,Description,Keeper,FromWH,ToWH,RequestQty,Building,Dock,RequestDate,Remark,LotNo,UDNo,CloseDateTime,KittingId,OrderKey,StoreKey,ShipDate,ShipQty,OrderStatus,Status,Remark1,Note,Unit,TrailerNumber,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PgaKitting pgaKitting)
        {
            if (ModelState.IsValid)
            {
                pgaKitting.ObjectState = ObjectState.Modified;
                				_pgaKittingService.Update(pgaKitting);
                                
                _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a PgaKitting record");
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(pgaKitting);
        }

        // GET: PgaKittings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaKitting pgaKitting = _pgaKittingService.Find(id);
            if (pgaKitting == null)
            {
                return HttpNotFound();
            }
            return View(pgaKitting);
        }

        // POST: PgaKittings/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PgaKitting pgaKitting =  _pgaKittingService.Find(id);
             _pgaKittingService.Delete(pgaKitting);
            _unitOfWork.SaveChanges();
           if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            DisplaySuccessMessage("Has delete a PgaKitting record");
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

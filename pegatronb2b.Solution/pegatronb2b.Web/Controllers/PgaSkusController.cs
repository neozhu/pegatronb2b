


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
    public class PgaSkusController : Controller
    {
        
        //Please RegisterType UnityConfig.cs
        //container.RegisterType<IRepositoryAsync<PgaSku>, Repository<PgaSku>>();
        //container.RegisterType<IPgaSkuService, PgaSkuService>();
        
        //private B2BContext db = new B2BContext();
        private readonly IPgaSkuService  _pgaSkuService;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public PgaSkusController (IPgaSkuService  pgaSkuService, IUnitOfWorkAsync unitOfWork)
        {
            _pgaSkuService  = pgaSkuService;
            _unitOfWork = unitOfWork;
        }

        // GET: PgaSkus/Index
        public ActionResult Index()
        {
            
            //var pgaskus  = _pgaSkuService.Queryable().AsQueryable();
            //return View(pgaskus  );
			return View();
        }

        // Get :PgaSkus/PageList
        // For Index View Boostrap-Table load  data 
        [HttpGet]
        public ActionResult GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            int totalCount = 0;
            //int pagenum = offset / limit +1;
                        var pgaskus  = _pgaSkuService.Query(new PgaSkuQuery().Withfilter(filters)).OrderBy(n=>n.OrderBy(sort,order)).SelectPage(page, rows, out totalCount);
                        var datarows = pgaskus .Select(  n => new {  Id = n.Id , Sku = n.Sku , Description = n.Description , StoreKey = n.StoreKey , Keeper = n.Keeper , Warehouse = n.Warehouse , MOQ = n.MOQ , LotNo = n.LotNo , Mo = n.Mo }).ToList();
            var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }

		[HttpPost]
		public ActionResult SaveData(PgaSkuChangeViewModel pgaskus)
        {
            if (pgaskus.updated != null)
            {
                foreach (var updated in pgaskus.updated)
                {
                    _pgaSkuService.Update(updated);
                }
            }
            if (pgaskus.deleted != null)
            {
                foreach (var deleted in pgaskus.deleted)
                {
                    _pgaSkuService.Delete(deleted);
                }
            }
            if (pgaskus.inserted != null)
            {
                foreach (var inserted in pgaskus.inserted)
                {
                    _pgaSkuService.Insert(inserted);
                }
            }
            _unitOfWork.SaveChanges();

            return Json(new {Success=true}, JsonRequestBehavior.AllowGet);
        }

		
		
       
        // GET: PgaSkus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaSku pgaSku = _pgaSkuService.Find(id);
            if (pgaSku == null)
            {
                return HttpNotFound();
            }
            return View(pgaSku);
        }
        

        // GET: PgaSkus/Create
        public ActionResult Create()
        {
            PgaSku pgaSku = new PgaSku();
            //set default value
            return View(pgaSku);
        }

        // POST: PgaSkus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sku,Description,StoreKey,Keeper,Warehouse,MOQ,LotNo,Mo,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PgaSku pgaSku)
        {
            if (ModelState.IsValid)
            {
             				_pgaSkuService.Insert(pgaSku);
                           _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a PgaSku record");
                return RedirectToAction("Index");
            }

            if (Request.IsAjaxRequest())
            {
                var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(pgaSku);
        }

        // GET: PgaSkus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaSku pgaSku = _pgaSkuService.Find(id);
            if (pgaSku == null)
            {
                return HttpNotFound();
            }
            return View(pgaSku);
        }

        // POST: PgaSkus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sku,Description,StoreKey,Keeper,Warehouse,MOQ,LotNo,Mo,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PgaSku pgaSku)
        {
            if (ModelState.IsValid)
            {
                pgaSku.ObjectState = ObjectState.Modified;
                				_pgaSkuService.Update(pgaSku);
                                
                _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a PgaSku record");
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(pgaSku);
        }

        // GET: PgaSkus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgaSku pgaSku = _pgaSkuService.Find(id);
            if (pgaSku == null)
            {
                return HttpNotFound();
            }
            return View(pgaSku);
        }

        // POST: PgaSkus/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PgaSku pgaSku =  _pgaSkuService.Find(id);
             _pgaSkuService.Delete(pgaSku);
            _unitOfWork.SaveChanges();
           if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            DisplaySuccessMessage("Has delete a PgaSku record");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pegatronb2b.Web.Models
{
    [Serializable]
    public class GrResponseItem {
        public string ReceiptKey { get; set; }
        public string TransmitId { get; set; }
        public string TransmitDateTime { get; set; }
        public string UDNo { get; set; }
        public string GRNo { get; set; }
        public string GRItem { get; set; }
    }
    [Serializable]
    public class GrRequestItem{
        public string UDNo{get;set;}
        public string Material{get;set;}
        public decimal Quantity{get;set;}
        public string GrDate{get;set;}
        public string Warehouse{get;set;}
        public string RC{get;set;}
        public string Plant{get;set;}
        public string Vendor{get;set;}
        public string GRNo{get;set;}
        public string GRItem{get;set;}
        public string Area{get;set;}
        public string Brand{get;set;}
        public string TransmitId { get; set; }
        public string StoreKey { get; set; }
    }
    public class GrRequestViewModel
    {
        public GrRequestViewModel()
        {
            //GrRequestItems = new List<GrRequestItem>();
        }
        public  GrRequestItem[] GrRequestItems { get; set; }
    }

    public class GrReponseViewModel {
        public GrReponseViewModel()
        {
            //GrResponseItems = new List<GrResponseItem>();
        }
        public GrResponseItem[] GrResponseItems { get; set; }
    }
}
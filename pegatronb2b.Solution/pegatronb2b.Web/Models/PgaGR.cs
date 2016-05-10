using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pegatronb2b.Web.Models
{
    public partial class PgaGr:Entity
    {
        [Key]
        public int Id { get; set; }
        public string UDNo { get; set; }
        public string Material { get; set; }
        public decimal Quantity { get; set; }
        public string GrDate { get; set; }
        public string Warehouse { get; set; }
        public string RC { get; set; }
        public string Plant { get; set; }
        public string Vendor { get; set; }
        public string GRNo { get; set; }
        public string GRItem { get; set; }
        public string Area { get; set; }
        public string Brand { get; set; }
        public string TransmitId { get; set; }
        public string StoreKey { get; set; }
        
        public string ReceiptKey { get; set; }
        [Display(Name = "收货日期")]
        public DateTime? ReceiptDate { get; set; }
        [Display(Name = "实收数量")]
        public decimal QtyReceived { get; set; }

        public string Status { get; set; }

        [Display(Name="总件数" )]
        public string Susr1 { get; set; }
        [Display(Name = "包装代码")]
        public string Susr2 { get; set; }
         [Display(Name = "ASN代码")]
        public string ReceiptType { get; set; }

        #region IAuditable Members
        [Display(Name="创建时间")]
        public DateTime CreatedDate { get; set; }
         [Display(Name="修改时间")]
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(20)]
         [Display(Name="创建人")]
        public string CreatedBy { get; set; }
        [MaxLength(20)]
        [Display(Name="最后修改人")]
        public string ModifiedBy { get; set; }
        #endregion

    }
}
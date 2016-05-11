using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pegatronb2b.Web.Models
{
    public partial class PgaKitting:Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Index("IDX_kitting_SEQID", IsUnique=true)]
        public string SeqId { get; set; }
        [Required]
        public string Plant { get; set; }
        public string HubId { get; set; }
        public string PdLine { get; set; }
        public string TransType { get; set; }
        public string MO { get; set; }
        public string Stage { get; set; }
        public string ItemNo { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string Keeper { get; set; }
        public string FromWH { get; set; }
        public string ToWH { get; set; }
        public decimal RequestQty { get; set; }
        public string Building { get; set; }
        public string Dock { get; set; }
        public string RequestDate { get; set; }
        public string Remark { get; set; }
        public string LotNo { get; set; }

        public string UDNo{get;set;}
        public DateTime? CloseDateTime { get; set; }
        public string KittingId { get; set; }
        public string OrderKey { get; set; }
        public string StoreKey { get; set; }
        public string ShipDate { get; set; }
        public decimal ShipQty { get; set; }
        public string OrderStatus { get; set; }

        public string Status { get; set; }

        public string Remark1 { get; set; }
        public string Note { get; set; }
        

        public string Unit { get; set; }
        public string TrailerNumber { get; set; }


        #region IAuditable Members
        [Display(Name = "创建时间")]
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "修改时间")]
        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(20)]
        [Display(Name = "创建人")]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        [MaxLength(20)]
        [Display(Name = "最后修改人")]
        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }
        #endregion



    }
}
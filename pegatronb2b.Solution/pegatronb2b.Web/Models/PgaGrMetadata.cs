using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace pegatronb2b.Web.Models
{
    [MetadataType(typeof(PgaGrMetadata))]
    public partial class PgaGr
    {
    }

    public partial class PgaGrMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 过账编号")]
        [Display(Name = "过账编号")]
        [MaxLength(50)]
        public string UDNo { get; set; }

        [Required(ErrorMessage = "Please enter : 料号(SKU)")]
        [Display(Name = "料号(SKU)")]
        [MaxLength(50)]
        public string Material { get; set; }

        [Required(ErrorMessage = "Please enter : 预收数量")]
        [Display(Name = "预收数量")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Please enter : 预收货日期")]
        [Display(Name = "预收货日期")]
        [MaxLength(20)]
        public string GrDate { get; set; }

        [Display(Name = "仓库")]
        [MaxLength(50)]
        public string Warehouse { get; set; }

        [Display(Name = "RC")]
        [MaxLength(250)]
        public string RC { get; set; }

        [Display(Name = "车间")]
        [MaxLength(50)]
        public string Plant { get; set; }

        [Required(ErrorMessage = "Please enter : 供应商")]
        [Display(Name = "供应商")]
        [MaxLength(50)]
        public string Vendor { get; set; }

        [Required(ErrorMessage = "Please enter : 入库单号")]
        [Display(Name = "入库单号")]
        [MaxLength(50)]
        public string GRNo { get; set; }

        [Display(Name = "入库单行号")]
        [MaxLength(10)]
        public string GRItem { get; set; }

        [Display(Name = "库区")]
        [MaxLength(50)]
        public string Area { get; set; }

        [Display(Name = "品牌商")]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please enter : 批次号")]
        [Display(Name = "批次号")]
        [MaxLength(50)]
        public string TransmitId { get; set; }

        [Required(ErrorMessage = "Please enter : 货主")]
        [Display(Name = "货主")]
        [MaxLength(20)]
        public string StoreKey { get; set; }

        [Display(Name = "收货单号")]
        [MaxLength(30)]
        public string ReceiptKey { get; set; }

        [Display(Name = "实际收货日期")]
        public DateTime ReceiptDate { get; set; }

        [Display(Name = "实收数量")]
        public decimal QtyReceived { get; set; }

        [Display(Name = "收货单状态")]
        [MaxLength(10)]
        public string Status { get; set; }

        [Display(Name = "总件数")]
        [MaxLength(20)]
        public string Susr1 { get; set; }

        [Display(Name = "包装")]
        [MaxLength(20)]
        public string Susr2 { get; set; }

        [Display(Name = "ASN类型")]
        [MaxLength(10)]
        public string ReceiptType { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "创建人")]
        public string CreatedBy { get; set; }

        [Display(Name = "ModifiedBy")]
        public string ModifiedBy { get; set; }

    }




	public class PgaGrChangeViewModel
    {
        public IEnumerable<PgaGr> inserted { get; set; }
        public IEnumerable<PgaGr> deleted { get; set; }
        public IEnumerable<PgaGr> updated { get; set; }
    }

}

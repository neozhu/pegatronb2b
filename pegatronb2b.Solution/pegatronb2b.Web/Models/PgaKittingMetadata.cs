using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace pegatronb2b.Web.Models
{
    [MetadataType(typeof(PgaKittingMetadata))]
    public partial class PgaKitting
    {
    }

    public partial class PgaKittingMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "项号")]
        [MaxLength(50)]
        public string SeqId { get; set; }

        [Display(Name = "车间")]
        [MaxLength(30)]
        public string Plant { get; set; }

        [Display(Name = "仓库")]
        [MaxLength(30)]
        public string HubId { get; set; }

        [Display(Name = "产线")]
        [MaxLength(30)]
        public string PdLine { get; set; }

        [Display(Name = "出货类型")]
        [MaxLength(10)]
        public string TransType { get; set; }

        [Display(Name = "工单号")]
        [MaxLength(50)]
        public string MO { get; set; }

        [Display(Name = "站别")]
        [MaxLength(50)]
        public string Stage { get; set; }

        [Display(Name = "工单行号")]
        [MaxLength(10)]
        public string ItemNo { get; set; }

        [Display(Name = "料号")]
        [MaxLength(50)]
        public string Material { get; set; }

        [Display(Name = "描述")]
        [MaxLength(50)]
        public string Description { get; set; }

        [Display(Name = "仓管员")]
        [MaxLength(30)]
        public string Keeper { get; set; }

        [Display(Name = "自仓库")]
        [MaxLength(30)]
        public string FromWH { get; set; }

        [Display(Name = "至仓库")]
        [MaxLength(30)]
        public string ToWH { get; set; }

        [Display(Name = "需求数量")]
        public decimal RequestQty { get; set; }

        [Display(Name = "栋")]
        [MaxLength(30)]
        public string Building { get; set; }

        [Display(Name = "码头")]
        [MaxLength(30)]
        public string Dock { get; set; }

        [Display(Name = "需求日期")]
        [MaxLength(20)]
        public string RequestDate { get; set; }

        [Display(Name = "备注")]
        [MaxLength(50)]
        public string Remark { get; set; }

        [Display(Name = "LotNo")]
        [MaxLength(50)]
        public string LotNo { get; set; }

        [Display(Name = "过账编号")]
        [MaxLength(50)]
        public string UDNo { get; set; }

        [Display(Name = "过账日期")]
        public DateTime CloseDateTime { get; set; }

        [Display(Name = "批次号")]
        [MaxLength(50)]
        public string KittingId { get; set; }

        [Display(Name = "出货订单号")]
        [MaxLength(30)]
        public string OrderKey { get; set; }

        [Display(Name = "货主")]
        [MaxLength(20)]
        public string StoreKey { get; set; }

        [Display(Name = "出货日期")]
        [MaxLength(20)]
        public string ShipDate { get; set; }

        [Display(Name = "出货数量")]
        public decimal ShipQty { get; set; }

        [Display(Name = "订单状态")]
        [MaxLength(10)]
        public string OrderStatus { get; set; }

        [Display(Name = "上传状态")]
        [MaxLength(10)]
        public string Status { get; set; }

        [Display(Name = "备注1")]
        [MaxLength(50)]
        public string Remark1 { get; set; }

        [Display(Name = "备注2")]
        [MaxLength(50)]
        public string Note { get; set; }

        [Display(Name = "单位")]
        [MaxLength(10)]
        public string Unit { get; set; }

        [Display(Name = "运输车牌")]
        [MaxLength(10)]
        public string TrailerNumber { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "ModifiedBy")]
        public string ModifiedBy { get; set; }

    }




	public class PgaKittingChangeViewModel
    {
        public IEnumerable<PgaKitting> inserted { get; set; }
        public IEnumerable<PgaKitting> deleted { get; set; }
        public IEnumerable<PgaKitting> updated { get; set; }
    }

}

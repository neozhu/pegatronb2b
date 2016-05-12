using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace pegatronb2b.Web.Models
{
    [MetadataType(typeof(PgaSkuMetadata))]
    public partial class PgaSku
    {
    }

    public partial class PgaSkuMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : Sku")]
        [Display(Name = "Sku")]
        [MaxLength(50)]
        public string Sku { get; set; }

        [Required(ErrorMessage = "Please enter : 描述")]
        [Display(Name = "描述")]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter : 货主")]
        [Display(Name = "货主")]
        [MaxLength(30)]
        public string StoreKey { get; set; }

        [Display(Name = "仓管")]
        [MaxLength(50)]
        public string Keeper { get; set; }

        [Display(Name = "仓库")]
        [MaxLength(50)]
        public string Warehouse { get; set; }

        [Display(Name = "MOQ")]
        public int MOQ { get; set; }

        [Display(Name = "LOT")]
        [MaxLength(50)]
        public string LotNo { get; set; }

        [Display(Name = "Mo聊")]
        [MaxLength(50)]
        public string Mo { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "CreatedBy")]
        [MaxLength(30)]
        public string CreatedBy { get; set; }

        [Display(Name = "ModifiedBy")]
        [MaxLength(30)]
        public string ModifiedBy { get; set; }

    }




	public class PgaSkuChangeViewModel
    {
        public IEnumerable<PgaSku> inserted { get; set; }
        public IEnumerable<PgaSku> deleted { get; set; }
        public IEnumerable<PgaSku> updated { get; set; }
    }

}

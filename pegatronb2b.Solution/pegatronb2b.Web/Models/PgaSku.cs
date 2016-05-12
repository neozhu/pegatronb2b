using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pegatronb2b.Web.Models
{
    public  partial class PgaSku:Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        public string Description { get; set; }
        [Required]
        public string StoreKey { get; set; }
        [Required]
        public string Keeper { get; set; }
        [Required]
        public string Warehouse { get; set; }
        [Required]
        public int MOQ { get; set; }
        public string LotNo { get; set; }
        public string Mo { get; set; }

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
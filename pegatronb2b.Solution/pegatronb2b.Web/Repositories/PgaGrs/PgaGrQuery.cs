
                    
      
     
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using Repository.Pattern.Repositories;
using Repository.Pattern.Ef6;
using System.Web.WebPages;
using pegatronb2b.Web.Models;
using pegatronb2b.Web.Extensions;

namespace pegatronb2b.Web.Repositories
{
   public class PgaGrQuery:QueryObject<PgaGr>
    {
        public PgaGrQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.UDNo.Contains(search) || x.Material.Contains(search) || x.Quantity.ToString().Contains(search) || x.GrDate.Contains(search) || x.Warehouse.Contains(search) || x.RC.Contains(search) || x.Plant.Contains(search) || x.Vendor.Contains(search) || x.GRNo.Contains(search) || x.GRItem.Contains(search) || x.Area.Contains(search) || x.Brand.Contains(search) || x.TransmitId.Contains(search) || x.StoreKey.Contains(search) || x.ReceiptKey.Contains(search) || x.ReceiptDate.ToString().Contains(search) || x.QtyReceived.ToString().Contains(search) || x.Status.Contains(search) || x.Susr1.Contains(search) || x.Susr2.Contains(search) || x.ReceiptType.Contains(search) || x.CreatedDate.ToString().Contains(search) || x.ModifiedDate.ToString().Contains(search) || x.CreatedBy.Contains(search) || x.ModifiedBy.Contains(search) );
            return this;
        }

		public PgaGrQuery WithPopupSearch(string search,string para="")
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.UDNo.Contains(search) || x.Material.Contains(search) || x.Quantity.ToString().Contains(search) || x.GrDate.Contains(search) || x.Warehouse.Contains(search) || x.RC.Contains(search) || x.Plant.Contains(search) || x.Vendor.Contains(search) || x.GRNo.Contains(search) || x.GRItem.Contains(search) || x.Area.Contains(search) || x.Brand.Contains(search) || x.TransmitId.Contains(search) || x.StoreKey.Contains(search) || x.ReceiptKey.Contains(search) || x.ReceiptDate.ToString().Contains(search) || x.QtyReceived.ToString().Contains(search) || x.Status.Contains(search) || x.Susr1.Contains(search) || x.Susr2.Contains(search) || x.ReceiptType.Contains(search) || x.CreatedDate.ToString().Contains(search) || x.ModifiedDate.ToString().Contains(search) || x.CreatedBy.Contains(search) || x.ModifiedBy.Contains(search) );
            return this;
        }

		public PgaGrQuery Withfilter(IEnumerable<filterRule> filters)
        {
           if (filters != null)
           {
               foreach (var rule in filters)
               {
                  
					
				    						if (rule.field == "Id" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							And(x => x.Id == val);
						}
				    
					
					
				    				
											if (rule.field == "UDNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.UDNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Material"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Material.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "Quantity" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							And(x => x.Quantity == val);
						}
				    
					
				    				
											if (rule.field == "GrDate"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.GrDate.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Warehouse"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Warehouse.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "RC"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.RC.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Plant"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Plant.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Vendor"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Vendor.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "GRNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.GRNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "GRItem"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.GRItem.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Area"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Area.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Brand"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Brand.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TransmitId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TransmitId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "StoreKey"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.StoreKey.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ReceiptKey"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ReceiptKey.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "ReceiptDate" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDateTime())
						{	
							var date = Convert.ToDateTime(rule.value) ;
							And(x => SqlFunctions.DateDiff("d", date, x.ReceiptDate)>=0);
						}
				   
				    				
					
				    
											if (rule.field == "QtyReceived" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							And(x => x.QtyReceived == val);
						}
				    
					
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Susr1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Susr1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Susr2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Susr2.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ReceiptType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ReceiptType.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "CreatedDate" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDateTime())
						{	
							var date = Convert.ToDateTime(rule.value) ;
							And(x => SqlFunctions.DateDiff("d", date, x.CreatedDate)>=0);
						}
				   
				    				
					
				    
					
											if (rule.field == "ModifiedDate" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDateTime())
						{	
							var date = Convert.ToDateTime(rule.value) ;
							And(x => SqlFunctions.DateDiff("d", date, x.ModifiedDate)>=0);
						}
				   
				    				
											if (rule.field == "CreatedBy"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CreatedBy.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ModifiedBy"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ModifiedBy.Contains(rule.value));
						}
				    
				    
					
					
				    									
                   
               }
           }
            return this;
        }
    }
}




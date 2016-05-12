
                    
      
     
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
   public class PgaSkuQuery:QueryObject<PgaSku>
    {
        public PgaSkuQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.Sku.Contains(search) || x.Description.Contains(search) || x.StoreKey.Contains(search) || x.Keeper.Contains(search) || x.Warehouse.Contains(search) || x.MOQ.ToString().Contains(search) || x.LotNo.Contains(search) || x.Mo.Contains(search) );
            return this;
        }

		public PgaSkuQuery WithPopupSearch(string search,string para="")
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.Sku.Contains(search) || x.Description.Contains(search) || x.StoreKey.Contains(search) || x.Keeper.Contains(search) || x.Warehouse.Contains(search) || x.MOQ.ToString().Contains(search) || x.LotNo.Contains(search) || x.Mo.Contains(search) );
            return this;
        }

		public PgaSkuQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
					
					
				    				
											if (rule.field == "Sku"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Sku.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "StoreKey"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.StoreKey.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Keeper"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Keeper.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Warehouse"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Warehouse.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "MOQ" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							And(x => x.MOQ == val);
						}
				    
					
					
				    				
											if (rule.field == "LotNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LotNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Mo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Mo.Contains(rule.value));
						}
				    
				    
					
					
				    									
                   
               }
           }
            return this;
        }
    }
}




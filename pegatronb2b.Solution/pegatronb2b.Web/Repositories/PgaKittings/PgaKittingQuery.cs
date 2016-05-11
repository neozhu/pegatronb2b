
                    
      
     
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
   public class PgaKittingQuery:QueryObject<PgaKitting>
    {
        public PgaKittingQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.SeqId.Contains(search) || x.Plant.Contains(search) || x.HubId.Contains(search) || x.PdLine.Contains(search) || x.TransType.Contains(search) || x.MO.Contains(search) || x.Stage.Contains(search) || x.ItemNo.Contains(search) || x.Material.Contains(search) || x.Description.Contains(search) || x.Keeper.Contains(search) || x.FromWH.Contains(search) || x.ToWH.Contains(search) || x.RequestQty.ToString().Contains(search) || x.Building.Contains(search) || x.Dock.Contains(search) || x.RequestDate.Contains(search) || x.Remark.Contains(search) || x.LotNo.Contains(search) || x.UDNo.Contains(search) || x.CloseDateTime.ToString().Contains(search) || x.KittingId.Contains(search) || x.OrderKey.Contains(search) || x.StoreKey.Contains(search) || x.ShipDate.Contains(search) || x.ShipQty.ToString().Contains(search) || x.OrderStatus.Contains(search) || x.Status.Contains(search) || x.Remark1.Contains(search) || x.Note.Contains(search) || x.Unit.Contains(search) || x.TrailerNumber.Contains(search) );
            return this;
        }

		public PgaKittingQuery WithPopupSearch(string search,string para="")
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.SeqId.Contains(search) || x.Plant.Contains(search) || x.HubId.Contains(search) || x.PdLine.Contains(search) || x.TransType.Contains(search) || x.MO.Contains(search) || x.Stage.Contains(search) || x.ItemNo.Contains(search) || x.Material.Contains(search) || x.Description.Contains(search) || x.Keeper.Contains(search) || x.FromWH.Contains(search) || x.ToWH.Contains(search) || x.RequestQty.ToString().Contains(search) || x.Building.Contains(search) || x.Dock.Contains(search) || x.RequestDate.Contains(search) || x.Remark.Contains(search) || x.LotNo.Contains(search) || x.UDNo.Contains(search) || x.CloseDateTime.ToString().Contains(search) || x.KittingId.Contains(search) || x.OrderKey.Contains(search) || x.StoreKey.Contains(search) || x.ShipDate.Contains(search) || x.ShipQty.ToString().Contains(search) || x.OrderStatus.Contains(search) || x.Status.Contains(search) || x.Remark1.Contains(search) || x.Note.Contains(search) || x.Unit.Contains(search) || x.TrailerNumber.Contains(search) );
            return this;
        }

		public PgaKittingQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
					
					
				    				
											if (rule.field == "SeqId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SeqId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Plant"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Plant.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "HubId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.HubId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PdLine"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PdLine.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TransType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TransType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "MO"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.MO.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Stage"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Stage.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ItemNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ItemNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Material"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Material.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Keeper"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Keeper.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "FromWH"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.FromWH.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ToWH"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ToWH.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "RequestQty" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							And(x => x.RequestQty == val);
						}
				    
					
				    				
											if (rule.field == "Building"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Building.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Dock"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Dock.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "RequestDate"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.RequestDate.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LotNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LotNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "UDNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.UDNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "CloseDateTime" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDateTime())
						{	
							var date = Convert.ToDateTime(rule.value) ;
							And(x => SqlFunctions.DateDiff("d", date, x.CloseDateTime)>=0);
						}
				   
				    				
											if (rule.field == "KittingId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.KittingId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "OrderKey"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderKey.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "StoreKey"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.StoreKey.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ShipDate"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ShipDate.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "ShipQty" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							And(x => x.ShipQty == val);
						}
				    
					
				    				
											if (rule.field == "OrderStatus"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderStatus.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Remark1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Note"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Note.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Unit"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Unit.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TrailerNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TrailerNumber.Contains(rule.value));
						}
				    
				    
					
					
				    									
                   
               }
           }
            return this;
        }
    }
}




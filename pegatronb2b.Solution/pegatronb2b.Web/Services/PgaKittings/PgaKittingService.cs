
             
           
 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using Service.Pattern;

using pegatronb2b.Web.Models;
using pegatronb2b.Web.Repositories;

using System.Data;
using System.Reflection;
namespace pegatronb2b.Web.Services
{
    public class PgaKittingService : Service< PgaKitting >, IPgaKittingService
    {

        private readonly IRepositoryAsync<PgaKitting> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  PgaKittingService(IRepositoryAsync< PgaKitting> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                  
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                PgaKitting item = new PgaKitting();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "PgaKitting").ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type pgakittingtype = item.GetType();
							PropertyInfo propertyInfo = pgakittingtype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type pgakittingtype = item.GetType();
							PropertyInfo propertyInfo = pgakittingtype.GetProperty(field.FieldName);
                            if (defval.ToLower() == "now" && propertyInfo.PropertyType ==typeof(DateTime))
                            {
                                propertyInfo.SetValue(item, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);
                            }
                            else
                            {
                                propertyInfo.SetValue(item, Convert.ChangeType(defval, propertyInfo.PropertyType), null);
                            }
						}
                }
                
                this.Insert(item);
               

            }
        }
    }
}




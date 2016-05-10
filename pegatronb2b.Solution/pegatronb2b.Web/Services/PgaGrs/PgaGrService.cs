
             
           
 

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
    public class PgaGrService : Service< PgaGr >, IPgaGrService
    {

        private readonly IRepositoryAsync<PgaGr> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  PgaGrService(IRepositoryAsync< PgaGr> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                  
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                PgaGr item = new PgaGr();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "PgaGr").ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type pgagrtype = item.GetType();
							PropertyInfo propertyInfo = pgagrtype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type pgagrtype = item.GetType();
							PropertyInfo propertyInfo = pgagrtype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(defval, propertyInfo.PropertyType), null);
						}
                }
                
                this.Insert(item);
               

            }
        }
    }
}




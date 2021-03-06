﻿
     
 
 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using Service.Pattern;
using pegatronb2b.Web.Models;
using pegatronb2b.Web.Repositories;

namespace pegatronb2b.Web.Services
{
    public interface IDataTableImportMappingService:IService<DataTableImportMapping>
    {

        IEnumerable<EntityInfo> GetAssemblyEntities();
        void GenerateByEnityName(string entityName);

        DataTableImportMapping FindMapping(string entitySetName, string sourceFieldName);
         
 
	}
}
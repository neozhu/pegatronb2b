

     
 
 
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

namespace pegatronb2b.Web.Services
{
    public interface IMenuItemService:IService<MenuItem>
    {

                  IEnumerable<MenuItem> GetByParentId(int  parentid);
        
                 IEnumerable<MenuItem>   GetSubMenusByParentId (int parentid);
         
         
 
		void ImportDataTable(DataTable datatable);
        IEnumerable<MenuItem> CreateWithController();
        IEnumerable<MenuItem> ReBuildMenus();
	}
}
﻿using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pegatronb2b.Web.Models
{
    public class B2BContext:DataContext
    {
        public B2BContext()
            : base("Name=DefaultConnection")
        { 
        }
         
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Product> Products { get; set; }

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        //public System.Data.Entity.DbSet<pegatronb2b.Web.Models.Company> Companies { get; set; }

        //public System.Data.Entity.DbSet<pegatronb2b.Web.Models.Department> Departments { get; set; }

        //public System.Data.Entity.DbSet<pegatronb2b.Web.Models.Work> Works { get; set; }

        //public System.Data.Entity.DbSet<pegatronb2b.Web.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<pegatronb2b.Web.Models.BaseCode> BaseCodes { get; set; }
        public System.Data.Entity.DbSet<pegatronb2b.Web.Models.CodeItem> CodeItems { get; set; }

        public System.Data.Entity.DbSet<pegatronb2b.Web.Models.MenuItem> MenuItems { get; set; }

        public DbSet<RoleMenu> RoleMenus { get; set; }

        public DbSet<DataTableImportMapping> DataTableImportMappings { get; set; }

        public System.Data.Entity.DbSet<pegatronb2b.Web.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<pegatronb2b.Web.Models.PgaGr> PgaGrs { get; set; }

        public System.Data.Entity.DbSet<pegatronb2b.Web.Models.PgaKitting> PgaKittings { get; set; }

        public System.Data.Entity.DbSet<pegatronb2b.Web.Models.PgaSku> PgaSkus { get; set; }
    }
}
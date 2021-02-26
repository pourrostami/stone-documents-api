using Microsoft.EntityFrameworkCore;
using Stone.DataLayer.Entities.Admin;
using Stone.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.DataLayer.Context
{
    public class StoneContext:DbContext
    {
        public StoneContext(DbContextOptions<StoneContext> options):base(options)
        {

        }
        #region User Section
        public DbSet<Stone.DataLayer.Entities.User.User> Users { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }
        //public DbSet<SubProduct> SubProducts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SubProd> SubProds { get; set; }
        public DbSet<EslimiDesign> EslimiDesigns { get; set; }

        #endregion

        #region Admin
        public DbSet<Admin> Admins { get; set; }
        #endregion

    }
}

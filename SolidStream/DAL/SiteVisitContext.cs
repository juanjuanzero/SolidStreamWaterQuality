using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SolidStream.Models;

namespace SolidStream.DAL
{
    public class SiteVisitContext : DbContext
    {


        
        //constructor defined for the constructing a connection instance
        public SiteVisitContext() : base("SiteVisitContext")
        {

        }

        public DbSet<SiteModel> SiteModel_tbl { get; set; }
        public DbSet<SiteVisitModel> SiteVisit_tbl { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
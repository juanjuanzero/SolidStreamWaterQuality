using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SolidStream.Models;

namespace SolidStream.DAL
{
    public class SiteVisitInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteVisitContext>
    {
        //the seed method takes in an instance of the SiteVisitContext
        protected override void Seed(SiteVisitContext context)
        {
            //base.Seed(context);
            var _siteVisits = new List<SiteVisitModel>
            {
                new SiteVisitModel
                {
                    SiteVisitID = 0,
                    Temperature = 15,
                    SpecCond = 500,
                    DissolvedOxygen = 10,
                    pH = 7,
                    StateSetting = SiteVisitModel.State.Before_Cleaning,
                    VisitDate = DateTime.Parse("2018-10-01"),
                    Comments = "hello world",
                    SondeSetting = SiteVisitModel.Sonde.Site,
                    SiteID = 0
                },
                new SiteVisitModel
                {
                    SiteVisitID = 1,
                    Temperature = 15,
                    SpecCond = 500,
                    DissolvedOxygen = 10,
                    pH = 4,
                    StateSetting = SiteVisitModel.State.Before_Cleaning,
                    VisitDate = DateTime.Parse("2018-12-01"),
                    Comments = "has a very low pH",
                    SondeSetting = SiteVisitModel.Sonde.Site,
                    SiteID = 0
                },
                new SiteVisitModel
                {
                    SiteVisitID = 2,
                    Temperature = 150,
                    SpecCond = 500,
                    DissolvedOxygen = 10,
                    pH = 7,
                    StateSetting = SiteVisitModel.State.Before_Cleaning,
                    VisitDate = DateTime.Parse("2018-11-01"),
                    Comments = "has a hot temp",
                    SondeSetting = SiteVisitModel.Sonde.Site,
                    SiteID = 0
                },
                new SiteVisitModel
                {
                    SiteVisitID = 3,
                    Temperature = 160,
                    SpecCond = 400,
                    DissolvedOxygen = 50,
                    pH = 8,
                    StateSetting = SiteVisitModel.State.Before_Cleaning,
                    VisitDate = DateTime.Parse("2018-12-01"),
                    Comments = "has a very hot temp",
                    SondeSetting = SiteVisitModel.Sonde.Site,
                    SiteID = 1
                }
                              
            };
            //adding it to the context class
            _siteVisits.ForEach(v => context.SiteVisit_tbl.Add(v)); //lambda expression for the v object to the context class of SiteVisit_tbl

            context.SaveChanges(); //save the changes to the context class

            var _site = new List<SiteModel>
            {
                new SiteModel
                {
                    SiteID = 0,
                    SiteName = "First Site",
                    SiteNumber = "03503000"
                },
                new SiteModel
                {
                    SiteID = 1,
                    SiteName = "Second Site",
                    SiteNumber = "03503050"
                }
            };

            _site.ForEach(s => context.SiteModel_tbl.Add(s));
            context.SaveChanges();

            //Added the following to the WebConfig File to let EF know about the context.
            //< contexts >
            //    < context type = "SolidStream.DAL.SiteVisitContext, SolidStream" >
            //    < databaseInitializer type = "SolidStream.DAL.SiteVisitInitializer, SolidStream" />
            //   </ context >
            //</ contexts >

        }
    }
}
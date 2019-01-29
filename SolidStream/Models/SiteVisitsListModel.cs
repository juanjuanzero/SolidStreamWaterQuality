using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolidStream.Models
{
    public class SiteVisitsListModel
    {
        public ICollection<SiteVisitModel> SiteVisitList { get; set; }
    }
}
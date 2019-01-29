using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolidStream.Models
{
    public class SiteModel
    {
        [Key]
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteNumber { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolidStream.Models
{
    public class SiteVisitModel
    {
        [Key]
        public int SiteVisitID { get; set; }
        public int Temperature { get; set; }
        public int SpecCond { get; set; }
        public int DissolvedOxygen { get; set; }
        public int pH { get; set; }

        public enum State
        {
            Before_Cleaning,
            After_Cleaning,
            Final
        }

        public enum Sonde { Site, Field}

        public State? StateSetting { get; set; } //Before Cleaning, After Cleaning, Final
        public DateTime VisitDate { get; set; } 
        public string Comments { get; set; }
        public Sonde? SondeSetting { get; set; } //site sonde or field sonde

        public int SiteID { get; set; }
    }
}
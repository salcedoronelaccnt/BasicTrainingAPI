using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicTraining.Models
{
    public class Holiday
    {
        public string HolidayID { get; set; }
        public string publicdate { get; set; }
        public string publiclocalName { get; set; }
        public string publicname { get; set; }
        public string publiccountryCode { get; set; }
        public bool publicfixed { get; set; }
        public bool publicglobal { get; set; }
        public string publiccounties { get; set; }
        public int publiclaunchYear { get; set; }
        public string publictype { get; set; }
    }

}

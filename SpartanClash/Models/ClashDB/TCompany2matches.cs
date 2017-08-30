using System;
using System.Collections.Generic;

namespace SpartanClash.Models
{
    public partial class TCompany2matches
    {
        public string MatchId { get; set; }
        public string Company { get; set; }

        public TCompanies CompanyNavigation { get; set; }
        public TClashdevset Match { get; set; }
    }
}

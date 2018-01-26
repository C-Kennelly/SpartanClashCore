using System;
using System.Collections.Generic;

namespace SpartanClash.Models.ClashDB
{
    public partial class TCompany2matches
    {
        public string MatchId { get; set; }
        public string CompanyId { get; set; }

        public TCompanies Company { get; set; }
        public TClashdevset Match { get; set; }
    }
}

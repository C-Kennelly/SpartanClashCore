using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SpartanClash.Models.ClashDB;

namespace ServiceRecord
{
    public class RegistryController : Controller
    {
        clashdbContext _clashdbContext;

        public RegistryController(clashdbContext context)
        {
            _clashdbContext = context;
        }

        public ActionResult All()
        {
            List<TCompanies> companyList = _clashdbContext.TCompanies.OrderBy(x => x.CompanyName).ToList();
            return View(companyList);
        }
    }
}

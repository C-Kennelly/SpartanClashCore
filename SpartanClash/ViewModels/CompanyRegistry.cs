using System.Collections.Generic;
using System.Linq;
using SpartanClash.Models;

namespace SpartanClash.ViewModels
{
    public class CompanyRegistry
    {
        public List<CompanyRegistryItem> registryItems;

        public CompanyRegistry()
        {
            using(var db = new clashdbContext())
            {
                List<TCompanies> allCompanies = db.TCompanies.OrderBy(x => x.Company).ToList();

                registryItems = new List<CompanyRegistryItem> (allCompanies.Count);

                foreach (TCompanies company in allCompanies)
                {
                    registryItems.Add(new CompanyRegistryItem(company));
                }
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using SpartanClash.Models;

namespace SpartanClash.ViewModels
{
    public class CompanyRegistry
    {
        clashdbContext _clashdbContext;
        public List<CompanyRegistryItem> registryItems;

        public CompanyRegistry(clashdbContext context)
        {
            _clashdbContext = context;

            List<TCompanies> allCompanies = _clashdbContext.TCompanies.OrderBy(x => x.Company).ToList();

            registryItems = new List<CompanyRegistryItem> (allCompanies.Count);

            foreach (TCompanies company in allCompanies)
            {
                registryItems.Add(new CompanyRegistryItem(company));
            }
        }
    }
}
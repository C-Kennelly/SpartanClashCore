using System.Collections.Generic;
using SpartanClashCore.Models;

namespace SpartanClashCore.ViewModels
{
    public class CompanyRegistry
    {
        public List<CompanyRegistryItem> registryItems;

        public CompanyRegistry()
        {
            using(var db = new clashdbEntities())
            {
                List<t_companies> allCompanies = db.t_companies.OrderBy(x => x.company).ToList();

                registryItems = new List<CompanyRegistryItem> (allCompanies.Count);

                foreach (t_companies company in allCompanies)
                {
                    registryItems.Add(new CompanyRegistryItem(company));
                }
            }
        }
    }
}
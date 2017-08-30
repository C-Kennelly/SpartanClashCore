using SpartanClash.Models;

namespace SpartanClash.ViewModels
{
    public class CompanyRegistryItem
    {
        public string companyName { get; }

        public CompanyRegistryItem(TCompanies rawItem)
        {
            companyName = rawItem.Company;
        }
    }
}
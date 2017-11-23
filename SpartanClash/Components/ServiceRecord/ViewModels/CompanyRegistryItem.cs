using SpartanClash.Models;

namespace ServiceRecord.ViewModels
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
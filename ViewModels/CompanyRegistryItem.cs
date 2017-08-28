using SpartanClashCore.Models;

namespace SpartanClashCore.ViewModels
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
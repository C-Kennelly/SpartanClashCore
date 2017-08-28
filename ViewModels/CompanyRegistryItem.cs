using SpartanClashCore.Models;

namespace SpartanClashCore.ViewModels
{
    public class CompanyRegistryItem
    {
        public string companyName { get; }

        public CompanyRegistryItem(t_companies rawItem)
        {
            companyName = rawItem.company;
        }
    }
}
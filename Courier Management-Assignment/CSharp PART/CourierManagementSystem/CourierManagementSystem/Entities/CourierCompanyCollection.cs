using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entities
{
    public class CourierCompanyCollection
    {
        private List<CourierCompany> companyList;
        public List<Courier> Couriers { get; set; } = new List<Courier>(); //Task 8 (3)
        public CourierCompanyCollection()
        {
            companyList = new List<CourierCompany>();
        }

        public void AddCompany(CourierCompany company)
        {
            companyList.Add(company);
        }

        public List<CourierCompany> GetAllCompanies()
        {
            return companyList;
        }

        public CourierCompany? GetCompanyById(int companyId)
        {
            return companyList.Find(c => c.CompanyID == companyId);
        }

        public bool RemoveCompany(int companyId)
        {
            var company = GetCompanyById(companyId);
            if (company != null)
            {
                companyList.Remove(company);
                return true;
            }
            return false;
        }
    }
}
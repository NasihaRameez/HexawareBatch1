using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Interfaces
{
    interface ICourierAdminInterface
    {
        //public interface ICourierAdminService
        //{
        //    int AddCourierStaff(Employee obj);

        //    bool IsValidEmployee(int empId);
        //}
        //public interface ICourierAdminInterface : ICourierCustomerInterface
        //{
        //    void UpdateCourierStatus(string trackingNumber, string newStatus);
        //    void RemoveCourierByTrackingNumber(string trackingNumber);

        //}
        public interface ICourierAdminInterface
        {
            void UpdateCourierStatus(string trackingNumber, string newStatus);
            void RemoveCourierByTrackingNumber(string trackingNumber);
        }

    }
}

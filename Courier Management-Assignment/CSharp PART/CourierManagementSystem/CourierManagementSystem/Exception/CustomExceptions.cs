using System;

namespace CourierManagementSystem.CustomException
{
    public class TrackingNumberNotFoundException : Exception
    {
        public TrackingNumberNotFoundException(string message) : base(message) { }
    }

    public class InvalidEmployeeIdException : Exception
    {
        public InvalidEmployeeIdException(string message) : base(message) { }
    }
}




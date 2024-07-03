using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.Shared.Constants
{
    public class ErrorMessages
    {
       // public const st
    }

    public static class EmployeeErrorMessages
    {
        public const string NotFound = "Employee Not Found,Invalid Employee ID";
        public const string CreateFail = "Fail to Create Employee";
        public const string UpdateFail = "Fail to Update Employee";
        public const string DeleteFail = "Fail to Delete Employee";
    }

    public static class CommonErrorMessages
    {
        public const string ModelCannotBeNull = "Request Model Cannot be Null or Empty";
    }
}

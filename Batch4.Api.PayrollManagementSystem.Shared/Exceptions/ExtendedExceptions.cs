using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, NotFoundException innerException) : base(message, innerException) { }
    }

    public class DBModifyException : Exception
    {
        public DBModifyException() : base() { }
        public DBModifyException(string message) : base(message) { }
        public DBModifyException(string message, DBModifyException innerException) : base(message, innerException) { }
    }
}

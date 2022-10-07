using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommon.CustomException
{
    public class InvalidProductException : ApplicationException
    {
        public InvalidProductException()
        {

        }

        public InvalidProductException(string msg)
            :base(msg)
        {

        }

        public InvalidProductException(string msg, Exception exception)
            :base(msg, exception)
        {

        }
    }
}

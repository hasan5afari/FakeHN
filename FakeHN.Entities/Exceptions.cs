using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.Entities
{
    public class DalException : Exception
    {
        public string Message_ { get; set; }

        public DalException(string message)
        {
            Message_ = message;
        }

    }

    public class BllException : Exception
    {
        public string Message_ { get; set; }

        public BllException(string message)
        {
            Message_ = message;
        }

    }


    public class UilException : Exception
    {
        public string Message_ { get; set; }

        public UilException(string payam)
        {
            Message_ = Message_;
        }

    }
}

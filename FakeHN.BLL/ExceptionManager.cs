using FakeHN.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.BLL
{
    public partial class ExceptionManager
    {
        public void saveException(string message)
        {
            ExceptionDao exceptionDao = new ExceptionDao();
            exceptionDao.saveException(message);
        }
    }
}

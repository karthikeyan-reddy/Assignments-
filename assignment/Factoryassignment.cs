using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj2_dlls.assignment
{
    public class Factoryassignment
    {
        public static ICustomerDataBaseLayer GetInstance()
        {
            return new DataAccessLayer();
        }
    }
}

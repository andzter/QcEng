using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class Lookup
    {

        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetUsers()
        {
            return dataacess.GetDataTable("select * from vw_userlookup");
        }
    }
}

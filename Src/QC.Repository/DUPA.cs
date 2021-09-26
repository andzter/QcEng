using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class DUPA
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetDUPA()
        {
            return GetDUPA(Lib.Settings.GetSetting("userid"));
        }

        public DataTable GetDUPA(params object[] args)
        {
            return dataacess.GetDataTable("usp_DUPAList", args);

        }

        public DataRow SaveDUPA(params object[] args)
        {
            return dataacess.GetDataRow("usp_DUPASaveNew", args);
        }

        public DataRow GetDUPAbyId(string id)
        {
            return dataacess.GetDataRow("usp_DUPAGetbyId", id);
        }
    }
}

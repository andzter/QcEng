using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class ProjectBom2
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetProjectBom2()
        {
            return dataacess.GetDataTable("select * from vw_projectbom");
        }

        public DataRow SaveProjectBom2(params object[] args)
        {
            return dataacess.GetDataRow("usp_ProjectBomSaveNew", args);
        }

        public DataRow GetProjectBombyId2(string id)
        {
            return dataacess.GetDataRow("usp_ProjectBomGetbyId", id);
        }
    }
}

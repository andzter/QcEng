using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class Inspection
    {
        readonly Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataRow Save(params object[] args)
        {
            return dataacess.GetDataRow("usp_InspectionSave", args);
        }

        public DataTable GetList(params object[] args)
        {
            return dataacess.GetDataTable("usp_InspectionGetList", args);
        }

        public DataTable GetHistory(params object[] args)
        {
            return dataacess.GetDataTable("usp_InspectionHistory", args);
        }

        public DataRow GetbyId(params object[] args)
        {
            return dataacess.GetDataRow("usp_InspectionGetbyId", args);
        }

        public int Delete(params object[] args)
        {
            return (int)dataacess.ExecSQLScalarSP("usp_InspectionDelete", args);
        }

        public DataTable InspectionList(params object[] args)
        {
            return dataacess.GetDataTable("usp_InspectionList", args);
        }
    }
}

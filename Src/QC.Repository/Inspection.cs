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

        public void Save(params object[] args)
        {
            dataacess.ExecuteNonQuery("usp_InspectionSave", args);
        }

        public DataRow SaveDetail(params object[] args)
        {
            return dataacess.GetDataRow("usp_InspectionSaveDetail", args);
        }

        public DataRow SaveDetailAttachment(params object[] args)
        {
            return dataacess.GetDataRow("usp_InspectionSaveAttachment", args);
        }

        public DataTable GetList(params object[] args)
        {
            return dataacess.GetDataTable("usp_InspectionGetList", args);
        }


        public DataRow Get(params object[] args)
        {
            return dataacess.GetDataRow("usp_InspectionGet", args);
        }

        public DataTable GetHistory(params object[] args)
        {
            return dataacess.GetDataTable("usp_InspectionHistory", args);
        }

        public DataRow GetbyId(params object[] args)
        {
            return dataacess.GetDataRow("usp_InspectionGetbyId", args);
        }

        // get detail row
        public DataRow GetDetail(params object[] args)
        {
            return dataacess.GetDataRow("usp_InspectionDetail", args);
        }

        // get all project detail
        public DataTable GetDetails(params object[] args)
        {
            return dataacess.GetDataTable("usp_InspectionDetails", args);
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

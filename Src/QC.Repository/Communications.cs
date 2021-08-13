using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class Communications
    {
        readonly Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataRow Save(params object[] args)
        {
            return dataacess.GetDataRow("usp_CommunicationsSave", args);
        }

        public DataTable GetList(params object[] args)
        {
            return dataacess.GetDataTable("usp_CommunicationsGetList", args);
        }

        public DataTable GetHistory(params object[] args)
        {
            return dataacess.GetDataTable("usp_CommunicationsHistory", args);
        }

        public DataRow GetbyId(params object[] args)
        {
            return dataacess.GetDataRow("usp_CommunicationsGetbyId", args);
        }

        public int Delete(params object[] args)
        {
            return (int)dataacess.ExecSQLScalarSP("usp_CommunicationsDelete", args);
        }

        public DataTable ProjectList(params object[] args)
        {
            return dataacess.GetDataTable("usp_CommunicationsProject", args);
        }













    }
}

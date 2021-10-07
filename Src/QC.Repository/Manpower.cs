using QC.Lib;
using System.Data;
 
namespace QC.Repository
{
    public class Manpower
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable Get(params object[] args)
        { 
            return dataacess.GetDataTable("usp_ProjectManpowerGet", args);
        }

        public DataTable GetList(params object[] args)
        {
            return dataacess.GetDataTable("usp_ProjectManpowerGetList", args);
        }

        public DataRow Save(params object[] args)
        {
            return dataacess.GetDataRow("usp_ProjectManpowerSave", args);
        }


        public int Delete(params object[] args)
        {
            return dataacess.ExecSQLScalarSP("usp_ProjectManpowerDelete", args).ToString().ToInt();
        }


    }
}

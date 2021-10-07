using QC.Lib;
using System.Data;

namespace QC.Repository
{
    public class Labor
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetDetail(params object[] args)
        {
            return dataacess.GetDataTable("uspLaborGetDetails", args);
        }


        public DataRow SaveDetail(params object[] args)
        {
            /*
                @id [nvarchar](50), 	@ProjectId [nvarchar](50),	@Seq [Int],	@DupaId [nvarchar](50),
	             @ItemCode [varchar](200), 	@Qty [float],	@Price [money], 	@user [nvarchar](50)
            */
            return dataacess.GetDataRow("usp_LaborSaveDetail", args);
        }

        public int DeleteDetail(params object[] args)
        {
            return dataacess.ExecSQLScalarSP("usp_LaborDeleteDetail", args).ToString().ToInt();
        }

        public DataRow GetbyId(string id)
        {
            return dataacess.GetDataRow("usp_LaborGetbyId", id);
        }
    }
}

using QC.Lib;
using System.Data;

namespace QC.Repository
{
    public class ProjectBom
    {
        DataAccess dataacess = new DataAccess();

        public DataTable GetProjectBomDetail(params object[] args)
        {
            return dataacess.GetDataTable("usp_BOMGetDetails", args);
        }

        public DataTable GetProjectBomDetailPrint(params object[] args)
        {
            return dataacess.GetDataTable("usp_ProjectPrintDetails", args);
        }

        public DataRow GetProjectBomHeaderPrint(params object[] args)
        {
            return dataacess.GetDataRow("usp_BOMPrintHeader", args);
        }

        public DataRow SaveProjectBom(params object[] args)
        {
            return dataacess.GetDataRow("usp_ProjectHeaderBOM", args);
        }

        public DataRow SaveDetails(params object[] args)
        {
            /*
                @id [nvarchar](50), 	@ProjectId [nvarchar](50),	@Seq [Int],	@DupaId [nvarchar](50),
	             @ItemCode [varchar](200), 	@Qty [float],	@Price [money], 	@user [nvarchar](50)
            */
            return dataacess.GetDataRow("usp_BOMSaveDetail", args);
        }

        public int DeleteDetails(params object[] args)
        {
            return dataacess.ExecSQLScalarSP("usp_BOMDeleteDetail", args).ToString().ToInt();
        }

        public DataRow GetProjectBombyId(string id)
        {
            return dataacess.GetDataRow("usp_ProjectBomGetbyId", id);
        }
    }
}

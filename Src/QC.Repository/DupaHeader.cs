using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class DupaHeader
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetDupaHeader()
        {
            return dataacess.GetDataTable("select id, ItemCode as [Item Code], Description, Unit, " +
                " UnitCost, AssumedOutputHour as [Assumed Output Hr]," +
                " AssumedNoOfUnitsLength as [Assumed No Of Units/Length], Width, " +
                " Area, Depth, Volume from DupaHeader");
        }

        public DataRow GetDupaHeaderId(params object[] args)
        {
            return dataacess.GetDataRow("usp_DupaHeaderId", args);
        }

        public DataRow SaveDupaHeader(params object[] args)
        {
            return dataacess.GetDataRow("usp_DupaHeaderSave", args);
        }

        public DataRow GetDupaHeaderbyId(string id)
        {
            return dataacess.GetDataRow("usp_DupaHeaderGetbyId", id);
        }
    }
}

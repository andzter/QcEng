using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class LaborCost
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetLaborCost()
        {
            return dataacess.GetDataTable("select id, Description, UnitCost1 as [Unit Price1]," +
                " UnitCost2 as [Unit Price2], UnitCost3 as [Unit Price3]," +
                " PickPrice as [Pick Price], Classification, SG from LaborCost");
        }

        public DataRow SaveLaborCost(params object[] args)
        {
            return dataacess.GetDataRow("usp_LaborCostSave", args);
        }

        public DataRow GetLaborCostbyId(params object[] args)
        {
            return dataacess.GetDataRow("usp_LaborCostGetbyId", args);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class MaterialCostcs
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetMaterialCost()
        {
            return dataacess.GetDataTable("select id, Description, Unit, UnitCost1 as [Unit Price1]," +
                " UnitCost2 as [Unit Price2], UnitCost3 as [Unit Price3], UnitCost4 as [Unit Price4]," +
                " PickPrice as [Pick Price] from MaterialCost");
        }

        public DataRow SaveMaterialCost(params object[] args)
        {
            return dataacess.GetDataRow("usp_MaterialCostSave", args);
        }

        public DataRow GetMaterialCostbyId(string id)
        {
            return dataacess.GetDataRow("usp_MaterialCostGetbyId", id);
        }
    }
}

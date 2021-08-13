using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class MaterialCostManual
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetMaterialCostManual()
        {
            return dataacess.GetDataTable("select HeaderId, ItemId, ItemCode, Description, " +
                " NoOfPersonsUnit, NoOfHoursQuantity, UnitCostHourlyRate, CostAmount " +
                " from DupaDetails");
        }

        public DataRow SaveDupaDetailsMaterial(params object[] args)
        {
            return dataacess.GetDataRow("usp_DupaDetailsSave", args);
        }

        public DataRow GetDupaDetailsbyId(string id)
        {
            return dataacess.GetDataRow("usp_DupaDetailsGetbyId", id);
        }
    }
}

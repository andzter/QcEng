using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class DupaDetailsMaterial
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetDupaDetailsMaterial(string id)
        {
            return dataacess.GetDataTable("select headerid, itemid, ItemCode, Description, " +
                " NoOfPersonsUnit as [Units], NoOfHoursQuantity as [Quantity]," +
                " UnitCostHourlyRate as [Unit Cost per Area], CostAmount as [Amount] from DupaDetails" +
                " Where ItemCode = 'C' and HeaderId = '" + id + "'");
        }

        public DataRow SaveDupaHeader(params object[] args)
        {
            return dataacess.GetDataRow("usp_DupaDetailsSave", args);
        }

        public DataRow GetDupaHeaderbyId(string id)
        {
            return dataacess.GetDataRow("usp_DupaDetailsGetbyId", id);
        }
    }
}

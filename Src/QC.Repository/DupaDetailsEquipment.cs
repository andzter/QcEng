using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class DupaDetailsEquipment
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetDupaDetailsEquipment(string id)
        {
            return dataacess.GetDataTable("select headerid, itemid, ItemCode, Description, " +
                " NoOfPersonsUnit as [No Of Units], NoOfHoursQuantity as [No Of Hours]," +
                " UnitCostHourlyRate as [Hourly Rate], CostAmount as [Cost] from DupaDetails" +
                " Where ItemCode like 'B%' and HeaderId = '" + id + "' Order by ItemCode Asc");
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

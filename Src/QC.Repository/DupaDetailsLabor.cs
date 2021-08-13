using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class DupaDetailsLabor
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetDupaDetailsLabor(string id)
        {
            return dataacess.GetDataTable("select headerid, itemid, ItemCode, Description, " +
                " NoOfPersonsUnit as [No Of Persons], NoOfHoursQuantity as [No Of Hours]," +
                " UnitCostHourlyRate as [Hourly Rate], CostAmount as [Amount] from DupaDetails" +
                " Where ItemCode = 'A' and HeaderId = '" + id + "'");
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
